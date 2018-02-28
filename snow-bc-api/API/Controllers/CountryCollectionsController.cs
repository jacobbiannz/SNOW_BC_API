using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using snow_bc_api.API.ApiModel;
using snow_bc_api.src.Repositories;
using AutoMapper;
using snow_bc_api.src.Helpers;
using snow_bc_api.src.model;

namespace snow_bc_api.API.Controllers
{
    [Route("api/countrycollections")]
    public class CountryCollectionsController : Controller
    {
        private readonly ICountryRepository _countryRepository;

        public CountryCollectionsController(ICountryRepository countryRepository)
        {
            _countryRepository = countryRepository;
        }

        [HttpPost]
        public IActionResult CreateCountryCollection(
            [FromBody] IEnumerable<CountryApiModelForCreation> countryCollection)
        {
            if (countryCollection == null)
            {
                return BadRequest();
            }

            var countryEntities = Mapper.Map<IEnumerable<Country>>(countryCollection);

            foreach (var country in countryEntities)
            {
                if (_countryRepository.AddAsync(country).Result == null)
                {
                    throw new Exception("Creating an country collection failed on save.");
                }
            }

           
            var countryCollectionToReturn = Mapper.Map<IEnumerable<CountryApiModel>>(countryEntities);
            var idsAsString = string.Join(",", countryCollectionToReturn.Select(a => a.Id));
            return CreatedAtRoute("GetCountryCollection", new{ids=idsAsString}, countryCollectionToReturn);
        }

        [HttpGet("({ids})", Name = "GetCountryCollection")]
        public IActionResult GetCountryCollection([ModelBinder(BinderType = typeof(ArrayModelBinder))] IEnumerable<Guid> ids)
        {
            if (ids == null)
            {
                return BadRequest();
            }

            var countryEntities = _countryRepository.GetCountries(ids);

            if (ids.Count() != countryEntities.Count())
            {
                return NotFound();
            }

            var countriesToReturn = Mapper.Map<IEnumerable<CountryApiModel>>(countryEntities);

            return Ok(countriesToReturn);
        }
    }
}
