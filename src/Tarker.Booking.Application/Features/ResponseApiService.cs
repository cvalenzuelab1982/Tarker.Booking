using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tarker.Booking.Domain.Model;

namespace Tarker.Booking.Application.Features
{
    public static class ResponseApiService
    {
        public static BaseResponseModel Response(int statuscode, object? Data = null, string? message = null)
        {
            bool success = false;

            if (statuscode >= 200 && statuscode < 300) success = true;

            var result = new BaseResponseModel
            {
                StatusCode = statuscode,
                Success = success,
                Message = message,
                Data = Data
            };

            return result;
        }
    }
}
