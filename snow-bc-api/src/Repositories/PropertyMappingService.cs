using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using snow_bc_api.API.ApiModel;
using snow_bc_api.src.model;

namespace snow_bc_api.src.Repositories
{
    public class PropertyMappingService : IPropertyMappingService
    {
        private Dictionary<string, PropertyMappingValue> _countryPrpertyMapping = 
            new Dictionary<string, PropertyMappingValue>(StringComparer.OrdinalIgnoreCase)
            {
                {"Id", new PropertyMappingValue(new List<string>(){"Id"}) },
                {"Name", new PropertyMappingValue(new List<string>(){"Name"}) },
                {"Description", new PropertyMappingValue(new List<string>(){"Description"}) }
            };
        private readonly IList<IPropertyMapping> propertyMappings = new List<IPropertyMapping>();

        public PropertyMappingService()
        {
            propertyMappings.Add(new PropertyMapping<CountryApiModel, Country>(_countryPrpertyMapping));
        }
        public Dictionary<string, PropertyMappingValue> GetPropertyMapping <TSource, TDestination>()
        {
            var matchMapping = propertyMappings.OfType<PropertyMapping<TSource, TDestination>>();

            if (matchMapping.Count() == 1)
            {
                return matchMapping.First().MappingDictionary;
            }

            throw  new Exception($"Cannot find exact property mapping instance for <{typeof(TSource)}>.");
        }

        public bool ValidMappingExistsFor<TSource, TDestination>(string fields)
        {
            var propertyMapping = GetPropertyMapping<TSource, TDestination>();
            if (string.IsNullOrWhiteSpace(fields))
            {
                return true;
            }

            var fieldsAfterSplit = fields.Split(',');

            foreach (var field in fieldsAfterSplit)
            {
                var trimmedField = field.Trim();

                var indexOfFirstSpace = trimmedField.IndexOf(" ");

                var propertyName = indexOfFirstSpace == 1 ? trimmedField : trimmedField.Remove(indexOfFirstSpace);

                if (!propertyMapping.ContainsKey(propertyName))
                {
                    return false;
                }   
            }
            return true;
        }
    }
}
