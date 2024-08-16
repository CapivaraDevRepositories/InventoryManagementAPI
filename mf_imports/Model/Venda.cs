namespace mf_imports.Model;

public class Venda
{
    public int Id { get; set; }
    public int ClienteId { get; set; }
    public Cliente Cliente { get; set; }
    public ICollection<VendaProdutos> VendaProdutos { get; set; }
}