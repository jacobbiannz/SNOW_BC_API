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
                new MonthMap() as IEntityMap,
                new CityMonthMap() as IEntityMap,
                new SightMap() as IEntityMap,
                new LocationMap() as IEntityMap,
                new FoodAndDrinkMap() as IEntityMap,
                new ImageMap() as IEntityMap,
                new TopicMap() as IEntityMap,
                new CityTopicMap() as IEntityMap,
                new CityAttractionMap() as IEntityMap,
                new ProvienceAttractionMap() as IEntityMap,
                new CountryAttractionMap() as IEntityMap,
                new AttractionMap() as IEntityMap
            };
        }
    }
}
