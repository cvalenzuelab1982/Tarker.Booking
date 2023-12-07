

namespace Tarker.Booking.Application.DataBase.Customer.Querys.GetAllCustomer
{
    public interface IGetAllCustomerQuery
    {
        Task<List<GetAllCustomerModel>> Execute();
    }
}
