﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;


namespace snow_bc_api.src.model
{
    public class FoodAndDrink : Entity
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [ForeignKey("LocationId")]
        public Location Location { get; set; }

        public Guid LocationId { get; set; }

    }
}
