using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace snow_bc_api.API.Response
{
    public interface IListModelResponse<TModel> : IResponse
    {
        Int32 PageSize { get; set; }

        Int32 PageNumber { get; set; }

        IEnumerable<TModel> Model { get; set; }
    }
}
