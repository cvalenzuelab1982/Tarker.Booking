using Microsoft.EntityFrameworkCore;
using Tarker.Booking.Application.Database;

namespace Tarker.Booking.Application.DataBase.Bookings.Querys.GetBookingByDocumentNumber
{
    public class GetBookingByDocumentNumberQuery : IGetBookingByDocumentNumberQuery
    {
        private readonly IDataBaseService _dataBaseService;

        public GetBookingByDocumentNumberQuery(IDataBaseService dataBaseService)
        {
            _dataBaseService = dataBaseService;
        }

        public async Task<List<GetBookingByDocumentNumberModel>> Execute(string documentNumber)
        {
            var result = await (from b in _dataBaseService.Booking
                                join c in _dataBaseService.Customer
                                on b.CustomerId equals c.CustomerId
                                where c.DocumentNumber == documentNumber
                                select new GetBookingByDocumentNumberModel
                                {
                                    Code = b.Code,
                                    RegisterDate = b.RegisterDate,
                                    Type = b.Type
                                }).ToListAsync();

            return result;
        }
    }
}
