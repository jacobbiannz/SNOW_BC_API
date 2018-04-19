using System;
using System.Collections.Generic;
using System.Text;
using snow_bc_api.src.data.modelMap;

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
                new CityMap() as IEntityMap,
                new MonthMapping() as IEntityMap,
                new CityMonthMapping() as IEntityMap,
                new SightMapping() as IEntityMap,
                new LocationMapping() as IEntityMap,
                new FoodAndDrinkMapping() as IEntityMap,
                new ImageMap() as IEntityMap
               
            };
        }
    }
}
