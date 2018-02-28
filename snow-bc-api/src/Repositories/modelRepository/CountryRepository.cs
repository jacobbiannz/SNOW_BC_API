using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using snow_bc_api.src.model;
using snow_bc_api.src.data;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using snow_bc_api.API.ApiModel;
using snow_bc_api.src.Helpers;

namespace snow_bc_api.src.Repositories
{
    public class CountryRepository : EntityRepository<Country>, ICountryRepository
    {

        private readonly BcApiDbContext _context;
        private IPropertyMappingService _propertyMappingService;
        public CountryRepository(BcApiDbContext dbContext, IPropertyMappingService propertyMappingService) : base(dbContext)
        {
            _context = dbContext;
            _propertyMappingService = propertyMappingService;
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

        public Provience AddProvienceForCountry(Guid countryId, Provience provience)
        {
            var country = GetSingleAsync(countryId);
            if (country != null)
            {
                // if there isn't an id filled out (ie: we're not upserting),
                // we should generate one
                if (provience.Id == Guid.Empty)
                {
                    provience.Id = Guid.NewGuid();
                    provience.CreatedDate = DateTime.UtcNow;
                }
                country.Result.AllProviences.Add(provience);
            }
            return provience; 
        }
        public IEnumerable<Country> GetCountries(IEnumerable<Guid> countryIds)
        {
            return _context.Countries.Where(a => countryIds.Contains(a.Id))
                .OrderBy(a => a.Name)
                .ToList();
        }

        public PagedList<Country> GetCountries(CountryResourceParameters countryResourceParameters)
        {
            //var collectionBeforePaging = _context.Countries
            //    .OrderBy(a => a.Name).AsQueryable();

            var collectionBeforePaging =
                _context.Countries.ApplySort(countryResourceParameters.OrderBy,
                    _propertyMappingService.GetPropertyMapping<CountryApiModel, Country>());

            if (!string.IsNullOrEmpty(countryResourceParameters.Name))
            {
                var genreForWhereClause = countryResourceParameters.Name.Trim().ToLowerInvariant();
                collectionBeforePaging =
                    collectionBeforePaging.Where(a => a.Name.ToLowerInvariant() == genreForWhereClause);
            }

            if (!string.IsNullOrEmpty(countryResourceParameters.SearchQuery))
            {
                var searchQueryForWhereClause = countryResourceParameters.SearchQuery.Trim().ToLowerInvariant();

                collectionBeforePaging =
                    collectionBeforePaging.Where(a => a.Name.ToLowerInvariant().Contains(searchQueryForWhereClause));
            }

            return PagedList<Country>.Create(collectionBeforePaging, 
                countryResourceParameters.PageNumber, 
                countryResourceParameters.PageSize);
               
        }

        public override async Task<Country> AddAsync(Country country)
        {
            country.Id = Guid.NewGuid();
            country.CreatedDate = DateTime.UtcNow;

            _context.Countries.Add(country);

            if (country.AllProviences.Any())
            {
                foreach (var provience in country.AllProviences)
                {
                    provience.CreatedDate = DateTime.UtcNow;
                    provience.Id = Guid.NewGuid();
                }
            }
            await CommitAsync();
            return country;
        }

        public Provience UpdateProvienceForCountry(Guid countryId, Provience provience)
        {
         
            return provience;
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
