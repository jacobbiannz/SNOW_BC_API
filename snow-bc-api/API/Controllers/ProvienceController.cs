using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using snow_bc_api.API.ApiModel;
using snow_bc_api.API.Core;
using snow_bc_api.src.Helpers;
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
        private readonly IProvienceRepository _provienceRepository;

        private readonly ILogger _logger;
        // GET: api/abc
        public ProvienceController(ICountryRepository countryRepository, IProvienceRepository provienceRepository, ILogger<ProvienceController> logger)
        {
            _countryRepository = countryRepository;
            _provienceRepository = provienceRepository;
            _logger = logger;
        }
        [HttpGet()]
        public IActionResult GetProviencesForCountry(Guid countryId)
        {

            if (!_countryRepository.EntityExists(countryId))
            {
                return NotFound();
            }

            var proviencesForCountryFromRepo = _countryRepository.GetProviencesForCountry(countryId);


            var citiesApiModel = new Dictionary<string, IEnumerable<CityApiModel>>();

            foreach (var provience in proviencesForCountryFromRepo)
            {
               var citiesFromRepo =  _provienceRepository.GetCitiesForProvience(provience.Id).Take(5);
                citiesApiModel.Add(provience.Id.ToString(), Mapper.Map<IEnumerable<CityApiModel>>(citiesFromRepo));
            }

            var proviencesApiModel = Mapper.Map<IEnumerable<ProvienceApiModel>>(proviencesForCountryFromRepo);

            foreach (var provienceApiModel in proviencesApiModel)
            {
                foreach (var cityApiModel in citiesApiModel[provienceApiModel.Id.ToString()])
                {
                    provienceApiModel.Cities.Add(cityApiModel);
                }
            }

            var results = proviencesApiModel;

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

            if (provience.Name.Length == 1)
            {
                ModelState.AddModelError(nameof(ProvienceApiModelForCreation), "The provided name should have more than once character.");
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

            var provienceEntity = Mapper.Map<Provience>(provience);

 
            if (_countryRepository.AddProvienceForCountry(countryId, provienceEntity) == null)
            {
                throw new Exception($"Creating a provience for country {countryId} failed on save.");
            }

            var provienceForReturn = Mapper.Map<ProvienceApiModel>(provienceEntity);

            return CreatedAtRoute("GetProvienceForCountry", 
                new { countryId = countryId, provienceId = provienceForReturn.Id}, provienceForReturn);
        }


        
        [HttpDelete("{id}")]
        public IActionResult DeleteProvienceForCountry(Guid countryId, Guid id)
        {
            if (!_countryRepository.EntityExists(countryId))
            {
                return NotFound();
            }

            var provienceFromRepo = _countryRepository.GetProvienceForCountry(countryId, id);

            if (provienceFromRepo == null)
            {
                return NotFound();
            }

           

            if (_provienceRepository.DeleteAsync(provienceFromRepo)==null)
            {
                throw new Exception($"Deleting provience {id} for country {countryId} failed on save.");
            }

            _logger.LogInformation(100, $"Provience {id} for country {countryId} was deleted.");

            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateProvienceForCountry(Guid countryId, Guid id, [FromBody] ProvienceApiModelForUpdate provience)
        {
            if (provience == null)
            {
                return BadRequest();
            }

            if (provience.Name.Length == 1)
            {
                ModelState.AddModelError(nameof(ProvienceApiModelForUpdate), "The provided name should have more than once character.");
            }

            if (!ModelState.IsValid)
            {
                return  new Microsoft.AspNetCore.Mvc.UnprocessableEntityObjectResult(ModelState);
            }

            if (!_countryRepository.EntityExists(countryId))
            {
                return NotFound();
            }

            var provienceFromRepo = _countryRepository.GetProvienceForCountry(countryId, id);

            if (provienceFromRepo == null)
            {
                var provienceToAdd = Mapper.Map<Provience>(provience);
                provienceToAdd.Id = id;
                if (_countryRepository.AddProvienceForCountry(countryId, provienceToAdd) == null)
                {
                    throw new Exception($"Upserting provience {id} for country {countryId} failed on save.");
                }
                var provienceToReturn = Mapper.Map<ProvienceApiModel>(provienceToAdd);

                return CreatedAtRoute("GetProvienceForCountry", new {countryId = countryId, id = provienceToReturn.Id},
                    provienceToReturn);
            }

            Mapper.Map(provience, provienceFromRepo);

            if (_provienceRepository.UpdateAsync(provienceFromRepo).Result == null)
            {
                throw new Exception($"Updating provience {id} for country {countryId} failed on save.");
            }

            return NoContent();
        }

        [HttpPatch("{id}")]
        public IActionResult PartiallyUpdateProvienceForCountry(Guid countryId, Guid id, 
            [FromBody] JsonPatchDocument<ProvienceApiModelForUpdate> patchDoc)
        {
            if (patchDoc == null)
            {
                return BadRequest();
            }
            if (!_countryRepository.EntityExists(countryId))
            {
                return NotFound();
            }

            var provienceFromRepo = _countryRepository.GetProvienceForCountry(countryId, id);

            if (provienceFromRepo == null)
            {
                var provienceApiModel = new ProvienceApiModelForUpdate();
                patchDoc.ApplyTo(provienceApiModel);

                // add validation
                if (provienceApiModel.Name.Length == 1)
                {
                    ModelState.AddModelError(nameof(ProvienceApiModelForUpdate), "The provided name should have more than one character.");
                }
                TryValidateModel(provienceApiModel);

                if (!ModelState.IsValid)
                {
                    return new Microsoft.AspNetCore.Mvc.UnprocessableEntityObjectResult(ModelState);
                }

                var provienceForAdd = Mapper.Map<Provience>(provienceApiModel);

                provienceForAdd.Id = id;

                if (_countryRepository.AddProvienceForCountry(countryId, provienceForAdd)==null)
                {
                    throw new Exception($"Upserting provience {id} for country {countryId} falied on save.");
                }

                var provienceToReturn = Mapper.Map<ProvienceApiModel>(provienceForAdd);

                return CreatedAtRoute("GetProvienceForCountry", new {countryId = countryId, id = provienceToReturn.Id},
                    provienceToReturn);
            }

            var provienceToPatch = Mapper.Map<ProvienceApiModelForUpdate>(provienceFromRepo);

            patchDoc.ApplyTo(provienceToPatch, ModelState);


            // add validation
            if (provienceToPatch.Name.Length == 1)
            {
                ModelState.AddModelError(nameof(ProvienceApiModelForUpdate), "The provided name should have more than one character.");
            }
            TryValidateModel(provienceToPatch);

            if (!ModelState.IsValid)
            {
                return new Microsoft.AspNetCore.Mvc.UnprocessableEntityObjectResult(ModelState);
            }

            Mapper.Map(provienceToPatch, provienceFromRepo);
            if (_provienceRepository.UpdateAsync(provienceFromRepo).Result == null)
            {
                throw new Exception($"Patching provience {id} for country {countryId} failed on save.");
            }
            return NoContent();
        }
    }
}