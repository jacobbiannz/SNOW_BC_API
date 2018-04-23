using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace snow_bc_api.src.model
{
    public class City : Entity
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [ForeignKey("ProvienceId")]
        public virtual Provience Provience { get; set; }

        public Guid ProvienceId { get; set; }

        public virtual ICollection<Image> Images { get; set; } = new List<Image>();

        public virtual ICollection<CityMonth> BestMonths { get; set; } = new List<CityMonth>();

        public virtual ICollection<Location> Locations { get; set; } = new List<Location>();

        public virtual ICollection<CityTopic> CityTopics { get; set; } = new List<CityTopic>();
    }
}
