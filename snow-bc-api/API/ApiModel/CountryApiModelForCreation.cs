using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace snow_bc_api.API.ApiModel
{
    public class CountryApiModelForCreation
    {
        public string Name { get; set; }
        public ICollection<ProvienceApiModelForCreation> Proviences { get; set; } = new List<ProvienceApiModelForCreation>();
    }
}
