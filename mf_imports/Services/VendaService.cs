using mf_imports.Model;

namespace mf_imports.Services;

public class VendaService
{
    private readonly IVendaRepository _vendaRepository;
    private readonly IEstoqueRepository _estoqueRepository;

    public VendaService(IVendaRepository vendaRepository, IEstoqueRepository estoqueRepository)
    {
        _vendaRepository = vendaRepository;
        _estoqueRepository = estoqueRepository;
    }

    public Task RealizarVendaAsync(Venda venda)
    {
        foreach (var item in venda.VendaProdutos)
        {
            var estoque = _estoqueRepository.GetByIdAsync(item.ProdutoId);
            if (estoque == null || estoque.Quantidade < item.QuantidadeProduto)
            {
                throw new InvalidOperationException("Estoque insuficiente.");
            }

            estoque.Quantidade -= item.QuantidadeProduto;
            _estoqueRepository.Update(estoque);
        }

        _vendaRepository.AddAsync(venda);
    }
}