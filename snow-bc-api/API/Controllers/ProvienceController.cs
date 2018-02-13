using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
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

    [Route("api/countries/{countryId}/proviences")]
    public class ProvienceController : Controller
    {
        public int Page = 1;
        public int PageSize = 100;

        private readonly ICountryRepository _countryRepository;
        // GET: api/abc
        public ProvienceController(ICountryRepository repository)
        {
            _countryRepository = repository;
        }
        [HttpGet()]
        public IActionResult GetProviencesForCountry(Guid countryId)
        {

            if (!_countryRepository.EntityExists(countryId))
            {
                return NotFound();
            }

            var proviencesForCountryFromRepo = _countryRepository.GetProviencesForCountry(countryId);
            var results = Mapper.Map<IEnumerable<ProvienceApiModel>>(proviencesForCountryFromRepo);

            return Ok(results);
        }

        // GET: api/abc/5
        [HttpGet("{provienceId}", Name = "GetProvienceForCountry")]
        public IActionResult GetProvienceForCountry(Guid countryId, Guid provienceId)
        {
            if (!_countryRepository.EntityExists(countryId))
            {
                return NotFound();
            }

            var provienceForCountryFromRepo = _countryRepository.GetProvienceForCountry(countryId, provienceId);

            var results = Mapper.Map<ProvienceApiModel>(provienceForCountryFromRepo);

            return Ok(results);
        }

        // POST: api/abc
        [HttpPost]
        public IActionResult CreateProvienceForCountry(Guid countryId, [FromBody]ProvienceApiModelForCreation provience)
        {
            if (provience == null)
            {
                return BadRequest();
            }
            if (!_countryRepository.EntityExists(countryId))
            {
                return NotFound();
            }

            var provienceEntity = Mapper.Map<Provience>(provience);

            _countryRepository.AddProvienceForCountry(countryId, provienceEntity);

            if (!_countryRepository.Completed())
            {
                throw new Exception($"Creating a provience for country {countryId} failed on save.");
            }

            var provienceForReturn = Mapper.Map<ProvienceApiModel>(provienceEntity);

            return CreatedAtRoute("GetProvienceForCountry", 
                new { countryId = countryId, provienceId = provienceForReturn.Id}, provienceForReturn);
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