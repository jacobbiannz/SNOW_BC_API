using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace snow_bc_api.src.model
{
    public class CityImage : Entity
    {

        [ForeignKey("CityId")]
        public City City { get; set; }

        public Guid CityId { get; set; }

        [ForeignKey("ImageId")]
        public Image Image { get; set; }

        public Guid ImageId { get; set; }
    }
}
