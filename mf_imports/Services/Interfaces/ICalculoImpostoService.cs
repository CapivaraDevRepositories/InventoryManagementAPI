using mf_imports.Model;

namespace mf_imports.Services.Interfaces;

public interface ICalculoImpostoService
{
    public Orcamento CalculoImposto(IList<Produto> listaProdutos);
}