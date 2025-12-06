using Domain_Service.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application_Service.Common.APIResponses
{
    public class ApiResponse<T>
    {
        private T Data { get; set; } = default!;
        private bool IsSuccess { get; set; }
        private string Messeg { get; set; } = string.Empty;
        public ResponseType Status { get; set; } // i keep this property public becuase i use it for checking the response type at controller level after checking we return that type of response to swagger  

        public static ApiResponse<T> Success(T data, string messege, ResponseType status = ResponseType.Ok)
        {
            return new ApiResponse<T>
            {
                Data = data!,
                IsSuccess = true,
                Status = status,
                Messeg = messege
            };

        }

        public static ApiResponse<T> Fail(string error, ResponseType status = ResponseType.BadRequest)
        {
            return new ApiResponse<T>
            {
                Data = default!,
                IsSuccess = false,
                Status = status,
                Messeg = error
            };
        }
    }
}
