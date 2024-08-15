namespace mf_imports.Model;

public class VendaProduto
{
    public int VendaId { get; set; }
    public Venda Venda { get; set; }

    public int ProdutoId { get; set; }
    public Produto Produto { get; set; }

    public decimal QuantidadeProduto { get; set; }
}
