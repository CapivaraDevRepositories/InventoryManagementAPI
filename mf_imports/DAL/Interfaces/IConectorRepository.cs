using mf_imports.Model;

namespace mf_imports.DAL.Interfaces;

public interface IConectorRepository
{
    void Add(Conector conector);
    IList<Conector> GetAll();
    Conector GetById(int id);
    IList<Conector> GetByName(string name);
    void Update(Conector conector);
    void Remove(Conector conector);
}