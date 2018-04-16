using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Hosting;

namespace snow_bc_api.API.ApiModel.Mapping
{
    public class AutoMapperConfiguration
    {
       public static void Configure()
        {
            Mapper.Initialize(x =>
            {
                x.AddProfile<DomainToApiModelMappingProfile>();
                x.AddProfile<ApiModelToDomainMappingProfile>();
            });
        }
    }
}
