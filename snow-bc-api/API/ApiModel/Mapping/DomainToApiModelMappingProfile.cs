using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using snow_bc_api.API.Controllers;
using snow_bc_api.src.Helpers;
using snow_bc_api.src.model;
using snow_bc_api.src.Repositories;

namespace snow_bc_api.API.ApiModel.Mapping
{
    public class DomainToApiModelMappingProfile : Profile
    {
        public DomainToApiModelMappingProfile()
        : this("MyProfile")
        {
          
        }

        protected DomainToApiModelMappingProfile(string profileName)
        : base(profileName)
        {
            //_env = env;
            CreateMap<Country, CountryApiModel>();
             //   .ForMember(am => am.Name,
              //      map => map.MapFrom(s => s.Name))
             //   .ForMember(am => am.Proviences,
             //       map => map.MapFrom(s => s.AllProviences));

            CreateMap<Country, CountryApiModelForCreation>();
         //       .ForMember(am => am.Name,
         //           map => map.MapFrom(s => s.Name))
          //      .ForMember(am => am.Proviences,
          //          map => map.MapFrom(s => s.AllProviences));

            CreateMap<Provience, ProvienceApiModel>();
           //     .ForMember(am => am.Name,
           //         map => map.MapFrom(s => s.Name))
             //   .ForMember(am => am.AllCities,
            //        s => s.ResolveUsing(src => ConvertCities(src.AllCities)))
            //    .ForMember(am => am.CountryInfo,
           //         s => s.ResolveUsing(src => ConvertCountry(src.CountryId)));

            CreateMap<Provience, ProvienceApiModelForCreation>();
            //     .ForMember(am => am.Name,
            //         map => map.MapFrom(s => s.Name));


            CreateMap<City, CityApiModel>()
                .ForMember(am => am.MainImageId,
                     s => s.ResolveUsing(src => MapImagePath(src.Images)));

            CreateMap<City, CityApiModelForCreation>();

            CreateMap<City, CityWithImagesApiModel>();

            CreateMap<City, CityApiModelForUpdate>();
            /*
            CreateMap<Category, CategoryViewModel>()
             .ForMember(vm => vm.Name,
                  map => map.MapFrom(s => s.Name))
             //.ForMember(vm => vm.Company,
             //     map => map.MapFrom(s => s.Company))
             .ForMember(vm => vm.AllProducts, s => s.ResolveUsing(src => ConvertProducts(src.AllProducts)));

            */
            CreateMap<Provience, ProvienceApiModelForUpdate>();


            CreateMap<Country, CountryApiModelForUpdate>();


            CreateMap<Month, MonthApiModel>();


            CreateMap<Image, ImageApiModel>();

           
        }

      

        /*
        private object ConvertProducts(ICollection<Product> src)
        {
            ICollection<KeyValuePair<string, string>> products = new Dictionary<string, string>();
            foreach (var p in src)
            {
                products.Add(new KeyValuePair<string, string>(p.Id.ToString(), p.Name));
            }
            return products;
        }
        */

        private object ConvertProviences(ICollection<Provience> src)
        {
            ICollection<KeyValuePair<string, string>> proviences = new Dictionary<string, string>();
            foreach (var p in src)
            {
                proviences.Add(new KeyValuePair<string, string>(p.Id.ToString(), p.Name));
            }

            return proviences;
        }

        private object ConvertCities(ICollection<City> src)
        {
            ICollection<KeyValuePair<string, string>> cities = new Dictionary<string, string>();
            foreach (var p in src)
            {
                cities.Add(new KeyValuePair<string, string>(p.Id.ToString(), p.Name));
            }

            return cities;
        }

        private object ConvertProvience(Guid provienceId)
        {
            return new KeyValuePair<string, string>("ProvienceId", provienceId.ToString());
        }

        private object ConvertCountry(Guid countryId)
        {
            return new KeyValuePair<string, string>("CountryId", countryId.ToString());
        }

        private Guid MapImagePath(ICollection<Image> images)
        {
            if (images.Count == 0)
            {
               return Guid.Empty;
            }
            var image = images.ToList().Find(i => i.IsMainImage);
            return image.Id;
        }
    }
}

