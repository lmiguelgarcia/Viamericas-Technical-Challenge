using Microsoft.EntityFrameworkCore;
using System;

namespace Viamericas.Agencies.Data.DBContext.Interface
{
    public interface IViamericasContext : IDisposable
    {
        DbSet<TEntity> Set<TEntity>() where TEntity : class;
    }
}
