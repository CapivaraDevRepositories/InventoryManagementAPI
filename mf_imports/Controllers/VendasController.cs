using mf_imports.DTO;
using mf_imports.Model;
using mf_imports.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace mf_imports.Controllers;

[ApiController]
[Route("api/v1/vendas")]
public class VendasController : ControllerBase
{
    private readonly IVendaService _vendaService;

    public VendasController(IVendaService vendaService)
    {
        _vendaService = vendaService;
    }

    [HttpPost]
    public IActionResult Post(VendaDTO venda)
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

    [HttpGet]
    public IActionResult Get()
    {
        return Ok(_vendaService.GetAll());
    }
}
