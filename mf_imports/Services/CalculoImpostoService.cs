using mf_imports.Model;
using mf_imports.Services.Interfaces;

namespace mf_imports.Services;

public class CalculoImpostoService : ICalculoImpostoService
{
    private const decimal AliquitaICMS = .17m;
    private const decimal DescontoPRC = 20m;
    // TODO: Alterar para ser retornado a partir de CotacaoService.ObterCotacaoDolarAsync()
    private const decimal TaxaCambio = 5.5m; 
    private const decimal ImpostoAte50Dolares = .2M;
    private const decimal ImpostoAcima50Dolares = .6m;

    public Orcamento CalculoImposto(IList<Produto> listaProdutos)
    {
        decimal valorProdutos = listaProdutos.Sum(produto => produto.PrecoCompra);
        decimal valorFrete = listaProdutos.Sum(produto => produto.Frete);
        decimal valorSeguro = listaProdutos.Sum(produto => produto.Seguro);
        
        decimal valorAduaneiro = valorProdutos + valorFrete + valorSeguro;
        
        decimal impostoImportacao = CalcularImpostoImportacao(listaProdutos, valorAduaneiro);
        decimal icms = CalcularICMS(valorProdutos, valorFrete, valorSeguro, impostoImportacao);
        
        decimal valorTotal = valorAduaneiro + impostoImportacao + icms;

        return new Orcamento
        {
            ValorAduaneiro = valorAduaneiro,
            ImpostoImportacao = impostoImportacao,
            ICMS = icms,
            ValorTotal = valorTotal
        };
    }

    private decimal CalcularImpostoImportacao(IList<Produto> listaProdutos, decimal valorAduaneiro)
    {
        decimal impostoImportacao = 0;
        foreach (var produto in listaProdutos)
        {
            if (produto.Certificado == 'S')
            {
                impostoImportacao += (50 > produto.PrecoCompra) ? (valorAduaneiro * ImpostoAte50Dolares) : ((valorAduaneiro * ImpostoAcima50Dolares) - (DescontoPRC * TaxaCambio));
            }
            else
            {
                impostoImportacao += valorAduaneiro * ImpostoAcima50Dolares;
            }
        }
        return impostoImportacao;
    }

    private decimal CalcularICMS(decimal valorProdutos, decimal valorFrete, decimal valorSeguro,
        decimal impostoImportacao)
    {
        decimal baseCalculoICMS = (valorProdutos + valorFrete + valorSeguro + impostoImportacao) / (1 - AliquitaICMS);
        return baseCalculoICMS * AliquitaICMS;
    }
}