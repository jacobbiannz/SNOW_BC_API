﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using snow_bc_api.src.model;

namespace snow_bc_api.API.ApiModel.Mapping
{
   public class ApiModelToDomainMappingProfile : Profile
{
    public ApiModelToDomainMappingProfile()
    : this("MyProfile")
    {
    }
    protected ApiModelToDomainMappingProfile(string profileName)
    : base(profileName)
    {
            CreateMap<CountryApiModelForCreation, Country>();
      //   .ForMember(m => m.Name,
      //        map => map.MapFrom(am => am.Name))
      //   .ForMember(am => am.AllProviences,
      //          map => map.MapFrom(s => s.Proviences));

            CreateMap<CountryApiModel, Country>();
      //      .ForMember(m => m.Name,
      //          map => map.MapFrom(am => am.Name))
      //      .ForMember(am => am.AllProviences,
       //         map => map.MapFrom(s => s.Proviences));

            CreateMap<ProvienceApiModelForCreation, Provience>();
       //      .ForMember(m => m.Name,
       //      map => map.MapFrom(am => am.Name));

            CreateMap<ProvienceApiModel, Provience>();

        //     .ForMember(m => m.Name,
        //        map => map.MapFrom(am => am.Name));

        /*
                CreateMap<ProvienceApiModel, Provience>()
                   .ForMember(m => m.Name,
                      map => map.MapFrom(vm => vm.Name))
                 .ForMember(m => m.Country,
                      map => map.MapFrom(vm => vm.CountryInfo));

                CreateMap<BrandViewModel, Brand>()
                  .ForMember(m => m.Name,
                     map => map.MapFrom(vm => vm.Name))
                .ForMember(m => m.Company,
                     map => map.MapFrom(vm => vm.Company));
        */
            CreateMap<ProvienceApiModelForUpdate, Provience>();

            CreateMap<CityApiModelForCreation, City>();

            CreateMap<CityApiModelForUpdate, City>();

            CreateMap<CountryApiModelForUpdate, Country>();

            CreateMap<AttractionApiModel, CityAttraction>();

        }
}
}
