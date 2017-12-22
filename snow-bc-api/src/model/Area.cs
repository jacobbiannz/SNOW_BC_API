using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace snow_bc_api.src.model
{
    public class Area : Entity
    {
        public string Name { get; set; }
        public int CountryId { get; set; }
        public Country Contry { get; set; }
        public ICollection<Provience> AllProviences { get; set; }
    }

}
