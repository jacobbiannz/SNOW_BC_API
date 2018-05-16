using snow_bc_api.src.data;
using snow_bc_api.src.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace snow_bc_api.src.Repositories.modelRepository
{

    public class AttractionRepository : EntityRepository<Attraction>, IAttractionRepository
    {
        private readonly BcApiDbContext _context;
        public AttractionRepository(BcApiDbContext dbContext) : base(dbContext)
        {
            _context = dbContext;
        }
        public IEnumerable<Attraction> GetAttractionsForCity(Guid cityId)
        {
            var attractionIds = new List<Guid>();
            foreach (var cityAttraction in _context.CityAttractions)
            {
                if (cityAttraction.CityId == cityId)
                {
                    attractionIds.Add(cityAttraction.AttractionId);
                }
            }
            return _context.Attractions.Where(a => attractionIds.Contains(a.Id) && a.DeleteDate == null).OrderByDescending(c => c.Rate).ToList();
        }
    }
}
