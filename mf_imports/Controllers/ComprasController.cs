using mf_imports.Model;
using mf_imports.DTO;
using mf_imports.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace mf_imports.Controllers;

[ApiController]
[Route("api/v1/compras")]
public class ComprasController : ControllerBase
{
    private readonly ICompraProdutoService _compraProdutoService;

    public ComprasController(ICompraProdutoService compraProdutoService)
    {
        _compraProdutoService = compraProdutoService;
    }

    [HttpPost]
    public IActionResult RegistrarCompra([FromBody] IList<ProdutoCompraDTO> compraProduto)
    {
        try
        {
            _compraProdutoService.RegistrarCompra(compraProduto);
            return Ok("Compra registrada com sucesso.");
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet]
    public IActionResult GetCompras()
    {
        try
        {
            List<CompraProduto> comprasRealizadas = _compraProdutoService.GetCompraProdutos();
            return Ok(comprasRealizadas);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}
