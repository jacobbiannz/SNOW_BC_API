using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using snow_bc_api.src.model;
using snow_bc_api.src.data;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace snow_bc_api.src.Repositories
{
    public class CountryRepository : EntityRepository<Country>, ICountryRepository
    {

        private BcApiDbContext _context;

        public CountryRepository(BcApiDbContext dbContext) : base(dbContext)
        {
            _context = dbContext;
        }


        public IEnumerable<Provience> GetProviencesForCountry(Guid countryId)
        {
            return _context.Proviences
                .Where(p => p.CountryId == countryId).OrderBy(p => p.Name).ToList();
        }

        public Provience GetProvienceForCountry(Guid countryId, Guid provienceId)
        {
            return _context.Proviences.FirstOrDefault(p => p.CountryId == countryId && p.Id == provienceId);
        }

        public void AddProvienceForCountry(Guid countryId, Provience provience)
        {
            var country = GetSingleAsync(countryId);
            if (country != null)
            {
                // if there isn't an id filled out (ie: we're not upserting),
                // we should generate one
                if (provience.Id == Guid.Empty)
                {
                    provience.Id = Guid.NewGuid();
                }
                country.Result.AllProviences.Add(provience);
            }
        }
        /*
        public override async Task<Country> AddAsync(Country entity)
        {
            EntityEntry dbEntityEntry = _context.Entry<Country>(entity);
            try
            {
                _context.Set<Country>().Add(entity);
                await CommitAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.InnerException);
            }

            return entity;
        }
        */

    }
}
