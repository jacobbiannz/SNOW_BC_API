using Microsoft.EntityFrameworkCore;
using snow_bc_api.src.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace snow_bc_api.src.data.modelMap
{
    public class ProvienceAttractionMap : IEntityMap
    {
        public void Map(ModelBuilder modelBuilder)
        {
            var entity = modelBuilder.Entity<ProvienceAttraction>();

            entity.ToTable("ProvienceAttraction", "Production");

            entity.HasOne(a => a.Provience).WithMany(s => s.Attractions).HasForeignKey(a => a.ProvienceId).IsRequired();
            entity.HasOne(a => a.Attraction).WithMany(s => s.Proviences).HasForeignKey(a => a.AttractionId).IsRequired();
        }
    }
}
