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
        public T Data { get; set; } = default!;
        public bool IsSuccess { get; set; }
        public string Message { get; set; } = string.Empty;
        public ResponseType Status { get; set; }   

        public static ApiResponse<T> Success(T data, string messege, ResponseType status = ResponseType.Ok)
        {
            return new ApiResponse<T>
            {
                Data = data!,
                IsSuccess = true,
                Status = status,
                Message = messege
            };

        }

        public static ApiResponse<T> Fail(string error, ResponseType status = ResponseType.BadRequest)
        {
            return new ApiResponse<T>
            {
                Data = default!,
                IsSuccess = false,
                Status = status,
                Message = error
            };
        }

        public static ApiResponse<T> Fail(T data, string error, ResponseType status = ResponseType.BadRequest)
        {
            return new ApiResponse<T>
            {
                Data = data,
                IsSuccess = false,
                Status = status,
                Message = error
            };
        }
    }
}
