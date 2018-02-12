using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace snow_bc_api.src.model
{
    public interface IEntity
    {
        Guid Id { get; set; }

        DateTime? CreatedDate { get; set; }

        string CreatedBy { get; set; }

        DateTime? UpdatedDate { get; set; }

        string UpdatedBy { get; set; }
    }
}
