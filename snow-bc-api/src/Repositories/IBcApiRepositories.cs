using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using snow_bc_api.src.model;

namespace snow_bc_api.src.Repositories
{
    public interface ICountryRepository : IEntityRepository<Country>{}
    public interface IProvienceRepository : IEntityRepository<Provience>{}
    public interface ICityRepository : IEntityRepository<City>{}
}
