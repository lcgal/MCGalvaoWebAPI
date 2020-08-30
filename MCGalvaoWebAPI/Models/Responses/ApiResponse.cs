using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MCGalvaoWebAPI.Models.Responses
{
    public class ApiResponse<T>
    {
        public Boolean Result { get; set; }
        public T ReturnData { get; set; }
        public String Error { get; set; }
    }
}
