using AutoMapper;
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

        public MonthCollectionController(IMonthRepository monthRepository, ILogger<MonthCollectionController> logger)
        {
            _logger = logger;
            _monthRepository = monthRepository;
        }

        [HttpGet()]
        public IActionResult GetMonths()
        {
            var monthsFromRepo = _monthRepository.GetMonths();
            var results = Mapper.Map<IEnumerable<MonthApiModel>>(monthsFromRepo);

            return Ok(results);
        }
    }
}
