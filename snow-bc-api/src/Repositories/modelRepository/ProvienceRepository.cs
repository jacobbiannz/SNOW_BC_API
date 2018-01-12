using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using snow_bc_api.src.model;
using snow_bc_api.src.data;

namespace snow_bc_api.src.Repositories
{
    public class ProvienceRepository : EntityRepository<Provience>, IProvienceRepository
    {
        public ProvienceRepository(BcApiDbContext dbContext) : base(dbContext)
        {
        }
    }
}
