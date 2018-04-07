using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace snow_bc_api.API.ApiModel
{
    public abstract class EntityApiModelForManipulation
    {
        [Required(ErrorMessage = "You should fill out a name.")]
        [MaxLength(50, ErrorMessage = "The name should not have more than 50 characters.")]
        public virtual string Name { get; set; }
        public virtual int Rate { get; set; } = 0;
    }
}
