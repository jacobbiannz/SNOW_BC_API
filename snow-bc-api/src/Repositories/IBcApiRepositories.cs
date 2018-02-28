using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using snow_bc_api.src.Helpers;
using snow_bc_api.src.model;

namespace snow_bc_api.src.Repositories
{
    public interface ICountryRepository : IEntityRepository<Country>
    {
        IEnumerable<Provience> GetProviencesForCountry(Guid countryId);
        Provience GetProvienceForCountry(Guid countryId, Guid provienceId);
        Provience AddProvienceForCountry(Guid countryId, Provience provience);
        IEnumerable<Country> GetCountries(IEnumerable<Guid> countryIds);
        PagedList<Country> GetCountries(CountryResourceParameters countryResourceParameters);
    }
    public interface IProvienceRepository : IEntityRepository<Provience> { }
    public interface ICityRepository : IEntityRepository<City> { }
}
