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

namespace snow_bc_api.API.Controllers
{

    [Route("api/cities")]
    public class CityController : Controller
    {
        private ILogger<CityController> _logger;
        private ICityRepository _cityRepository;
        public CityController(ICityRepository cityRepository, ILogger<CityController> logger)
        {
            _logger = logger;
            _cityRepository = cityRepository;
        }

        // GET: api/City
        [HttpGet]
        public ActionResult GetCities()
        {
            var cityEntities = _cityRepository.GetAll();
            var results = Mapper.Map<IEnumerable<CityApiModel>>(cityEntities);
            return Ok(results);
        }

        // GET: api/City/5
        [HttpGet("{id}")]
        public string Get(int id)
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
