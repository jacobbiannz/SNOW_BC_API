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
//using snow_bc_api.API.ApiModel.ApiModelMap;


namespace snow_bc_api.API.Controllers
{
    [Route("api/[controller]")]
    public class CountryController : Controller
    {
        int page = 1;
        int pageSize = 100;

        private ICountryRepository _countryRepository;

        public CountryController(ICountryRepository repository)
        {
            _countryRepository = repository;
        }

        [HttpGet]
        [Route("Countries")]
        public IActionResult GetCountries()
        {
            var pagination = Request.Headers["Pagination"];

            if (!string.IsNullOrEmpty(pagination))
            {
                string[] vals = pagination.ToString().Split(',');
                int.TryParse(vals[0], out page);
                int.TryParse(vals[1], out pageSize);
            }

            int currentPage = page;
            int currentPageSize = pageSize;
            var totalCountries = _countryRepository.Count();
            var totalPages = (int)Math.Ceiling((double)totalCountries / pageSize);


            IEnumerable<Country> _countries = _countryRepository
               //.AllIncluding(s => s.Company, s => s.AllProducts)
                .AllIncluding(s=>s.AllProviences)
                .OrderBy(s => s.Id)
                .Skip((currentPage - 1) * currentPageSize)
                .Take(currentPageSize)
                .ToList();

            Response.AddPagination(page, pageSize, totalCountries, totalPages);

            var response = new ListModelResponse<CountryApiModel>() as IListModelResponse<CountryApiModel>;

            IEnumerable<CountryApiModel> _CountriesAM = Mapper.Map<IEnumerable<Country>, IEnumerable<CountryApiModel>>(_countries);

            return new OkObjectResult(_CountriesAM);
        }

        /*
        //---------------------------------------
        // GET: api/abc
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }
        */
        // GET: api/abc/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }
        
        // POST: api/abc
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }
        
        // PUT: api/abc/5
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
