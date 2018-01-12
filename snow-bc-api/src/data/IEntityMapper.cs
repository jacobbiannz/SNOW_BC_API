using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace snow_bc_api.src.data
{
    public interface IEntityMapper
    {
        IEnumerable<IEntityMap> Mappings { get; }

        void MapEntities(ModelBuilder modelBuilder);
    }
}
