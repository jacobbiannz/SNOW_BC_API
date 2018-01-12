using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using snow_bc_api.src.model;

namespace snow_bc_api.src.data
{
    public class CityMap : IEntityMap
    {
        public void Map(ModelBuilder modelBuilder)
        {
            var entity = modelBuilder.Entity<City>();

            entity.ToTable("City", "Production");

            entity.HasKey(p => new { p.Id });

            entity.Property(p => p.Id).UseSqlServerIdentityColumn();
            entity.HasOne(a => a.Provience).WithMany(s => s.AllCities).HasForeignKey(a => a.ProvienceId);
        }
    }
}
