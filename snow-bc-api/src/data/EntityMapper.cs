using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;


namespace snow_bc_api.src.data
{
    public class EntityMapper : IEntityMapper
    {
        public IEnumerable<IEntityMap> Mappings { get; protected set; }

        public void MapEntities(ModelBuilder modelBuilder)
        {
            foreach (var item in Mappings)
            {
                item.Map(modelBuilder);
            }
        }
    }
}
