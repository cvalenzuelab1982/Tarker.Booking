namespace Tarker.Booking.Application.DataBase.Bookings.Querys.GetBookingsByType
{
    public interface IGetBookingsByTypeQuery
    {
        Task<List<GetBookingsByTypeModel>> Execute(string type);
    }
}
