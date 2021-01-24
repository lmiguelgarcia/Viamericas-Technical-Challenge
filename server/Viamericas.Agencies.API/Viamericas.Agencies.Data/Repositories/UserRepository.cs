using Viamericas.Agencies.Data.DBContext.Interface;
using Viamericas.Agencies.Data.Repositories.Interfaces;
using Viamericas.Agencies.Entity;
using System.Linq;
using Viamericas.Agencies.Entity.Dto;

namespace Viamericas.Agencies.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        #region Properties
        private readonly IViamericasContext _context;
        #endregion
        #region Constructor
        public UserRepository(IViamericasContext context)
        {
            _context = context;
        }
        #endregion
        #region Methods
        public User GetUserByLogin(LoginModel userData)
        {
            return _context.Set<User>().FirstOrDefault(i => i.Login.Equals(userData.UserName)
            && i.Password.Equals(userData.Password));
        }
        #endregion
    }
}