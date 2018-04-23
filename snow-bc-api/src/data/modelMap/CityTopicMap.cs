using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using snow_bc_api.src.model;

namespace snow_bc_api.src.data.modelMap
{
    public class CityTopicMap : IEntityMap
    {
        public void Map(ModelBuilder modelBuilder)
        {
            var entity = modelBuilder.Entity<CityTopic>();

            entity.ToTable("CityTopic", "Production");

            entity.HasOne(a => a.City).WithMany(s => s.CityTopics).HasForeignKey(a => a.CityId);

            entity.HasOne(a => a.Topic).WithMany(s => s.TopicCities).HasForeignKey(a => a.TopicId);
        }
    }
}
