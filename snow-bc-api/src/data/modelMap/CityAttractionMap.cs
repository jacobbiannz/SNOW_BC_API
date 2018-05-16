using Microsoft.EntityFrameworkCore;
using snow_bc_api.src.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace snow_bc_api.src.data.modelMap
{
    public class CityAttractionMap : IEntityMap
    {
        public void Map(ModelBuilder modelBuilder)
        {
            var entity = modelBuilder.Entity<CityAttraction>();

            entity.ToTable("CityAttraction", "Production");

            entity.HasOne(a => a.City).WithMany(s => s.Attractions).HasForeignKey(a => a.CityId).IsRequired();

            entity.HasOne(a => a.Attraction).WithMany(s => s.Cities).HasForeignKey(a => a.AttractionId).IsRequired();
        }
    }
}
