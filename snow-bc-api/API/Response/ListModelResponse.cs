using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace snow_bc_api.API.Response
{
    public class ListModelResponse<TModel> : IListModelResponse<TModel>
    {
        public String Message { get; set; }

        public Boolean DidError { get; set; }

        public String ErrorMessage { get; set; }

        public Int32 PageSize { get; set; }

        public Int32 PageNumber { get; set; }

        public IEnumerable<TModel> Model { get; set; }
    }
}
