using Microsoft.EntityFrameworkCore;
using snow_bc_api.src.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace snow_bc_api.src.data.modelMap
{
    public class AttractionMap : IEntityMap
    {
        public void Map(ModelBuilder modelBuilder)
        {
            var entity = modelBuilder.Entity<Attraction>();

            entity.ToTable("Attraction", "Production");
        }
    }
}
