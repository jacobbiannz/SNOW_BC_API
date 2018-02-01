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
    [Route("api/Countries")]
    public class CountryController : Controller
    {
        public int Page = 1;
        public int PageSize = 100;

        private readonly ICountryRepository _countryRepository;

        public CountryController(ICountryRepository repository)
        {
            _countryRepository = repository;
        }

        [HttpGet]
        public IActionResult GetCountries()
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
            var totalCountries = _countryRepository.Count();
            var totalPages = (int)Math.Ceiling((double)totalCountries / PageSize);


            IEnumerable<Country> countries = _countryRepository
                //.AllIncluding(s => s.Company, s => s.AllProducts)
                .AllIncluding(s => s.AllProviences)
                .OrderBy(s => s.Id)
                .Skip((currentPage - 1) * currentPageSize)
                .Take(currentPageSize)
                .ToList();

            Response.AddPagination(Page, PageSize, totalCountries, totalPages);


            IEnumerable<CountryApiModel> countriesAm = Mapper.Map<IEnumerable<Country>, IEnumerable<CountryApiModel>>(countries);

            return new OkObjectResult(countriesAm);
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
