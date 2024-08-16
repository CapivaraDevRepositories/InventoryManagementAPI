using mf_imports.Model;

namespace mf_imports.DAL;

public class EstoqueLocalRepository : Repository<EstoqueLocal>
{
    public EstoqueLocalRepository(ConnectionContext context) : base(context) { }

    public override IList<EstoqueLocal> GetByName(string name)
    {
        return _context.Set<EstoqueLocal>().Where(e => e.Nome.ToLower().Contains(name.ToLower())).ToList();
    }
}