using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace snow_bc_api.src.model
{
    public class City : Entity
    {
        public string Name { get; set; }
        public int ProvienceId { get; set; }
        public Provience Provience { get; set; }

    }
}
