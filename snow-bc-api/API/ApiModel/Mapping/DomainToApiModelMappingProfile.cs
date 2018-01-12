using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using snow_bc_api.src.model;

namespace snow_bc_api.API.ApiModel.Mapping
{
    public class DomainToApiModelMappingProfile : Profile
    {
        public DomainToApiModelMappingProfile()
        : this("MyProfile")
        {
        }
        protected DomainToApiModelMappingProfile(string profileName)
        : base(profileName)
        {
            CreateMap<Country, CountryApiModel>()
                .ForMember(am => am.Name,
                    map => map.MapFrom(s => s.Name))
                .ForMember(am => am.AllProvices, 
                    s => s.ResolveUsing(src => ConvertProviences(src.AllProviences)));

            /*
            CreateMap<Category, CategoryViewModel>()
             .ForMember(vm => vm.Name,
                  map => map.MapFrom(s => s.Name))
             //.ForMember(vm => vm.Company,
             //     map => map.MapFrom(s => s.Company))
             .ForMember(vm => vm.AllProducts, s => s.ResolveUsing(src => ConvertProducts(src.AllProducts)));

            */
        }

        /*
        private object ConvertProducts(ICollection<Product> src)
        {
            ICollection<KeyValuePair<string, string>> products = new Dictionary<string, string>();
            foreach (var p in src)
            {
                products.Add(new KeyValuePair<string, string>(p.Id.ToString(), p.Name));
            }
            return products;
        }
        */

        private object ConvertProviences(ICollection<Provience> src)
        {
            ICollection<KeyValuePair<string, string>> proviences = new Dictionary<string, string>();
            foreach (var p in src)
            {
                proviences.Add(new KeyValuePair<string, string>(p.Id.ToString(), p.Name));
            }

            return proviences;
        }
    }
}

