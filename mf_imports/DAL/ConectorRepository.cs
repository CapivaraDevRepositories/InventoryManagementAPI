using mf_imports.DAL.Interfaces;
using mf_imports.Model;

namespace mf_imports.DAL;

public class ConectorRepository : Repository<Conector>
{
    public ConectorRepository(ConnectionContext context) : base(context){ }

    public override IList<Conector> GetByName(string name)
    {
        return _context.Conectores.Where(c => c.Nome.ToLower().Contains(name.ToLower())).ToList();
    }
}