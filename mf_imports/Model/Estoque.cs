namespace mf_imports.Model;

public class Estoque
{
    public int Id { get; set; }
    public int ProdutoId { get; set; }
    public Produto Produto { get; set; }

    public int EstoqueLocalId { get; set; }
    public EstoqueLocal EstoqueLocal { get; set; }

    public decimal Quantidade { get; set; }
}
