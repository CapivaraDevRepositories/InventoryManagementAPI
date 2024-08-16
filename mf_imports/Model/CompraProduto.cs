namespace mf_imports.Model;

public class CompraProduto
{
    public int Id { get; set; }
    public int IdProduto { get; set; }
    public Produto Produto { get; set; }
    public decimal Quantidade { get; set; }
    public int NumeroNF { get; set; }
    public int SerieNF { get; set; }
    public DateTime DataCompra { get; set; }
    public string Usuario { get; set; }
}
