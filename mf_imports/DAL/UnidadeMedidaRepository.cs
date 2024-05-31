using mf_imports.DAL.Interfaces;
using mf_imports.Model;

namespace mf_imports.DAL;

public class UnidadeMedidaRepository : IUnidadeMedidaRepository
{
    private readonly ConnectionContext _context;

    public UnidadeMedidaRepository(ConnectionContext context)
    {
        _context = context;
    }

    public void Add(UnidadeMedida unidadeMedida)
    {
        _context.UnidadeMedidas.Add(unidadeMedida);
        _context.SaveChanges();
    }

    public IList<UnidadeMedida> GetAll()
    {
        return _context.UnidadeMedidas.ToList();
    }

    public UnidadeMedida GetById(int id)
    {
        return _context.UnidadeMedidas.FirstOrDefault(um => um.Id == id);
    }

    public IList<UnidadeMedida> GetByName(string name)
    {
        return _context.UnidadeMedidas.Where(um => um.Nome.ToLower().Contains(name.ToLower())).ToList();
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