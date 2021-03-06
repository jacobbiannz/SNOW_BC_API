﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace snow_bc_api.API.ApiModel
{
    public class ProvienceApiModelForUpdate : EntityApiModelForManipulation
    {
        [Required(ErrorMessage = "You should fill out a name.")]
        public override string Name
        {
            get => base.Name;
            set => base.Name = value;
        }
    }
}
