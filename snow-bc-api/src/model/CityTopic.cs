using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace snow_bc_api.src.model
{
    public class CityTopic : Entity
    {
        [ForeignKey("CityId")]
        public City City { get; set; }

        public Guid CityId { get; set; }

        [ForeignKey("TopicId")]
        public Topic Topic { get; set; }

        public Guid TopicId { get; set; }
    }
}
