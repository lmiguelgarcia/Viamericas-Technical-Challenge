using System.Collections.Generic;
using Viamericas.Agencies.Data.DBContext.Interface;
using Viamericas.Agencies.Data.Repositories.Interfaces;
using Viamericas.Agencies.Entity;
using System.Linq;

namespace Viamericas.Agencies.Data.Repositories
{
    public class AgencyRepository : IAgencyRepository
    {
        #region Properties
        private readonly IViamericasContext _context;
        #endregion
        #region Constructor
        public AgencyRepository(IViamericasContext context)
        {
            _context = context;
        }
        #endregion
        #region Methods
        public List<Agency> GetAllAgencies()
        {
            return _context.Set<Agency>()
                .ToList();
        }

        public List<Agency> GetAllAgenciesByCity(string city)
        {
            return _context.Set<Agency>()
                .Where(i => i.City.Equals(city))
                .ToList();
        }

        public List<string> GetAllCities()
        {
            return _context.Set<Agency>()
                .Select(x => x.City).Distinct().ToList();
        }
        #endregion
    }
}
