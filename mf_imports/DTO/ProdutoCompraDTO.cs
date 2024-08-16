namespace mf_imports.DTO;

public class ProdutoCompraDTO
{
    public int ProdutoId { get; set; }
    public decimal Quantidade { get; set; }
    public int NumeroNF { get; set; }
    public int SerieNF { get; set; }
    public DateTime DataCompra { get; set; }
    public string Usuario { get; set; }
    public int IdEstoqueLocalDestino { get; set; }
}