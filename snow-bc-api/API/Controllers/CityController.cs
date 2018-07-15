using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using snow_bc_api.src.Repositories;
using snow_bc_api.src.data;
using AutoMapper;
using snow_bc_api.API.ApiModel;
using snow_bc_api.API.Core;
using snow_bc_api.src.model;
using snow_bc_api.src.Helpers;

namespace snow_bc_api.API.Controllers
{

    [Route("api/countries/{countryId}/proviences/{provienceId}/cities")]
    public class CityController : Controller
    {
        public int Page = 1;
        public int PageSize = 100;

        private readonly ICountryRepository _countryRepository;
        private readonly IProvienceRepository _provienceRepository;
        private readonly ICityRepository _cityRepository;
        private readonly IImageRepository _imageRepository;
        private readonly IAttractionRepository _attractionRepository;

        private readonly ILogger _logger;

        public CityController(ICountryRepository countryRepository,
                                IProvienceRepository provienceRepository, 
                                ICityRepository cityRepository, 
                                IImageRepository imageRepository,
                                IAttractionRepository attractionRepository,
                                ILogger<ProvienceController> logger)
        {
            _logger = logger;
            _countryRepository = countryRepository;
            _provienceRepository = provienceRepository;
            _cityRepository = cityRepository;
            _imageRepository = imageRepository;
            _attractionRepository = attractionRepository;
        }

        // GET: api/City
        [HttpGet()]
        public IActionResult GetCitiesForProvience(Guid countryId, Guid provienceId)
        {
            if (!_countryRepository.EntityExists(countryId))
            {
                return NotFound();
            }

            if (!_provienceRepository.EntityExists(provienceId))
            {
                return NotFound();
            }

            var citiesForProvienceFromRepo = _provienceRepository.GetCitiesForProvience(provienceId);

            var results = Mapper.Map<IEnumerable<CityApiModel>>(citiesForProvienceFromRepo);

            foreach (var cityApiModel in results)
            {
                cityApiModel.MainImageId = _imageRepository.GetMainImageIdForCity(cityApiModel.Id);

               var attractionsFromRepo = _attractionRepository.GetAttractionsForCity(cityApiModel.Id);

               var attractionsAPIModel = Mapper.Map<IEnumerable<AttractionApiModel>>(attractionsFromRepo);

               foreach (var cityAttractionAPIModel in attractionsAPIModel)
                {
                    cityApiModel.Attractions.Add(cityAttractionAPIModel);
                }
            }


            return Ok(results);
        }


        // GET: api/abc/5
        [HttpGet("{cityId}", Name = "GetCityForProvience")]
        public IActionResult GetCityForProvience(Guid provienceId, Guid cityId)
        {
            if (!_provienceRepository.EntityExists(provienceId))
            {
                return NotFound();
            }

            var cityForProvienceFromRepo = _provienceRepository.GetCityForProvience(provienceId, cityId);

            var results = Mapper.Map<CityApiModel>(cityForProvienceFromRepo);

            return Ok(results);
        }


        // POST: api/City
        [HttpPost]
        public IActionResult CreateCityForProvience(Guid countryId, Guid provienceId, [FromBody]CityApiModelForCreation city)
        {
            if (city == null)
            {
                return BadRequest();
            }

            if (city.Name.Length == 1)
            {
                ModelState.AddModelError(nameof(CityApiModelForCreation), "The provided name should have more than once character.");
            }

            if (!ModelState.IsValid)
            {
                //return 422
                return new Microsoft.AspNetCore.Mvc.UnprocessableEntityObjectResult(ModelState);
            }

            if (!_countryRepository.EntityExists(countryId))
            {
                return NotFound();
            }

            if (!_provienceRepository.EntityExists(provienceId))
            {
                return NotFound();
            }


            var cityEntity = Mapper.Map<City>(city);


            if (_provienceRepository.AddCityForProvience(provienceId, cityEntity) == null)
            {
                throw new Exception($"Creating a city for provience {provienceId} failed on save.");
            }

            var cityForReturn = Mapper.Map<CityApiModel>(cityEntity);

            return CreatedAtRoute("GetCityForProvience",
                new { provienceId = provienceId, cityId = cityForReturn.Id }, cityForReturn);
        }

        // PUT: api/City/5
        [HttpPut("{id}")]
        public IActionResult UpdateCityForProvience(Guid countryId, Guid provienceId, Guid id, [FromBody] CityApiModelForUpdate city)
        {
            if (city == null)
            {
                return BadRequest();
            }

            if (city.Name.Length == 1)
            {
                ModelState.AddModelError(nameof(CityApiModelForUpdate), "The provided name should have more than once character.");
            }

            if (!ModelState.IsValid)
            {
                return new Microsoft.AspNetCore.Mvc.UnprocessableEntityObjectResult(ModelState);
            }

            if (!_countryRepository.EntityExists(countryId))
            {
                return NotFound();
            }

            if (!_provienceRepository.EntityExists(provienceId))
            {
                return NotFound();
            }


            var cityFromRepo = _cityRepository.GetSingleAsync(id);

            if (cityFromRepo.Result == null)
            {
                var cityToAdd = Mapper.Map<City>(city);
                cityToAdd.Id = id;
                if (_provienceRepository.AddCityForProvience(provienceId, cityToAdd) == null)
                {
                    throw new Exception($"Upserting city {id} for provience {provienceId} failed on save.");
                }
                var cityToReturn = Mapper.Map<CityApiModel>(cityToAdd);

                return CreatedAtRoute("GetCityForProvience", new { provienceId = provienceId, id = cityToReturn.Id },
                    cityToReturn);
            }

            Mapper.Map(city, cityFromRepo.Result);

            if (_cityRepository.UpdateAsync(cityFromRepo.Result).Result == null)
            {
                throw new Exception($"Updating city {id} for provience {provienceId} failed on save.");
            }

            return NoContent();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
