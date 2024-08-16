using mf_imports.DAL.Interfaces;
using mf_imports.Model;

namespace mf_imports.DAL;

public class ConectorRepository : Repository<Conector>
{
    public ConectorRepository(IConnectionContext context) : base(context){ }

    public new IList<Conector> GetByName(string name)
    {
        return _context.Conectores.Where(c => c.Nome.ToLower().Contains(name.ToLower())).ToList();
    }
}