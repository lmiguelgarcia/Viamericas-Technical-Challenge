using System.Collections.Generic;
using Viamericas.Agencies.Entity;

namespace Viamericas.Agencies.Data.Repositories.Interfaces
{
    public interface IAgencyRepository
    {
        List<string> GetAllCities();
        List<Agency> GetAllAgencies();
        List<Agency> GetAllAgenciesByCity(string city);
    }
}