using mf_imports.Model;
using Microsoft.EntityFrameworkCore;

namespace mf_imports.DAL;

public class VendasRepository : Repository<Venda>
{
    public VendasRepository(ConnectionContext context) : base(context) { }

    public override IList<Venda> GetAll()
    {
        return _context.Set<Venda>()
            .Include(venda => venda.VendaProdutos)
            .Include(venda => venda.Cliente)
            .ToList();
    }

    public override Venda GetById(int id)
    {
        return base.GetById(id);
    }
}