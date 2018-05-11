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
        private BcApiDbContext _context;
        public ProvienceRepository(BcApiDbContext dbContext) : base(dbContext)
        {
            _context = dbContext;
        }

        public IEnumerable<City> GetCitiesForProvience(Guid provienceId)
        {
            return _context.Cities
                .Where(p => p.ProvienceId == provienceId && p.DeleteDate == null).OrderByDescending(r => r.Rate).ToList();
        }


        public City GetCityForProvience(Guid provienceId, Guid cityId)
        {
            return _context.Cities.FirstOrDefault(p => p.ProvienceId == provienceId && p.Id == cityId);
        }

        public async Task<City> AddCityForProvience(Guid procienceId, City City)
        {
            var provience = GetSingleAsync(procienceId);
            if (provience != null)
            {
                // if there isn't an id filled out (ie: we're not upserting),
                // we should generate one
                if (City.Id == Guid.Empty)
                {
                    City.Id = Guid.NewGuid();
                    City.CreatedDate = DateTime.UtcNow;
                }
                provience.Result.AllCities.Add(City);
                await CommitAsync();
            }
            return City;
        }
    }
}
