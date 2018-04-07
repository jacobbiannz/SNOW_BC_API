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
    [Route("api/months/{monthId}/cities")]
    public class MonthController : Controller
    {
        private readonly ILogger _logger;
        private readonly IMonthRepository _monthRepository;

        public MonthController(IMonthRepository monthRepository, ILogger<MonthController> logger)
        {
            _logger = logger;
            _monthRepository = monthRepository;
        }


        [HttpGet()]
        public IActionResult GetCitiesForMonth(Guid monthId)
        {
            if (!_monthRepository.EntityExists(monthId))
            {
                return NotFound();
            }

            var citiesForMonthFromRepo = _monthRepository.GetCitiesForMonth(monthId);
            var results = Mapper.Map<IEnumerable<CityApiModel>>(citiesForMonthFromRepo);

            return Ok(results);
        }
    }
}
