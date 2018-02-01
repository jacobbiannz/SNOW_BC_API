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

    [Route("api/cities")]
    public class CityController : Controller
    {
        public int Page = 1;
        public int PageSize = 100;

        private ILogger<CityController> _logger;
        private readonly ICityRepository _cityRepository;
        public CityController(ICityRepository cityRepository, ILogger<CityController> logger)
        {
            _logger = logger;
            _cityRepository = cityRepository;
        }

        // GET: api/City
        [HttpGet]
        public ActionResult GetCities()
        {
            var pagination = Request.Headers["Pagination"];

            if (!string.IsNullOrEmpty(pagination))
            {
                string[] vals = pagination.ToString().Split(',');
                int.TryParse(vals[0], out Page);
                int.TryParse(vals[1], out PageSize);
            }

            int currentPage = Page;
            int currentPageSize = PageSize;
            var totalCities = _cityRepository.Count();
            var totalPages = (int)Math.Ceiling((double)totalCities / PageSize);


            IEnumerable<City> cityEntities = _cityRepository
                .GetAll()
                .OrderBy(s => s.Name)
                .Skip((currentPage - 1) * currentPageSize)
                .Take(currentPageSize)
                .ToList();

            Response.AddPagination(Page, PageSize, totalCities, totalPages);

            var results = Mapper.Map<IEnumerable<CityApiModel>>(cityEntities);
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
