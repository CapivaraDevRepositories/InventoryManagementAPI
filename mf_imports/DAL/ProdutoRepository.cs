using mf_imports.DAL.Interfaces;
using mf_imports.Model;

namespace mf_imports.DAL;

public class ProdutoRepository : Repository<Produto>
{
    public ProdutoRepository(ConnectionContext context) : base(context) { }

    public override IList<Produto> GetByName(string name)
    {
        return _context.Produtos.Where(p => p.Nome.ToLower().Contains(name.ToLower())).ToList();
    }
}