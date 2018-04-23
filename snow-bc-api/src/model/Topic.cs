using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace snow_bc_api.src.model
{
    public class Topic : Entity
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        public ICollection<CityTopic> TopicCities { get; set; } = new List<CityTopic>();
    }
}
