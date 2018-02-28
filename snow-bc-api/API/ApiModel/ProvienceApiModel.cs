using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace snow_bc_api.API.ApiModel
{
    public class ProvienceApiModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public KeyValuePair<String, String> CountryInfo { get; set; }

        public ICollection<KeyValuePair<string, string>> AllCities { get; set; }
    }
}
