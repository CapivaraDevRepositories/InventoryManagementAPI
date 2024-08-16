using mf_imports.Model;
using Microsoft.EntityFrameworkCore;

namespace mf_imports.DAL;

public class CompraProdutoRepository : Repository<CompraProduto>
{
    public CompraProdutoRepository(ConnectionContext context) : base(context) { }

    public override IList<CompraProduto> GetAll()
    {
        return _context.Set<CompraProduto>().Include(compraProduto => compraProduto.Produto).ToList();
    }

    public override CompraProduto GetById(int id)
    {
        return _context.Set<CompraProduto>().Include(compraProduto => compraProduto.Produto).FirstOrDefault(compraProduto => compraProduto.Id == id);
    }

    public override IList<CompraProduto> GetByName(string name)
    {
        return _context.Set<CompraProduto>().Include(compraProduto => compraProduto).Where(compraProduto => compraProduto.Produto.Nome.ToLower().Contains(name.ToLower())).ToList();
    }
}