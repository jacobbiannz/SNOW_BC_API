using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace snow_bc_api.API.ApiModel
{
    public class MonthApiModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Rate { get; set; }
        public ICollection<CityApiModel> TopCities { get; set; } = new List<CityApiModel>();
    }
}
