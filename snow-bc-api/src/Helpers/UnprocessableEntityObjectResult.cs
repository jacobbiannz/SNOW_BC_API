﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace snow_bc_api.src.Helpers
{
    public class UnprocessableEntityObjectResult :ObjectResult
    {
        public UnprocessableEntityObjectResult(ModelStateDictionary modelState) : base(new SerializableError(modelState))
        {
            if (modelState == null)
            {
                throw  new ArgumentException(nameof(modelState));
            }
            StatusCode = 422;
        }
    }
}
