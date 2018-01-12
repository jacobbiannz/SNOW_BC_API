using System;
using System.Collections.Generic;
using System.Text;

namespace snow_bc_api.src.data
{
    public class BcApiEntityMapper : EntityMapper
    {
        public BcApiEntityMapper()
        {
            Mappings = new List<IEntityMap>()
            {
                
                new CountryMap() as IEntityMap,
                new ProvienceMap() as IEntityMap,
                new CityMap() as IEntityMap
            };
        }
    }
}
