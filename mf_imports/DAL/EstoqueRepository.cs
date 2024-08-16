using mf_imports.DAL.Interfaces;
using mf_imports.Model;

namespace mf_imports.DAL;

public class EstoqueRepository : Repository<Estoque>, IEstoqueRepository
{
    public EstoqueRepository(ConnectionContext context) : base(context) { }

    public Estoque? GetEstoqueByProduto(int produtoId, int estoqueLocalId)
    {
        return _context.Set<Estoque>().FirstOrDefault(estoque => (estoque.ProdutoId == produtoId) && (estoque.EstoqueLocalId == estoqueLocalId));
    }
}