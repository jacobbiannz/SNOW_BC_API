﻿using snow_bc_api.src.data;
using snow_bc_api.src.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace snow_bc_api.src.Repositories.modelRepository
{
    public class ProvienceAttractionRepository : EntityRepository<ProvienceAttraction>, IProvienceAttractionRepository
    {
        public ProvienceAttractionRepository(BcApiDbContext dbContext) : base(dbContext)
        {
        }
    }
}
