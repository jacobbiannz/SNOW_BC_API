using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using snow_bc_api.API.ApiModel;
using snow_bc_api.src.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace snow_bc_api.API.Controllers
{
    [Route("api/monthcollection")]
    public class MonthCollectionController :Controller
    {
        private readonly ILogger _logger;
        private readonly IMonthRepository _monthRepository;
        private IHostingEnvironment _env;
        public MonthCollectionController(IHostingEnvironment env, IMonthRepository monthRepository, ILogger<MonthCollectionController> logger)
        {
            _logger = logger;
            _monthRepository = monthRepository;
            _env = env;
        }

        [HttpGet()]
        public IActionResult GetMonths()
        {
            var monthsFromRepo = _monthRepository.GetMonths();

            
            var monthsApiModel = Mapper.Map<IEnumerable<MonthApiModel>>(monthsFromRepo);


            foreach (var monthApiModel in monthsApiModel)
            {
              var citiesFromRepo =  _monthRepository.GetCitiesForMonth(monthApiModel.Id).Take(5);

                foreach (var city in citiesFromRepo)
                {
                    var cityApiModel = Mapper.Map<CityApiModel>(city);
                    monthApiModel.TopCities.Add(cityApiModel);
                } 
            }
            
            return Ok(monthsApiModel);
        }
    }
}
