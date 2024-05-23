using mf_imports.Model;

namespace mf_imports.DAL.Interfaces;

public interface IUnidadeMedida
{
    void Add(UnidadeMedida unidadeMedida);
    List<UnidadeMedida> GetAll();
    UnidadeMedida GetById(int id);
    UnidadeMedida GetByName(string name);
    void Alter(UnidadeMedida unidadeMedida);
    void Delete(UnidadeMedida unidadeMedida);
}