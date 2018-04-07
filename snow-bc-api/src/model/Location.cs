using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace snow_bc_api.src.model
{
    public class Location : Entity
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [ForeignKey("CityId")]
        public City City { get; set; }

        public Guid CityId { get; set; }


        public ICollection<FoodAndDrink> FoodAndDrinks { get; set; } = new List<FoodAndDrink>();

        public ICollection<Sight> Sights { get; set; } = new List<Sight>();
    }
}
