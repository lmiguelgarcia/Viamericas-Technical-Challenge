using Viamericas.Agencies.Entity;
using Viamericas.Agencies.Entity.Dto;

namespace Viamericas.Agencies.Data.Repositories.Interfaces
{
    public interface IUserRepository
    {
        User GetUserByLogin(LoginModel userData);
    }
}