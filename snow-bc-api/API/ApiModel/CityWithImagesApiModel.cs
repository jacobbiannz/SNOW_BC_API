using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace snow_bc_api.API.ApiModel
{
    public class CityWithImagesApiModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Rate { get; set; }
        public ICollection<ImageApiModel> Images { get; set; } = new List<ImageApiModel>();
    }
}
