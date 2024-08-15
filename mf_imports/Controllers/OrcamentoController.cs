using mf_imports.Model;
using mf_imports.Services;
using mf_imports.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace mf_imports.Controllers;

[ApiController]
[Route("api/v1/orcamento")]
public class OrcamentoController : ControllerBase
{
    private readonly ICalculoImpostoService _calculoImpostoService;

    public OrcamentoController(ICalculoImpostoService calculoImpostoService)
    {
        _calculoImpostoService = calculoImpostoService;
    }

    [HttpPost]
    [Route("gerar")]
    public IActionResult GerarOrcamento([FromBody] List<Produto> listaProdutos)
    {
        if (null == listaProdutos || !listaProdutos.Any())
        {
            return BadRequest("A lista de produtos não pode estar vazia.");
        }
        var orcamento = _calculoImpostoService.CalculoImposto(listaProdutos);
        return Ok(orcamento);
    }
    
}