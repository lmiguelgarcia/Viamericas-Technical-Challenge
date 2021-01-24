using Microsoft.EntityFrameworkCore;
using Viamericas.Agencies.Data.DBContext.Interface;
using Viamericas.Agencies.Entity;

namespace Viamericas.Agencies.Data.DBContext
{
    public class ViamericasContext : DbContext, IViamericasContext
    {
        #region Properties
        public DbSet<Agency> Agencies { get; set; }
        public DbSet<User> Users { get; set; }
        #endregion
        #region Constructor
        public ViamericasContext(DbContextOptions<ViamericasContext> options) : base(options)
        {
        }
        #endregion
    }
}