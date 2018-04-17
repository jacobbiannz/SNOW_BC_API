using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using snow_bc_api.API.ApiModel;
using snow_bc_api.src.model;
using snow_bc_api.src.Repositories;

namespace snow_bc_api.API.Controllers
{
    [Route("api/images")]
    public class ImageController : Controller
    {

        private readonly ILogger _logger;
        private readonly IImageRepository _imageRepository;

        public ImageController(IImageRepository imageRepository, ILogger<ProvienceController> logger)
        {
            _logger = logger;
            _imageRepository = imageRepository;
        }

        [HttpGet("{id}")]
        public IActionResult GetImage(Guid id)
        {
            if (!_imageRepository.EntityExists(id))
            {
                return NotFound();
            }

            var imageData = _imageRepository.GetImage(id);
            return File(imageData, "image/png");
        }
    }
}
