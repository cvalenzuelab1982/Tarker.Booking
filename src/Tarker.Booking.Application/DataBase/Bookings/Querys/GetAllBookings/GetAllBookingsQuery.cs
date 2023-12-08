using Microsoft.EntityFrameworkCore;
using Tarker.Booking.Application.Database;

namespace Tarker.Booking.Application.DataBase.Bookings.Querys.GetAllBookings
{
    public class GetAllBookingsQuery : IGetAllBookingsQuery
    {
        private readonly IDataBaseService _dataBaseService;

        public GetAllBookingsQuery(IDataBaseService dataBaseService)
        {
            _dataBaseService = dataBaseService;
        }

        public async Task<List<GetAllBookingsModel>> Execute()
        {
            var result = await (from b in _dataBaseService.Booking
                                join c in _dataBaseService.Customer
                                on b.CustomerId equals c.CustomerId
                                select new GetAllBookingsModel
                                {
                                    BookingId = b.BookingId,
                                    Code = b.Code,
                                    RegisterDate = b.RegisterDate,
                                    Type = b.Type,
                                    CustomerFullName = c.FullName,
                                    CustomerDocumentNumber = c.DocumentNumber
                                }).ToListAsync();
            return result;
        }
    }
}
