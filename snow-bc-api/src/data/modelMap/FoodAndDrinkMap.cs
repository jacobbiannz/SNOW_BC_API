using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using snow_bc_api.src.model;

namespace snow_bc_api.src.data.modelMap
{
    public class FoodAndDrinkMap : IEntityMap
    {
        public void Map(ModelBuilder modelBuilder)
        {
            var entity = modelBuilder.Entity<FoodAndDrink>();

            entity.ToTable("FoodAndDrink", "Production");

            entity.HasOne(a => a.Location).WithMany(s => s.FoodAndDrinks).HasForeignKey(a => a.LocationId);

        }
    }
}
