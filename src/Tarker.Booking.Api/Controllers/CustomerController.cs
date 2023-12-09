using Microsoft.AspNetCore.Mvc;
using Tarker.Booking.Application.DataBase.Bookings.Querys.GetBookingByDocumentNumber;
using Tarker.Booking.Application.DataBase.Customer.Commands.CreateCustomer;
using Tarker.Booking.Application.DataBase.Customer.Commands.DeleteCustomer;
using Tarker.Booking.Application.DataBase.Customer.Commands.UpdateCustomer;
using Tarker.Booking.Application.DataBase.Customer.Querys.GetAllCustomer;
using Tarker.Booking.Application.DataBase.Customer.Querys.GetCustomerByDocumentNumber;
using Tarker.Booking.Application.DataBase.Customer.Querys.GetCustomerById;
using Tarker.Booking.Application.DataBase.User.Commands.DeleteUser;
using Tarker.Booking.Application.DataBase.User.Querys.GetUSerById;
using Tarker.Booking.Application.DataBase.User.Querys.GetUserByUserNameAndPassword;
using Tarker.Booking.Application.Exceptions;
using Tarker.Booking.Application.Features;

namespace Tarker.Booking.Api.Controllers
{
    [Route("api/v1/customer")]
    [ApiController]
    [TypeFilter(typeof(ExceptionsManager))]
    public class CustomerController : ControllerBase
    {
        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody]CreateCustomerModel model, [FromServices]ICreateCustomerCommand createCustomerCommand)
        {
            var data = await createCustomerCommand.Execute(model);
            return StatusCode(StatusCodes.Status201Created, ResponseApiService.Response(StatusCodes.Status201Created, data, "Creado correctamente"));
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update([FromBody]UpdateCustomerModel model, [FromServices] IUpdateCustomerCommand updateCustomerCommand)
        {
           var data = await updateCustomerCommand.Execute(model);
            return StatusCode(StatusCodes.Status200OK, ResponseApiService.Response(StatusCodes.Status200OK, data, "Actualizado correctamente"));
        }

        [HttpDelete("delete/{customerId}")]
        public async Task<IActionResult> Delete(int customerId, [FromServices]IDeleteCustomerCommand deleteCustomerCommand)
        {
            if (customerId == 0)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ResponseApiService.Response(StatusCodes.Status400BadRequest, null, "Error en la solicitud"));
            }

            var data = await deleteCustomerCommand.Execute(customerId);

            if (!data)
            {
                return StatusCode(StatusCodes.Status404NotFound, ResponseApiService.Response(StatusCodes.Status404NotFound, null, "No encontrado"));
            }

            return StatusCode(StatusCodes.Status200OK, ResponseApiService.Response(StatusCodes.Status200OK, null, "Eliminado correctamente"));

        }

        [HttpGet("get-all")]
        public async Task<IActionResult> GetAll([FromServices] IGetAllCustomerQuery getAllCustomerQuery)
        {
            var data = await getAllCustomerQuery.Execute();

            if (data.Count == 0)
            {
                return StatusCode(StatusCodes.Status404NotFound, ResponseApiService.Response(StatusCodes.Status404NotFound, null, "No encontrado"));
            }

            return StatusCode(StatusCodes.Status200OK, ResponseApiService.Response(StatusCodes.Status200OK, data));

        }

        [HttpGet("get-by-id/{customerId}")]
        public async Task<IActionResult> GetById(int customerId, [FromServices] IGetCustomerByIdQuery getCustomerByIdQuery)
        {
            if (customerId == 0)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ResponseApiService.Response(StatusCodes.Status400BadRequest, null, "Error en la solicitud"));
            }

            var data = await getCustomerByIdQuery.Execute(customerId);

            if (data == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, ResponseApiService.Response(StatusCodes.Status404NotFound, null, "No encontrado"));
            }

            return StatusCode(StatusCodes.Status200OK, ResponseApiService.Response(StatusCodes.Status200OK, data));

        }

        [HttpGet("get-by-documentNumber/{documentNumber}")]
        public async Task<IActionResult> GetByDocumentoNumber(string documentNumber, [FromServices] IGetCustomerByDocumentNumberQuery getCustomerByDocumentNumberQuery)
        {

            if (string.IsNullOrEmpty(documentNumber))
            {
                return StatusCode(StatusCodes.Status400BadRequest, ResponseApiService.Response(StatusCodes.Status400BadRequest, null, "Error en la solicitud"));
            }

            var data = await getCustomerByDocumentNumberQuery.Execute(documentNumber);

            if (data == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, ResponseApiService.Response(StatusCodes.Status404NotFound, null, "No encontrado"));
            }

            return StatusCode(StatusCodes.Status200OK, ResponseApiService.Response(StatusCodes.Status200OK, data));

        }
    }
}
