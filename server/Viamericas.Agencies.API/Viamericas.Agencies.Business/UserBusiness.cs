using System;
using Viamericas.Agencies.Business.Interfaces;
using Viamericas.Agencies.Data.Repositories.Interfaces;
using Viamericas.Agencies.Entity.Dto;

namespace Viamericas.Agencies.Business
{
    public class UserBusiness : IUserBusiness
    {
        #region Properties
        private readonly IUserRepository _repository;
        #endregion
        #region Constructor
        public UserBusiness(IUserRepository repository)
        {
            this._repository = repository;
        }
        #endregion
        #region Methods
        public bool ValidateUser(LoginModel userData)
        {
            return _repository.GetUserByLogin(userData) != null;
        }
        #endregion
    }
}