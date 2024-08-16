using mf_imports.DAL.Interfaces;
using mf_imports.Model;
using Microsoft.AspNetCore.Mvc;

namespace mf_imports.Controllers;

[Route("api/v1/cliente")]
public class ClienteController : ControllerBase
{
    private readonly IRepository<Cliente> _clienteRepository;

    public ClienteController(IRepository<Cliente> clienteRepository)
    {
        _clienteRepository = clienteRepository;
    }

    [HttpGet]
    public ActionResult Get()
    {
        return Ok(_clienteRepository.GetAll());
    }

    [HttpGet("id={id:int}")]
    public ActionResult Get(int id)
    {
        var cliente = _clienteRepository.GetById(id);
        if (cliente == null)
            return NotFound();
        return Ok(cliente);
    }

    [HttpPost]
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
    public ActionResult Update(Cliente cliente)
    {
        _clienteRepository.Alter(cliente);
        return Ok();
    }

    [HttpDelete("id={id:int}")]
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