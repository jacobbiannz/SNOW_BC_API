using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using snow_bc_api.src.model;
using snow_bc_api.src.Repositories;
using Microsoft.EntityFrameworkCore;
using snow_bc_api.API.Response;
using snow_bc_api.API.Core;
using snow_bc_api.API.ApiModel;
using AutoMapper;
using snow_bc_api.src.Helpers;

//using snow_bc_api.API.ApiModel.ApiModelMap;


namespace snow_bc_api.API.Controllers
{
    [Route("api/countries")]
    public class CountryController : Controller
    {
        public int Page = 1;
        

        private readonly ICountryRepository _countryRepository;
        private readonly IProvienceRepository _provienceRepository;
        private readonly IUrlHelper _urlHelper;
        private readonly IPropertyMappingService _propertyMappingService;
        private readonly ITypeHelperService _typeHelperService;
        public CountryController(ICountryRepository countryRepository, IProvienceRepository provienceRepository, 
            IUrlHelper urlHelper, IPropertyMappingService propertyMappingService, ITypeHelperService typeHelperService)
        {
            _countryRepository = countryRepository;
            _provienceRepository = provienceRepository;
            _urlHelper = urlHelper;
            _propertyMappingService = propertyMappingService;
            _typeHelperService = typeHelperService;
        }

        [HttpGet(Name = "GetCountries")]
        [HttpHead]
        public IActionResult GetCountries(CountryResourceParameters countryResourceParameters)
        {
            if (!_propertyMappingService.ValidMappingExistsFor<CountryApiModel, Country>(countryResourceParameters.OrderBy))
            {
                return BadRequest();
            }

            if (!_typeHelperService.TypeHasProperties<CountryApiModel>(countryResourceParameters.Fields))
            {
                return BadRequest();
            }

            var countriesFromRepo = _countryRepository.GetCountries(countryResourceParameters);

            var previousPageLink = countriesFromRepo.HasPrevious
                ? CreateCountriesResourceUri(countryResourceParameters, ResourceUriType.PreviousPage)
                : null;

            var nextPageLink = countriesFromRepo.HasNext
                ? CreateCountriesResourceUri(countryResourceParameters, ResourceUriType.NextPage)
                : null;

            var paginationMetadata = new
            {
                totalCount = countriesFromRepo.TotalCount,
                pageSize = countriesFromRepo.PageSize,
                currentPage = countriesFromRepo.CurrentPage,
                totalPages = countriesFromRepo.TotalPages,
                previousPageLink = previousPageLink,
                nextPageLink = nextPageLink
            };

            Response.Headers.Add("X-Pagination", Newtonsoft.Json.JsonConvert.SerializeObject(paginationMetadata));


            var countries = Mapper.Map<IEnumerable<CountryApiModel>>(countriesFromRepo);

            return Ok(countries.ShapeData(countryResourceParameters.Fields));
        }

      
        [HttpGet("{id}", Name = "GetCountry")]
        public IActionResult GetCountry(Guid id, [FromQuery] string fields)
        {
            if (!_typeHelperService.TypeHasProperties<CountryApiModel>(fields))
            {
                return BadRequest();
            }
            var countryFromRepo =  _countryRepository.GetSingleAsync(id);

            if (countryFromRepo == null)
            {
                return NotFound();
            }

            var country = Mapper.Map<CountryApiModel>(countryFromRepo.Result);
            return Ok(country.ShapeData(fields));
        }

        // POST: api/abc
        [HttpPost]
        public IActionResult CreateCountry([FromBody]CountryApiModelForCreation country)
        {
            if (country == null)
            {
                return BadRequest();
            }

            var countryEntity = Mapper.Map<Country>(country);

            if (_countryRepository.AddAsync(countryEntity).Result == null)
            {
                throw new Exception("Creating an country failed on save.");
            }
            var countryToReturn = Mapper.Map<CountryApiModel>(countryEntity);

            return CreatedAtRoute("GetCountry", new { id = countryToReturn.Id }, countryToReturn);
        }

        [HttpPost("{id}")]
        public IActionResult BlockCountryCreation(Guid id)
        {
            if (_countryRepository.EntityExists(id))
            {
                return  new StatusCodeResult(StatusCodes.Status409Conflict);
            }
            return NotFound();
        }

        

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult DeleteCountry(Guid id)
        {
            var countryFromRepo = _countryRepository.GetSingleAsync(id);
            if (countryFromRepo == null)
            {
                return NotFound();
            }

            foreach (var provience in countryFromRepo.Result.AllProviences)
            {
               _provienceRepository.DeleteAsync(provience);
            }

            if (_countryRepository.DeleteAsync(countryFromRepo.Result).Result==null)
            {
                throw new Exception($"Deleting country {id} failed on save.");
            }
            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCountry(Guid id, [FromBody] CountryApiModelForUpdate country)
        {
            if (country == null)
            {
                return BadRequest();
            }

            if (country.Name.Length == 1)
            {
                ModelState.AddModelError(nameof(CountryApiModelForUpdate), "The provided name should have more than once character.");
            }

            if (!ModelState.IsValid)
            {
                return new UnprocessableEntityObjectResult(ModelState);
            }

            var countryFromRepo = _countryRepository.GetSingleAsync(id).Result;

            if (countryFromRepo == null)
            {
                var countryToAdd = Mapper.Map<Country>(country);
                countryToAdd.Id = id;
                if (_countryRepository.AddAsync(countryToAdd) == null)
                {
                    throw new Exception($"Upserting country {id} failed on save.");
                }
                var countryToReturn = Mapper.Map<CountryApiModel>(countryToAdd);

                return CreatedAtRoute("GetCountry", new { id = countryToReturn.Id },
                    countryToReturn);
            }

            Mapper.Map(country, countryFromRepo);

            if (_countryRepository.UpdateAsync(countryFromRepo).Result == null)
            {
                throw new Exception($"Updating country {id} failed on save.");
            }

            return NoContent();
        }


        [HttpOptions]
        public IActionResult GetCountriesOptions()
        {
            Response.Headers.Add("Allow", "GET,OPTIONS,POST");
            return Ok();
        }

        private string CreateCountriesResourceUri(CountryResourceParameters countryResourceParameters, ResourceUriType type)
        {
            switch (type)
            {
                case ResourceUriType.PreviousPage:
                    return _urlHelper.Link("GetCountries",
                        new
                        {
                            fields = countryResourceParameters.Fields,
                            orderBy = countryResourceParameters.OrderBy,
                            searchQuery= countryResourceParameters.SearchQuery,
                            name= countryResourceParameters.Name,
                            pageNumber = countryResourceParameters.PageNumber - 1,
                            pageSize = countryResourceParameters.PageSize
                        });
                case ResourceUriType.NextPage:
                    return _urlHelper.Link("GetCountries",
                        new
                        {
                            fields = countryResourceParameters.Fields,
                            orderBy = countryResourceParameters.OrderBy,
                            searchQuery = countryResourceParameters.SearchQuery,
                            name = countryResourceParameters.Name,
                            pageNumber = countryResourceParameters.PageNumber + 1,
                            pageSize = countryResourceParameters.PageSize
                        });
                default:
                    return _urlHelper.Link("GetCountries",
                        new
                        {
                            fields = countryResourceParameters.Fields,
                            orderBy = countryResourceParameters.OrderBy,
                            searchQuery = countryResourceParameters.SearchQuery,
                            name = countryResourceParameters.Name,
                            pageNumber = countryResourceParameters.PageNumber,
                            pageSize = countryResourceParameters.PageSize
                        });
            }
        }
    }
}
