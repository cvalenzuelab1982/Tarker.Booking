using Microsoft.AspNetCore.Mvc;
using Tarker.Booking.Application.DataBase.Bookings.Commands.CreateBooking;
using Tarker.Booking.Application.DataBase.Bookings.Querys.GetAllBookings;
using Tarker.Booking.Application.DataBase.Bookings.Querys.GetBookingByDocumentNumber;
using Tarker.Booking.Application.DataBase.Bookings.Querys.GetBookingsByType;
using Tarker.Booking.Application.DataBase.Customer.Commands.CreateCustomer;
using Tarker.Booking.Application.DataBase.Customer.Querys.GetAllCustomer;
using Tarker.Booking.Application.DataBase.Customer.Querys.GetCustomerByDocumentNumber;
using Tarker.Booking.Application.Exceptions;
using Tarker.Booking.Application.Features;

namespace Tarker.Booking.Api.Controllers
{
    [Route("api/v1/booking")]
    [ApiController]
    [TypeFilter(typeof(ExceptionsManager))]
    public class BookingController : ControllerBase
    {
        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] CreateBookingModel model, [FromServices] ICreateBookingCommand createBookingCommand)
        {
            var data = await createBookingCommand.Execute(model);
            return StatusCode(StatusCodes.Status201Created, ResponseApiService.Response(StatusCodes.Status201Created, data, "Creado correctamente"));
        }

        [HttpGet("get-all")]
        public async Task<IActionResult> GetAll([FromServices] IGetAllBookingsQuery getAllBookingsQuery)
        {
            var data = await getAllBookingsQuery.Execute();

            if (data.Count == 0)
            {
                return StatusCode(StatusCodes.Status404NotFound, ResponseApiService.Response(StatusCodes.Status404NotFound, null, "No encontrado"));
            }

            return StatusCode(StatusCodes.Status200OK, ResponseApiService.Response(StatusCodes.Status200OK, data));

        }

        [HttpGet("get-by-documentNumber")]
        public async Task<IActionResult> GetByDocumentoNumber([FromQuery] string documentNumber, [FromServices] IGetBookingByDocumentNumberQuery getBookingByDocumentNumberQuery)
        {

            if (string.IsNullOrEmpty(documentNumber))
            {
                return StatusCode(StatusCodes.Status400BadRequest, ResponseApiService.Response(StatusCodes.Status400BadRequest, null, "Error en la solicitud"));
            }

            var data = await getBookingByDocumentNumberQuery.Execute(documentNumber);

            if (data.Count == 0)
            {
                return StatusCode(StatusCodes.Status404NotFound, ResponseApiService.Response(StatusCodes.Status404NotFound, null, "No encontrado"));
            }

            return StatusCode(StatusCodes.Status200OK, ResponseApiService.Response(StatusCodes.Status200OK, data));

        }

        [HttpGet("get-by-type")]
        public async Task<IActionResult> GetByType([FromQuery] string type, [FromServices] IGetBookingsByTypeQuery getBookingsByTypeQuery)
        {

            if (string.IsNullOrEmpty(type))
            {
                return StatusCode(StatusCodes.Status400BadRequest, ResponseApiService.Response(StatusCodes.Status400BadRequest, null, "Error en la solicitud"));
            }

            var data = await getBookingsByTypeQuery.Execute(type);

            if (data.Count == 0)
            {
                return StatusCode(StatusCodes.Status404NotFound, ResponseApiService.Response(StatusCodes.Status404NotFound, null, "No encontrado"));
            }

            return StatusCode(StatusCodes.Status200OK, ResponseApiService.Response(StatusCodes.Status200OK, data));

        }
    }
}
