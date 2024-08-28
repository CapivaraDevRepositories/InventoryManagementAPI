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

    /// <summary>
    /// Generates an orcamento (budget) based on the provided list of produtos (products).
    /// The orcamento includes calculations for ValorAduaneiro (customs value), ImpostoImportacao (import tax),
    /// ICMS (state tax) and ValorTotal (total value).
    /// </summary>
    /// <param name="listaProdutos">The list of produtos to generate the orcamento from.</param>
    /// <returns>An Orcamento object containing the calculated values.</returns>
    [HttpPost]
    [Route("gerar")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
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