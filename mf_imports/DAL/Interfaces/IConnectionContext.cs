using Microsoft.EntityFrameworkCore;

namespace mf_imports.DAL.Interfaces;

public interface IConnectionContext
{
    DbSet<T> Set<T>() where T : class;
    int SaveChanges();
    TEntity Find<TEntity>(params object[] keyValues) where TEntity : class;
    void Remove<TEntity>(TEntity entity) where TEntity : class;
    void Update<TEntity>(TEntity entity) where TEntity : class;
    void Add<TEntity>(TEntity entity) where TEntity : class;
}