namespace mf_imports.Model;

public class VendaProdutos
{
    public int Id { get; set; }
    public int VendaId { get; set; }
    public Venda Venda { get; set; }

    public int ProdutoId { get; set; }
    public Produto Produto { get; set; }

    public decimal QuantidadeProduto { get; set; }
}
