
namespace Tarker.Booking.Application.DataBase.User.Querys.GetAllUser
{
    public interface IGetAllUserQuery
    {
        Task<List<GetAllUserModel>> Execute();
    }
}
