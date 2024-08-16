using mf_imports.DAL;
using mf_imports.DAL.Interfaces;
using mf_imports.DTO;
using mf_imports.Model;
using mf_imports.Services.Interfaces;

namespace mf_imports.Services;

public class VendaService : IVendaService
{
    private readonly IRepository<Venda> _vendaRepository;
    private readonly IEstoqueRepository _estoqueRepository;

    public VendaService(IRepository<Venda> vendaRepository, IEstoqueRepository estoqueRepository)
    {
        _vendaRepository = vendaRepository;
        _estoqueRepository = estoqueRepository;
    }

    public void RealizarVenda(VendaDTO venda)
    {
        Venda vendaStore = new Venda();
        vendaStore.ClienteId = venda.ClienteId;
        vendaStore.VendaProdutos = new List<VendaProdutos>();
        foreach (var item in venda.VendaProduto)
        {
            var estoque = _estoqueRepository.GetEstoqueByProduto(item.ProdutoId, item.EstoqueLocalId);
            if (estoque == null || estoque.Quantidade < item.QuantidadeProduto)
            {
                throw new InvalidOperationException("Estoque insuficiente.");
            }
            vendaStore.VendaProdutos.Add(new VendaProdutos()
            {
                ProdutoId = item.ProdutoId,
                QuantidadeProduto = item.QuantidadeProduto,
                Venda = vendaStore
            });
            estoque.Quantidade -= item.QuantidadeProduto;
            _estoqueRepository.Alter(estoque);
        }

        _vendaRepository.Add(vendaStore);
    }

    public IList<Venda> GetAll()
    {
        return _vendaRepository.GetAll();
    }
}