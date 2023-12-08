using Microsoft.EntityFrameworkCore;
using Tarker.Booking.Application.Database;

namespace Tarker.Booking.Application.DataBase.Bookings.Querys.GetBookingsByType
{
    public class GetBookingsByTypeQuery : IGetBookingsByTypeQuery
    {
        private readonly IDataBaseService _dataBaseService;

        public GetBookingsByTypeQuery(IDataBaseService dataBaseService)
        {
            _dataBaseService = dataBaseService;
        }

        public async Task<List<GetBookingsByTypeModel>> Execute(string type)
        {
            var result = await (from b in _dataBaseService.Booking
                                join c in _dataBaseService.Customer
                                on b.CustomerId equals c.CustomerId
                                where b.Type == type
                                select new GetBookingsByTypeModel
                                {
                                    Code = b.Code,
                                    RegisterDate = b.RegisterDate,
                                    Type = b.Type,
                                    CustomerFullName = c.FullName,
                                    CustomerDocumentNumber = c.DocumentNumber,
                                }).ToListAsync();
            return result;
        }
    }
}
