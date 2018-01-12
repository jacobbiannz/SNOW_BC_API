using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace snow_bc_api.API.ApiModel
{
    public class CountryApiModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<KeyValuePair<string, string>> AllProvices { get; set; }
    }
}
