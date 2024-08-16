namespace mf_imports.DTO;

public class VendaDTO
{
    public int ClienteId { get; set; }
    public IList<VendaProdutoDTO> VendaProduto { get; set; }
}