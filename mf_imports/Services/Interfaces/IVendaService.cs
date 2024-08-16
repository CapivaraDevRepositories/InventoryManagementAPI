using mf_imports.Model;

namespace mf_imports.Services.Interfaces;

public interface IVendaService
{
    public void RealizarVenda(Venda venda);
    
    public IList<Venda> GetAll();
}