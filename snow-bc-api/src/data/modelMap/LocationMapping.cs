using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using snow_bc_api.src.model;

namespace snow_bc_api.src.data.modelMap
{
    public class LocationMapping : IEntityMap
    {
        public void Map(ModelBuilder modelBuilder)
        {
            var entity = modelBuilder.Entity<Location>();

            entity.ToTable("Location", "Production");

            entity.HasOne(a => a.City).WithMany(s => s.Locations).HasForeignKey(a => a.CityId);
        }
    }
}
