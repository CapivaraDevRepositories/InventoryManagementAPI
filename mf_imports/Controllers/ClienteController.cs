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

    /// <summary>
    /// Retrieves all clients from the repository.
    /// </summary>
    /// <returns>An ActionResult containing a list of all clients.</returns>
    [HttpGet]
    [ProducesResponseType<int>(StatusCodes.Status200OK)]
    public ActionResult Get()
    {
        return Ok(_clienteRepository.GetAll());
    }

    /// <summary>
    /// Retrieves a client by their ID.
    /// </summary>
    /// <param name="id">The ID of the client to retrieve.</param>
    /// <returns>An ActionResult containing the client if found, or NotFound if not found.</returns>
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

    /// <summary>
    /// Adds a new client to the repository.
    /// </summary>
    /// <param name="cliente">The client object to add.</param>
    /// <returns>An ActionResult containing the created client if successful, or BadRequest if the client object is null.</returns>
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

    /// <summary>
    /// Updates a client in the repository.
    /// </summary>
    /// <param name="cliente">The client to be updated.</param>
    /// <returns>An ActionResult indicating the update was successful (200 OK) or the client was not found (404 Not Found).</returns>
    [HttpPut]
    [ProducesResponseType<int>(StatusCodes.Status200OK)]
    [ProducesResponseType<int>(StatusCodes.Status404NotFound)]
    public ActionResult Update(Cliente cliente)
    {
        _clienteRepository.Alter(cliente);
        return Ok();
    }

    /// <summary>
    /// Deletes a client from the repository based on their ID.
    /// </summary>
    /// <param name="id">The ID of the client to be deleted.</param>
    /// <returns>An ActionResult representing the success of the operation. Returns NotFound if the client is not found in the repository, and Ok if the client is successfully deleted.</returns>
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

    /// <summary>
    /// Retrieves a list of clients from the repository that match the given name.
    /// </summary>
    /// <param name="nome">The name of the clients to retrieve.</param>
    /// <returns>An ActionResult containing a list of clients that match the given name.</returns>
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