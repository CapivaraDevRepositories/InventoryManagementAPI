using mf_imports.Model;

namespace mf_imports.DAL.Interfaces;

public interface IEstoqueRepository : IRepository<Estoque>
{
    public Estoque? GetEstoqueByProduto(int produtoId, int estoqueLocalId);
}