using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace snow_bc_api.API.ApiModel
{
    public class CountryApiModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Rate { get; set; }

        public ICollection<ProvienceApiModel> Proviences { get; set; } = new List<ProvienceApiModel>();
    }
}
