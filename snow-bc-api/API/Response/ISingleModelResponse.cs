using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace snow_bc_api.API.Response
{
    public interface ISingleModelResponse<TModel> : IResponse
{
    TModel Model { get; set; }
}
}
