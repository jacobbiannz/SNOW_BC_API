using snow_bc_api.src.data;
using snow_bc_api.src.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace snow_bc_api.src.Repositories.modelRepository
{
    public class MonthRepository : EntityRepository<Month>, IMonthRepository
    {
        private readonly BcApiDbContext _context;
        public MonthRepository(BcApiDbContext dbContext) : base(dbContext)
        {
            _context = dbContext;
        }


        public IEnumerable<City> GetCitiesForMonth(Guid monthId)
        {
            var cities = new List<Guid>();
            foreach (var cityMonth in _context.CityMonths)
            {
                if (cityMonth.MonthId == monthId)
                {
                    cities.Add(cityMonth.CityId);
                }
            }
            
            return _context.Cities.Where(c=> cities.Contains(c.Id)).OrderByDescending(c => c.Rate).ToList();
        }

        public IEnumerable<Month> GetMonths()
        {
            return _context.Months;
        }
    }
}
