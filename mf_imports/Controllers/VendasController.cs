using mf_imports.Model;
using mf_imports.Services;
using Microsoft.AspNetCore.Mvc;

namespace mf_imports.Controllers;

[ApiController]
[Route("api/v1/vendas")]
public class VendasController : ControllerBase
{
    private readonly VendaService _vendaService;

    public VendasController(VendaService vendaService)
    {
        _vendaService = vendaService;
    }

    [HttpPost]
    public IActionResult Post(Venda venda)
    {
        try
        {
            _vendaService.RealizarVenda(venda);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
