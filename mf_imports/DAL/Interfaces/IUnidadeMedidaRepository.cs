using mf_imports.Model;

namespace mf_imports.DAL.Interfaces;

public interface IUnidadeMedidaRepository
{
    void Add(UnidadeMedida unidadeMedida);
    IList<UnidadeMedida> GetAll();
    UnidadeMedida GetById(int id);
    IList<UnidadeMedida> GetByName(string name);
    void Alter(UnidadeMedida unidadeMedida);
    void Delete(UnidadeMedida unidadeMedida);
}