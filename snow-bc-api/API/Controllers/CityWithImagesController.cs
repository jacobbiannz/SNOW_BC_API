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
    [Route("api/cities")]
    public class CityWithImagesController : Controller
    {
       
        private readonly ICityRepository _cityRepository;
        private readonly IImageRepository _imageRepository;

        private readonly ILogger _logger;

        public CityWithImagesController(ICityRepository cityRepository, IImageRepository imageRepository, ILogger<ProvienceController> logger)
        {
            _logger = logger;
            _cityRepository = cityRepository;
            _imageRepository = imageRepository;
        }

        // GET: api/City/5
        [HttpGet("{id}")]
        public IActionResult GetCity(Guid id)
        {
            var cityFromRepo = _cityRepository.GetSingleAsync(id);

            var cityApiModel = Mapper.Map<CityWithImagesApiModel>(cityFromRepo.Result);


            foreach (var image in _imageRepository.GetImagesForCity(id))
            {
                cityApiModel.Images.Add(Mapper.Map<ImageApiModel>(image));
            }

            return Ok(cityApiModel);
        }

    }
}
