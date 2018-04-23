using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using snow_bc_api.src.model;

namespace snow_bc_api.src.data.modelMap
{
    public class MonthMap : IEntityMap
    {
        public void Map(ModelBuilder modelBuilder)
        {
            var entity = modelBuilder.Entity<Month>();

            entity.ToTable("Month", "Production");
        }
    }
}
