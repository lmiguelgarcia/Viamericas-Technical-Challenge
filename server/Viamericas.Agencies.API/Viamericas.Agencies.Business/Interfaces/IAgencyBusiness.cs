using System.Collections.Generic;
using Viamericas.Agencies.Entity;

namespace Viamericas.Agencies.Business.Interfaces
{
    public interface IAgencyBusiness
    {
        List<string> GetAllCities();
        List<Agency> GetAllAgenciesByCity(string city);
    }
}