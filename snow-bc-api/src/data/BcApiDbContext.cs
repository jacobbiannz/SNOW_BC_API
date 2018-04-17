using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using snow_bc_api.src.model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Options;

namespace snow_bc_api.src.data
{
    public class BcApiDbContext : DbContext
    {
        public DbSet<Country> Countries { get; set; }
        public DbSet<Provience> Proviences { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Month> Months { get; set; }
        public DbSet<CityMonth> CityMonths { get; set; }

        public DbSet<Image> Images { get; set; }

        public DbSet<CityImage> CityImages { get; set; }


        public String ConnectionString { get; }
        public IEntityMapper EntityMapper { get; }
     
        public BcApiDbContext(IOptions<AppSettings> appSettings, IEntityMapper entityMapper)
        {
            ConnectionString = appSettings.Value.ConnectionString;
            EntityMapper = entityMapper;
            Database.Migrate();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionString);
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }

            EntityMapper.MapEntities(modelBuilder);
            base.OnModelCreating(modelBuilder);
        }

    }
}
