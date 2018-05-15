using Microsoft.EntityFrameworkCore;
using snow_bc_api.src.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace snow_bc_api.src.data.modelMap
{
    public class CountryAttractionMap : IEntityMap
    {
        public void Map(ModelBuilder modelBuilder)
        {
            var entity = modelBuilder.Entity<CountryAttraction>();

            entity.ToTable("CountryAttraction", "Production");

            entity.HasOne(a => a.Country).WithMany(s => s.Attractions).HasForeignKey(a => a.CountryId).IsRequired();
        }
    }
}
