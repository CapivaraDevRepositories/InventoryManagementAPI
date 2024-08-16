using System.Data;
using mf_imports.DAL.Interfaces;
using mf_imports.DTO;
using mf_imports.Model;
using mf_imports.Services.Interfaces;

namespace mf_imports.Services;

public class CompraProdutoService : ICompraProdutoService
{
    private readonly IRepository<Estoque> _estoqueRepository;
    private readonly IRepository<EstoqueMovimenta> _estoqueMovimentaRepository;
    private readonly IRepository<Produto> _produtoRepository;
    private readonly IRepository<EstoqueLocal> _estoqueLocalRepository;
    static private int COMPRA_EstoqueLocal = -1;  

    public CompraProdutoService(IRepository<Estoque> estoqueRepository, IRepository<EstoqueMovimenta> estoqueMovimentaRepository, IRepository<Produto> produtoRepository, IRepository<EstoqueLocal> estoqueLocalRepository)
    {
        _estoqueRepository = estoqueRepository;
        _estoqueMovimentaRepository = estoqueMovimentaRepository;
        _produtoRepository = produtoRepository;
        _estoqueLocalRepository = estoqueLocalRepository;
        
        if (0 >= COMPRA_EstoqueLocal)
            COMPRA_EstoqueLocal = _estoqueLocalRepository.GetByName("Compra").FirstOrDefault().Id;
    }

    public void RegistrarCompra(IList<ProdutoCompraDTO> compraProdutoDTO)
    {
        foreach (ProdutoCompraDTO produtoDTO in compraProdutoDTO)
        {
            Produto produto = _produtoRepository.GetById(produtoDTO.ProdutoId);
            if (null == produto)
            {
                throw new Exception($"Produto (Código: {produtoDTO.ProdutoId}) não encontrado no cadastro.");
            }

            EstoqueLocal EstoqueLocalDestino = _estoqueLocalRepository.GetById(produtoDTO.IdEstoqueLocalDestino);
            if (null == EstoqueLocalDestino)
            {
                throw new Exception($"Local de destino (Código: {produtoDTO.IdEstoqueLocalDestino}) no estoque não cadastrado.");
            }

            if (0 >= produtoDTO.Quantidade)
            {
                throw new Exception($"Não é permitido adicionar ({produtoDTO.Quantidade}) ao Estoque.");
            }
                
            RegistrarMovimentacaoEstoque(produtoDTO);
            AdicionarProdutoAoEstoque(produto, COMPRA_EstoqueLocal, produtoDTO.Quantidade);
        }
    }

    public List<CompraProduto> GetCompraProdutos()
    {
        List<CompraProduto> compraProdutos = new List<CompraProduto>();
        IList<EstoqueMovimenta> movimentacoes = _estoqueMovimentaRepository.GetAll()
            .Where(movimentacao => movimentacao.IdEstoqueLocalOrigem == COMPRA_EstoqueLocal).ToList();
        foreach (var movimentacao in movimentacoes)
        {
            compraProdutos.Add(new CompraProduto
            {
                Usuario = movimentacao.Usuario,
                Id = movimentacao.Id,
                Quantidade = movimentacao.Quantidade,
                IdProduto = movimentacao.IdProduto,
                NumeroNF = movimentacao.NumeroNF,
                SerieNF = movimentacao.SerieNF,
                DataCompra = movimentacao.DataHora
            });
        }
        return compraProdutos;
    }

    private void RegistrarMovimentacaoEstoque(ProdutoCompraDTO produtoDTO)
    {
        var movimentacao = new EstoqueMovimenta
        {
            IdEstoqueLocalOrigem = COMPRA_EstoqueLocal,
            IdEstoqueLocalDestino = produtoDTO.IdEstoqueLocalDestino,
            IdProduto = produtoDTO.ProdutoId,
            NumeroNF = produtoDTO.NumeroNF,
            SerieNF = produtoDTO.SerieNF,
            Quantidade = produtoDTO.Quantidade,
            DataHora = DateTime.UtcNow,
            Usuario = produtoDTO.Usuario
        };
        _estoqueMovimentaRepository.Add(movimentacao);
    }

    private void AdicionarProdutoAoEstoque(Produto produto, int COMPRA_EstoqueLocal, decimal quantidade)
    {
        _estoqueRepository.Add(new Estoque
        {
            ProdutoId = produto.Id, 
            Quantidade = quantidade, 
            EstoqueLocalId = COMPRA_EstoqueLocal,
        });
    }
}
