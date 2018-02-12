using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using snow_bc_api.src.model;

namespace snow_bc_api.src.data
{
    public class ProvienceMap : IEntityMap
    {
        public void Map(ModelBuilder modelBuilder)
        {
            var entity = modelBuilder.Entity<Provience>();

            entity.ToTable("Provience", "Production");

          //  entity.HasKey(p => new { p.Id });

          //  entity.Property(p => p.Id).UseSqlServerIdentityColumn();

            entity.HasOne(a => a.Country).WithMany(s => s.AllProviences).HasForeignKey(a => a.CountryId);
        }
    }
}
