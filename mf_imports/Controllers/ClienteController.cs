using mf_imports.DAL.Interfaces;
using mf_imports.Model;
using Microsoft.AspNetCore.Mvc;

namespace mf_imports.Controllers;

[ApiController]
[Route("api/v1/cliente")]
public class ClienteController : ControllerBase
{
    private readonly IRepository<Cliente> _clienteRepository;

    public ClienteController(IRepository<Cliente> clienteRepository)
    {
        _clienteRepository = clienteRepository;
    }

    [HttpGet]
    [ProducesResponseType<int>(StatusCodes.Status200OK)]
    public ActionResult Get()
    {
        return Ok(_clienteRepository.GetAll());
    }

    [HttpGet("id={id:int}")]
    [ProducesResponseType<int>(StatusCodes.Status200OK)]
    [ProducesResponseType<int>(StatusCodes.Status404NotFound)]
    public ActionResult Get(int id)
    {
        var cliente = _clienteRepository.GetById(id);
        if (cliente == null)
            return NotFound();
        return Ok(cliente);
    }

    [HttpPost]
    [ProducesResponseType<int>(StatusCodes.Status201Created)]
    [ProducesResponseType<int>(StatusCodes.Status400BadRequest)]
    public ActionResult Post(Cliente cliente)
    {
        if (cliente == null)
        {
            return BadRequest("Cliente object is null");
        }

        _clienteRepository.Add(cliente);
        return CreatedAtAction(nameof(Get), new { id = cliente.Id }, cliente);
    }

    [HttpPut]
    [ProducesResponseType<int>(StatusCodes.Status200OK)]
    [ProducesResponseType<int>(StatusCodes.Status404NotFound)]
    public ActionResult Update(Cliente cliente)
    {
        _clienteRepository.Alter(cliente);
        return Ok();
    }

    [HttpDelete("id={id:int}")]
    [ProducesResponseType<int>(StatusCodes.Status200OK)]
    [ProducesResponseType<int>(StatusCodes.Status404NotFound)]
    public ActionResult Delete(int id)
    {
        var cliente = _clienteRepository.GetById(id);
        if (cliente == null)
        {
            return NotFound();
        }
        _clienteRepository.Delete(cliente);
        return Ok();
    }

    [HttpGet("nome={nome}")]
    [ProducesResponseType<string>(StatusCodes.Status200OK)]
    [ProducesResponseType<string>(StatusCodes.Status404NotFound)]
    public ActionResult GetByName(string nome)
    {
        var clientes = _clienteRepository.GetByName(nome);
        if (clientes == null || !clientes.Any())
        {
            return NotFound();
        }
        return Ok(clientes);
    }
}