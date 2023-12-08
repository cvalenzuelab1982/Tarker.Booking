namespace Tarker.Booking.Application.DataBase.Bookings.Querys.GetAllBookings
{
    public interface IGetAllBookingsQuery
    {
        Task<List<GetAllBookingsModel>> Execute();
    }
}
