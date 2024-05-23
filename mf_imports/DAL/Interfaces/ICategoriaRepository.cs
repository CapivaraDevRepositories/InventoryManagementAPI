using mf_imports.Model;

namespace mf_imports.DAL.Interfaces;

public interface ICategoriaRepository
{
    void Add(Categoria categoria);
    List<Categoria?> GetAll();
    Categoria GetById(int id);
    Categoria? GetByName(string name);
    void Alter(Categoria categoria);
    void Delete(Categoria? categoria);
}