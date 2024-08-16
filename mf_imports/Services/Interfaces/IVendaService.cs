using mf_imports.Model;
using mf_imports.DTO;

namespace mf_imports.Services.Interfaces;

public interface IVendaService
{
    public void RealizarVenda(VendaDTO venda);
    
    public IList<Venda> GetAll();
}