using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using snow_bc_api.src.model;

namespace snow_bc_api.src.data.modelMap
{
    public class CityImageMap : IEntityMap
    {
        public void Map(ModelBuilder modelBuilder)
        {
            var entity = modelBuilder.Entity<CityImage>();

            entity.ToTable("CityImage", "Production");

            entity.HasOne(a => a.City).WithMany(s => s.CityImages).HasForeignKey(a => a.CityId);
            entity.HasOne(a => a.Image);
        }
    }
}
