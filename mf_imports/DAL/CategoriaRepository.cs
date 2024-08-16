using mf_imports.DAL.Interfaces;
using mf_imports.Model;
using Microsoft.EntityFrameworkCore;

namespace mf_imports.DAL;

public class CategoriaRepository : Repository<Categoria>  
{
    public CategoriaRepository(IConnectionContext context) : base(context) { }
    
    public new IList<Categoria> GetByName(string name)
    {
        return _context.Categorias.Where(c => c.Nome.ToLower().Contains(name)).ToList();
    }
}