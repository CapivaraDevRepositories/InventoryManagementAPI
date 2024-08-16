using mf_imports.Model;

namespace mf_imports.DAL;

public class ClienteRepository: Repository<Cliente>
{
    public ClienteRepository(ConnectionContext context) : base(context) { }

    public override IList<Cliente> GetByName(string name)
    {
        return _context.Set<Cliente>().Where(cliente => cliente.Nome.ToLower().Contains(name.ToLower())).ToList();
    }
}