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
