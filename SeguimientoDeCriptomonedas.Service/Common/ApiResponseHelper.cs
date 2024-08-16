using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeguimientoDeCriptomonedas.Service.Common
{
    public static class ApiResponseHelper
    {
        public static ApiResponse<T> CreateSuccessResponse<T>(T data, string message = "Operation successful.")
        {
            return new ApiResponse<T>("success", data, message);
        }

        public static ApiResponse<object> CreateErrorResponse(string code, string description, string message = "An error occurred.")
        {
            return new ApiResponse<object>("error", null, message, new ApiError { Code = code, Description = description });
        }
    }
}
