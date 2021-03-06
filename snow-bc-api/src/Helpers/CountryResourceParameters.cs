﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace snow_bc_api.src.Helpers
{
    public class CountryResourceParameters
    {
        private const int MaxPageSize = 20;
        public int PageNumber { get; set; } = 1;

        private int _pageSize = 10;

        public int PageSize
        {
            get => _pageSize;
            set => _pageSize = (value > MaxPageSize) ? MaxPageSize : value;
        }

        public string Name { get; set; }

        public string SearchQuery { get; set; }

        public string OrderBy { get; set; }// = "Name";

        public string Fields { get; set; }

        public bool Deleted { get; set; } = false;
    }
}
