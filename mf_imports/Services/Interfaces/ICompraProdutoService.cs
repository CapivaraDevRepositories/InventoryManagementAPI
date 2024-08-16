using mf_imports.DTO;
using mf_imports.Model;

namespace mf_imports.Services.Interfaces;

public interface ICompraProdutoService
{
    public void RegistrarCompra(IList<ProdutoCompraDTO> compraProdutoDTO);
    public List<CompraProduto> GetCompraProdutos();
}