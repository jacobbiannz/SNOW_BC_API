using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace snow_bc_api.src.data
{
    public interface IEntityMap
    {
        void Map(ModelBuilder modelBuilder);
    }
}
