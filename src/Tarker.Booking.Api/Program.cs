using Tarker.Booking.Api;
using Tarker.Booking.Application;
using Tarker.Booking.Application.DataBase.Customer.Commands.DeleteCustomer;
using Tarker.Booking.Application.DataBase.Customer.Querys.GetAllCustomer;
using Tarker.Booking.Application.DataBase.Customer.Querys.GetCustomerByDocumentNumber;
using Tarker.Booking.Application.DataBase.Customer.Querys.GetCustomerById;
using Tarker.Booking.Common;
using Tarker.Booking.External;
using Tarker.Booking.Persistence;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddWebApi()
    .AddCommon()
    .AddApplication()
    .AddExternal(builder.Configuration)
    .AddPersistence(builder.Configuration);

var app = builder.Build();

app.MapGet("/testService", async (IGetCustomerByDocumentNumberQuery service) =>
{
    return await service.Execute("123456");
});

app.Run();
