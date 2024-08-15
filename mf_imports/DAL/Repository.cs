using mf_imports.DAL.Interfaces;

namespace mf_imports.DAL;

public class Repository<T> : IRepository<T> where T : class
{
    protected readonly ConnectionContext _context;

    public Repository(ConnectionContext context)
    {
        _context = context;
    }

    public void Add(T entity)
    {
        _context.Set<T>().Add(entity);
        _context.SaveChanges();
    }

    public IList<T> GetAll()
    {
        return _context.Set<T>().ToList();
    }

    public T GetById(int id)
    {
        return _context.Set<T>().Find(id);
    }

    public IList<T> GetByName(string name)
    {
        throw new NotImplementedException();
    }

    public void Alter(T entity)
    {
        _context.Set<T>().Update(entity);
        _context.SaveChanges();
    }

    public void Delete(T? entity)
    {
        _context.Set<T>().Remove(entity);
        _context.SaveChanges();
    }
}