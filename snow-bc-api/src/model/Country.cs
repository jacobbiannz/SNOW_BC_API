using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace snow_bc_api.src.model
{
    public class Country : Entity
    {
        public string Name { get; set; }
        public ICollection<Provience> AllProviences { get; set; }

    }
}
