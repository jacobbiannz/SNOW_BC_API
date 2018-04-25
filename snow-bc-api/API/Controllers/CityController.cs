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


        private readonly ILogger _logger;

        public CityController(ICountryRepository countryRepository, IProvienceRepository provienceRepository, ICityRepository cityRepository, IImageRepository imageRepository, ILogger<ProvienceController> logger)
        {
            _logger = logger;
            _countryRepository = countryRepository;
            _provienceRepository = provienceRepository;
            _cityRepository = cityRepository;
            _imageRepository = imageRepository;
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
            }
            return Ok(results);
        }

        // GET: api/City/5
        [HttpGet("{id}")]
        public string GetCity(int cityId, bool includeProvience)
        {
            return "value";
        }

        // POST: api/City
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/City/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
