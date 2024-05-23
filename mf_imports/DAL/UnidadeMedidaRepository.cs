using mf_imports.DAL.Interfaces;
using mf_imports.Model;

namespace mf_imports.DAL;

public class UnidadeMedidaRepository : IUnidadeMedida
{
    private ConnectionContext _context = new ConnectionContext();
    
    public void Add(UnidadeMedida unidadeMedida)
    {
        _context.UnidadeMedidas.Add(unidadeMedida);
    }

    public List<UnidadeMedida> GetAll()
    {
        return _context.UnidadeMedidas.ToList();
    }

    public UnidadeMedida GetById(int id)
    {
        return _context.UnidadeMedidas.FirstOrDefault(um => um.Id == id);
    }

    public UnidadeMedida GetByName(string name)
    {
        return _context.UnidadeMedidas.FirstOrDefault(um => um.Nome.Equals(name));
    }

    public void Alter(UnidadeMedida unidadeMedida)
    {
        _context.UnidadeMedidas.Update(unidadeMedida);
        _context.SaveChanges();
    }

    public void Delete(UnidadeMedida unidadeMedida)
    {
        _context.Remove(unidadeMedida);
        _context.SaveChanges();
    }
}