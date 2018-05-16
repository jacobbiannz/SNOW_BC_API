using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace snow_bc_api.src.model
{
    public class Country : Entity
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        public virtual ICollection<Provience> AllProviences { get; set; } = new List<Provience>();

        public virtual ICollection<CountryAttraction> Attractions { get; set; } = new List<CountryAttraction>();
    }
}
