using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace snow_bc_api.src.model
{
    public class Attraction : Entity
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        public ICollection<CityAttraction> Cities { get; set; } = new List<CityAttraction>();
        public ICollection<ProvienceAttraction> Proviences { get; set; } = new List<ProvienceAttraction>();
        public ICollection<CountryAttraction> Countries { get; set; } = new List<CountryAttraction>();
    }

    public class CityAttraction : Entity
    {
        [ForeignKey("CityId")]
        public virtual City City { get; set; }

        public Guid CityId { get; set; }


        [ForeignKey("AttractionId")]
        public virtual Attraction Attraction { get; set; }

        public Guid AttractionId { get; set; }
    }

    public class ProvienceAttraction : Entity
    {
       
        [ForeignKey("ProvienceId")]
        public virtual Provience Provience { get; set; }

        public Guid ProvienceId { get; set; }

        [ForeignKey("AttractionId")]
        public virtual Attraction Attraction { get; set; }

        public Guid AttractionId { get; set; }
    }


    public class CountryAttraction : Entity
    {
        [ForeignKey("CountryId")]
        public virtual Country Country { get; set; }

        public Guid CountryId { get; set; }

        [ForeignKey("AttractionId")]
        public virtual Attraction Attraction { get; set; }

        public Guid AttractionId { get; set; }
    }


}
