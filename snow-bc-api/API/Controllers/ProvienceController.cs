using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using snow_bc_api.API.ApiModel;
using snow_bc_api.API.Core;
using snow_bc_api.src.model;
using snow_bc_api.src.Repositories;

namespace snow_bc_api.API.Controllers
{

    [Route("api/proviences")]
    public class ProvienceController : Controller
    {
        public int Page = 1;
        public int PageSize = 100;

        private readonly IProvienceRepository _provienceRepository;
        // GET: api/abc
        public ProvienceController(IProvienceRepository repository)
        {
            _provienceRepository = repository;
        }
        [HttpGet]
        public ActionResult GetProviences()
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
            var totalProviences = _provienceRepository.Count();
            var totalPages = (int)Math.Ceiling((double)totalProviences / PageSize);


            IEnumerable<Provience> proviences = _provienceRepository
                .AllIncluding(s => s.AllCities)
                .OrderBy(s => s.Id)
                .Skip((currentPage - 1) * currentPageSize)
                .Take(currentPageSize)
                .ToList();

            Response.AddPagination(Page, PageSize, totalProviences, totalPages);


            var results = Mapper.Map<IEnumerable<ProvienceApiModel>>(proviences);

            return Ok(results);
        }

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