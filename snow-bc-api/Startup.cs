using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Serialization;
using snow_bc_api.src.data;
using snow_bc_api.src.Repositories;
using snow_bc_api.API.ApiModel.Mapping;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Routing;
using NLog.Extensions.Logging;
using Swashbuckle.AspNetCore.Swagger;
using snow_bc_api.src.Repositories.modelRepository;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Diagnostics;

namespace snow_bc_api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(setupAction =>
            {
                setupAction.ReturnHttpNotAcceptable = true;
                setupAction.InputFormatters.Add(new XmlDataContractSerializerInputFormatter(setupAction));
                setupAction.OutputFormatters.Add(new XmlDataContractSerializerOutputFormatter());
            })
           .AddJsonOptions(a => a.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver())
            
           .AddXmlDataContractSerializerFormatters();

            // Automapper Configuration
            AutoMapperConfiguration.Configure();

            services.AddEntityFrameworkSqlServer().AddDbContext<BcApiDbContext>();
            services.Configure<AppSettings>(Configuration.GetSection("AppSettings"));

            services.AddScoped<IEntityMapper, BcApiEntityMapper>();
            services.AddScoped<ICountryRepository, CountryRepository>();
            services.AddScoped<ICityRepository, CityRepository>();
            services.AddScoped<IProvienceRepository, ProvienceRepository>();
            services.AddScoped<IMonthRepository, MonthRepository>();
            services.AddScoped<IImageRepository, ImageRepository>();
            services.AddScoped<IAttractionRepository, AttractionRepository>();
          
            services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();

            services.AddScoped<IUrlHelper, UrlHelper>(implementationFactory =>
            {
                var actionContext = implementationFactory.GetService<IActionContextAccessor>().ActionContext;
                return new UrlHelper(actionContext);
            });

            services.AddOptions();
            services.AddSingleton<IConfiguration>(Configuration);
            services.AddTransient<IPropertyMappingService, PropertyMappingService>();
            services.AddTransient<ITypeHelperService, TypeHelperService>();

            //services.AddResponseCaching();

            services.AddHttpCacheHeaders(
                (expirationModelOptions)
                =>
                {
                    expirationModelOptions.MaxAge = 600;
                },
                (validationModelOptions)
                    =>
                {
                    validationModelOptions.AddMustRevalidate = true;
                });


            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "My API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory, BcApiDbContext context)
        {
            loggerFactory.AddDebug(LogLevel.Information);
            loggerFactory.AddConsole();

            loggerFactory.AddNLog();

            app.UseStatusCodePages();

            if (env.IsDevelopment())
            {
                //app.UseDeveloperExceptionPage();
                // Add MVC to the request pipeline.
                app.UseCors(builder =>
                    builder.AllowAnyOrigin()
                    .AllowAnyHeader()
                    .AllowAnyMethod());

                app.UseExceptionHandler(appBuilder =>
                {
                    appBuilder.Run(async cont =>
                    {
                        cont.Response.Headers.Add("Access-Control-Allow-Origin", "*");
                        //cont.Response.Headers.Add("Access-Control-Allow-Methods", "POST, GET, PUT,  DELETE, OPTIONS");
                        //cont.Response.Headers.Add("Access-Control-Allow-Headers", "Content-Type, Accept");

                        var exceptionHandlerFeature = cont.Features.Get<IExceptionHandlerFeature>();
                        if (exceptionHandlerFeature != null)
                        {
                            var logger = loggerFactory.CreateLogger("Global exception logger");

                            logger.LogError(500, exceptionHandlerFeature.Error, exceptionHandlerFeature.Error.Message);
                        }
                        cont.Response.StatusCode = 500;
                        await cont.Response.WriteAsync("An unexpected fault happened. Try again later.");
                    });
                });

            }
            else
            {
                app.UseExceptionHandler(appBuilder =>
                {
                    appBuilder.Run(async cont =>
                    {
                        var exceptionHandlerFeature = cont.Features.Get<IExceptionHandlerFeature>();
                        if (exceptionHandlerFeature != null)
                        {
                            var logger = loggerFactory.CreateLogger("Global exception logger");

                            logger.LogError(500, exceptionHandlerFeature.Error, exceptionHandlerFeature.Error.Message);
                        }
                        cont.Response.StatusCode = 500;
                        await cont.Response.WriteAsync("An unexpected fault happened. Try again later.");
                    });
                });
            }

            //app.UseResponseCaching();

            //app.UseHttpCacheHeaders();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            app.UseMvc();
            




          //  DbInitializer.Initialize(context);
        }
    }
}
