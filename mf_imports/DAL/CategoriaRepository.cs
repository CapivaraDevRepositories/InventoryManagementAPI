using mf_imports.DAL.Interfaces;
using mf_imports.Model;
using Microsoft.EntityFrameworkCore;

namespace mf_imports.DAL;

public class CategoriaRepository : Repository<Categoria>  
{
    public CategoriaRepository(ConnectionContext context) : base(context) { }
    
    public override IList<Categoria> GetByName(string name)
    {
        return _context.Categorias.Where(c => c.Nome.ToLower().Contains(name)).ToList();
    }
}