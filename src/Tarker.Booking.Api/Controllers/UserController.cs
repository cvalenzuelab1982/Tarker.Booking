using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Tarker.Booking.Application.Exceptions;
using Tarker.Booking.Application.Features;

namespace Tarker.Booking.Api.Controllers
{
    [Route("api/v1/user")]
    [ApiController]
    [TypeFilter(typeof(ExceptionsManager))]
    public class UserController : ControllerBase
    {
        public UserController()
        {
            
        }

        [HttpPost]
        public async Task<IActionResult> test()
        {
            var nunmber = int.Parse("dcfaedf");
            return StatusCode(StatusCodes.Status200OK, ResponseApiService.Response(StatusCodes.Status200OK, "{}", "Exitosa"));
        }
    }
}
