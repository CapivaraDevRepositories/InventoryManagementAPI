namespace mf_imports.Model;

public class Produto
{
    public int Id { get; set; }
    public string? Nome { get; set; }
    public string? Descricao { get; set; }
    public Categoria Categoria { get; set; }
    public Conector? Conector { get; set; }
    public UnidadeMedida UnidadeMedida { get; set; }
    public decimal PrecoCompra { get; set; }
    public decimal PrecoVenda { get; set; }
    public IList<string> OpcoesCompra { get; set; }
}