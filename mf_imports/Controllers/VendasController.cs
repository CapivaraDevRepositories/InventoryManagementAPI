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

    /// <summary>
    /// Creates a new venda.
    /// </summary>
    /// <param name="venda">The VendaDTO object representing the venda to be created.</param>
    /// <returns>An IActionResult representing the HTTP response status code and, if successful, the created venda.</returns>
    /// <remarks>
    /// This method expects a VendaDTO object as input, which represents the venda to be created.
    /// The venda object should contain information such as the clienteId and a list of vendaProdutos.
    /// The method returns an IActionResult, which indicates the HTTP response status code.
    /// If the venda is created successfully, the method returns a status code 201 (Created) along with the created venda.
    /// If an error occurs during the creation process, the method returns a status code 400 (Bad Request) along with an error message.
    /// </remarks>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public IActionResult Post(VendaDTO venda)
    {
        try
        {
            _vendaService.RealizarVenda(venda);
            return Created();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    /// <summary>
    /// Retrieves all vendas.
    /// </summary>
    /// <returns>An IActionResult representing the HTTP response status code and, if successful, a list of vendas.</returns>
    /// <remarks>
    /// This method returns an IActionResult, which indicates the HTTP response status code.
    /// If the retrieval is successful, the method returns a status code 200 (OK) along with a list of vendas.
    /// </remarks>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IActionResult Get()
    {
        return Ok(_vendaService.GetAll());
    }
}
