using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using snow_bc_api.src.Repositories;
using System.Linq.Dynamic.Core;
namespace snow_bc_api.src.Helpers
{
    public static class IQueryExtentions
    {
        public static IQueryable<T> ApplySort<T>(this IQueryable<T> source, string orderBy,
            Dictionary<string, PropertyMappingValue> mappingDictionary)
        {
            if (source == null)
            {
                throw  new ArgumentException("Source");
            }

            if (mappingDictionary == null)
            {
                throw new ArgumentException("mappingDictionary");
            }

            if (string.IsNullOrWhiteSpace(orderBy))
            {
                return source;
            }

            var orderByAfterSplit = orderBy.Split(',');

            foreach (var orderByClause in orderByAfterSplit.Reverse())
            {
                var trimedOrderByClause = orderByClause.Trim();

                var orderDescending = trimedOrderByClause.EndsWith(" desc");

                var indexOfFirstSpace = trimedOrderByClause.IndexOf(" ");

                var proertyName = indexOfFirstSpace == -1
                    ? trimedOrderByClause
                    : trimedOrderByClause.Remove(indexOfFirstSpace);

                if (!mappingDictionary.ContainsKey(proertyName))
                {
                    throw new ArgumentException($"Key mapping for {proertyName} is missing");
                }

                var propertyMappingValue = mappingDictionary[proertyName];

                if (propertyMappingValue == null)
                {
                    throw  new ArgumentException("propertyMappingValue");
                }

                foreach (var destinationProperty in propertyMappingValue.DestinationProperties.Reverse())
                {
                    if (propertyMappingValue.Revert)
                    {
                        orderDescending = !orderDescending;
                    }
                    source = source.OrderBy(destinationProperty + (orderDescending ? " descending" : " ascending"));
                }
            }
            return source;
        }
    }
}
