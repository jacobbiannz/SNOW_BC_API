﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace snow_bc_api.API.ApiModel
{
    public class CityApiModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Rate { get; set; }
        public string MainImageId { get; set; }

        public ICollection<AttractionApiModel> Attractions { get; set; } = new List<AttractionApiModel>();
    }
}
