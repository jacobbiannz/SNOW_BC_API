using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace snow_bc_api.src.model
{
    public abstract class Attraction : Entity
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
    }

    public class CityAttraction : Attraction
    {
        [ForeignKey("CityId")]
        public virtual City City { get; set; }

        public Guid CityId { get; set; }
    }

    public class ProvienceAttraction : Attraction
    {
       
        [ForeignKey("ProvienceId")]
        public virtual Provience Provience { get; set; }

        public Guid ProvienceId { get; set; }
    }


    public class CountryAttraction : Attraction
    {
        [ForeignKey("CountryId")]
        public virtual Country Country { get; set; }

        public Guid CountryId { get; set; }
    }


}
