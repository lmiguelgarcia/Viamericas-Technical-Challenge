using System.Collections.Generic;
using Viamericas.Agencies.Business.Interfaces;
using Viamericas.Agencies.Data.Repositories.Interfaces;
using Viamericas.Agencies.Entity;

namespace Viamericas.Agencies.Business
{
    public class AgencyBusiness : IAgencyBusiness
    {
        #region Properties
        private readonly IAgencyRepository _repository;
        #endregion
        #region Constructor
        public AgencyBusiness(IAgencyRepository repository)
        {
            this._repository = repository;
        }
        #endregion
        #region Methods
        public List<Agency> GetAllAgenciesByCity(string city)
        {
            if (string.IsNullOrEmpty(city))
                return _repository.GetAllAgencies();
            else
                return _repository.GetAllAgenciesByCity(city);
        }

        public List<string> GetAllCities()
        {
            return _repository.GetAllCities();
        }
        #endregion
    }
}