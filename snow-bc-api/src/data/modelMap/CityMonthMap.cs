using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using snow_bc_api.src.model;

namespace snow_bc_api.src.data.modelMap
{
    public class CityMonthMap :  IEntityMap
    {
        public void Map(ModelBuilder modelBuilder)
        {
            var entity = modelBuilder.Entity<CityMonth>();

            entity.ToTable("CityMonth", "Production");

            entity.HasOne(a => a.City).WithMany(s => s.BestMonths).HasForeignKey(a => a.CityId);

            entity.HasOne(a => a.Month).WithMany(s => s.TopCities).HasForeignKey(a => a.MonthId);
        }
    }
}
