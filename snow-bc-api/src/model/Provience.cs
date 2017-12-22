﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace snow_bc_api.src.model
{
    public class Provience : Entity
    {
        public string Name { get; set; }
        public int AreaId { get; set; }
        public Area Area { get; set; }
        public ICollection<City> AllCities { get; set; }
    }
}
