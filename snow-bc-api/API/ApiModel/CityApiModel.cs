﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace snow_bc_api.API.ApiModel
{
    public class CityApiModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public KeyValuePair<String, String> ProvienceInfo { get; set; }

    }
}
