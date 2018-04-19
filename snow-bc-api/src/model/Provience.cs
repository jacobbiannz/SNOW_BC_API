using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace snow_bc_api.src.model
{
    public class Provience : Entity
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [ForeignKey("CountryId")]

        public virtual Country Country { get; set; }

        public Guid CountryId { get; set; }

        public virtual ICollection<City> AllCities { get; set; } = new List<City>();

    }
}
