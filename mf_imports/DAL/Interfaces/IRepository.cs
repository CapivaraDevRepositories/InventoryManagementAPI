using mf_imports.Model;

namespace mf_imports.DAL.Interfaces;

public interface IRepository<T> where T : class
{
    void Add(T entity);
    IList<T> GetAll();
    T GetById(int id);
    IList<T> GetByName(string name);
    void Alter(T entity);
    void Delete(T? entity);
}