using mf_imports.Model;

namespace mf_imports.DAL.Interfaces;

public interface IConectorRepository
{
    void Add(Conector conector);
    List<Conector> GetAll();
    Conector GetById(int id);
    Conector GetByName(string name);
    void Alter(Conector conector);
    void Delete(Conector conector);
}