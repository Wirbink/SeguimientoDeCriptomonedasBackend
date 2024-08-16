using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeguimientoDeCriptomonedas.Service.Common
{
    public class ApiResponse<T>
    {
        public string Status { get; set; }
        public T Data { get; set; }
        public string Message { get; set; }
        public ApiError Error { get; set; }

        public ApiResponse(string status, T data, string message, ApiError error = null)
        {
            Status = status;
            Data = data;
            Message = message;
            Error = error;
        }
    }

    public class ApiError
    {
        public string Code { get; set; }
        public string Description { get; set; }
    }

}
