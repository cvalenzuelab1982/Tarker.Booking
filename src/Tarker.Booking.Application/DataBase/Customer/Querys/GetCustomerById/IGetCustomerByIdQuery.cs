

namespace Tarker.Booking.Application.DataBase.Customer.Querys.GetCustomerById
{
    public interface IGetCustomerByIdQuery
    {
        Task<GetCustomerByIdModel> Execute(int customerId);
    }
}
