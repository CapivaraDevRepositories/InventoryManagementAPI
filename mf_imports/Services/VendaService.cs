using mf_imports.DAL.Interfaces;
using mf_imports.Model;
using mf_imports.Services.Interfaces;

namespace mf_imports.Services;

public class VendaService : IVendaService
{
    private readonly IRepository<Venda> _vendaRepository;
    private readonly IRepository<Estoque> _estoqueRepository;

    public VendaService(IRepository<Venda> vendaRepository, IRepository<Estoque> estoqueRepository)
    {
        _vendaRepository = vendaRepository;
        _estoqueRepository = estoqueRepository;
    }

    public void RealizarVenda(Venda venda)
    {
        foreach (var item in venda.VendaProdutos)
        {
            var estoque = _estoqueRepository.GetById(item.ProdutoId);
            if (estoque == null || estoque.Quantidade < item.QuantidadeProduto)
            {
                throw new InvalidOperationException("Estoque insuficiente.");
            }

            estoque.Quantidade -= item.QuantidadeProduto;
            _estoqueRepository.Alter(estoque);
        }
        _vendaRepository.Add(venda);
    }
}