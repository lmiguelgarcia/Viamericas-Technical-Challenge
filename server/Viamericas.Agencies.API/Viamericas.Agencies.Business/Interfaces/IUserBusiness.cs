using Viamericas.Agencies.Entity.Dto;

namespace Viamericas.Agencies.Business.Interfaces
{
    public interface IUserBusiness
    {
        bool ValidateUser(LoginModel userData);
    }
}