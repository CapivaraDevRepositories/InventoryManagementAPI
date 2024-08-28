using mf_imports.DAL;
using mf_imports.DAL.Interfaces;
using mf_imports.Model;
using Microsoft.AspNetCore.Mvc;

namespace mf_imports.Controllers;

[ApiController]
[Route("api/v1/unidadeMedida")]
public class UnidadeMedidaController : ControllerBase
{
    private readonly IRepository<UnidadeMedida> _unidadeMedidaRepository;

    public UnidadeMedidaController(IRepository<UnidadeMedida> unidadeMedidaRepository)
    {
        _unidadeMedidaRepository = unidadeMedidaRepository;
    }

    /// <summary>
    /// Retrieves all UnidadeMedida objects from the repository.
    /// </summary>
    /// <returns>All UnidadeMedida objects in the repository.</returns>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public ActionResult Get()
    {
        return Ok(_unidadeMedidaRepository.GetAll());
    }

    /// <summary>
    /// Retrieves all UnidadeMedida objects from the repository.
    /// </summary>
    /// <returns>All UnidadeMedida objects in the repository.</returns>
    [HttpGet("id={id:int}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult Get(int id)
    {
        var unidadeMedida = _unidadeMedidaRepository.GetById(id);
        if (unidadeMedida == null)
        {
            return NotFound();
        }

        return Ok(unidadeMedida);
    }

    /// <summary>
    /// Adds a new UnidadeMedida object to the repository.
    /// </summary>
    /// <param name="unidadeMedida">The UnidadeMedida object to add to the repository.</param>
    /// <returns>A HTTP status code indicating the success or failure of the operation.</returns>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public ActionResult Add(UnidadeMedida unidadeMedida)
    {
        _unidadeMedidaRepository.Add(unidadeMedida);
        return Created();
    }

    /// <summary>
    /// Updates an existing UnidadeMedida object in the repository.
    /// </summary>
    /// <param name="unidadeMedida">The UnidadeMedida object to update.</param>
    /// <returns>A HTTP status code indicating the success or failure of the operation.</returns>
    [HttpPut]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public ActionResult Update(UnidadeMedida unidadeMedida)
    {
        _unidadeMedidaRepository.Alter(unidadeMedida);
        return Ok();
    }

    /// <summary>
    /// Deletes an existing UnidadeMedida object from the repository.
    /// </summary>
    /// <param name="id">The ID of the UnidadeMedida object to delete.</param>
    /// <returns>A HTTP status code indicating the success or failure of the operation.</returns>
    [HttpDelete("id={id:int}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult Delete(int id)
    {
        var unidadeMedida = _unidadeMedidaRepository.GetById(id);
        if (unidadeMedida == null)
        {
            return NotFound();
        }
        _unidadeMedidaRepository.Delete(unidadeMedida);
        return Ok();
    }

    /// <summary>
    /// Retrieves an UnidadeMedida object from the repository by name.
    /// </summary>
    /// <param name="nome">The name of the UnidadeMedida object to retrieve.</param>
    /// <returns>The UnidadeMedida object with the specified name, or null if not found.</returns>
    [HttpGet("nome={nome}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult GetByName(string nome)
    {
        var unidadeMedida = _unidadeMedidaRepository.GetByName(nome);
        if ((unidadeMedida == null) || (! unidadeMedida.Any()))
        {
            return NotFound();
        }
        return Ok(unidadeMedida);
    }
    
}
