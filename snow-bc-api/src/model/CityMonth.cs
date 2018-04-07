using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace snow_bc_api.src.model
{
    public class CityMonth : Entity
    {

        [ForeignKey("CityId")]
        public City City { get; set; }

        public Guid CityId { get; set; }

        [ForeignKey("MonthId")]
        public Month Month { get; set; }

        public Guid MonthId { get; set; }
    }
}
