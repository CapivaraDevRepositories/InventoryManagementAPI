using mf_imports.DAL;
using mf_imports.DAL.Interfaces;
using mf_imports.Model;
using Microsoft.AspNetCore.Mvc;

namespace mf_imports.Controllers;

[ApiController]
[Route("api/v1/Categoria")]
public class CategoriaController : ControllerBase
{
    private readonly IRepository<Categoria> _categoriaRepository;
    
    public CategoriaController(IRepository<Categoria> categoriaRepository)
    {
        _categoriaRepository = categoriaRepository;
    }

    /// <summary>
    /// Adds a new Categoria object to the repository.
    /// </summary>
    /// <param name="categoria">The Categoria object to be added.</param>
    /// <returns>An IActionResult representing the HTTP response.</returns>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult Add(Categoria categoria)
    {
        if (null == categoria)
        {
            return BadRequest("Objeto fornecido não pode ser nulo ou vazio.");
        }
        _categoriaRepository.Add(categoria);
        return Created();
    }

    /// <summary>
    /// Retrieves all categories from the database.
    /// </summary>
    /// <returns>An IActionResult representing the status of the request.</returns>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IActionResult Get()
    {
        var categorias = _categoriaRepository.GetAll();
        return Ok(categorias);
    }

    /// <summary>
    /// Retrieves all categories from the database.
    /// </summary>
    /// <returns>An IActionResult representing the status of the request.</returns>
    [HttpGet("id={id:int}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult Get(int id)
    {
        var categoria = _categoriaRepository.GetById(id);
        if (null == categoria)
        {
            return NotFound();
        }
        return Ok(categoria);
    }

    /// <summary>
    /// Retrieves all categories from the database.
    /// </summary>
    /// <returns>An IActionResult representing the status of the request.</returns>
    [HttpGet("nome={nome}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult Get(string nome)
    {
        var categoria = _categoriaRepository.GetByName(nome);
        if (null == categoria)
        {
            return NotFound();
        }
        return Ok(categoria);
    }

    /// <summary>
    /// Deletes a Categoria object from the repository by its id.
    /// </summary>
    /// <param name="id">The id of the Categoria object to be deleted.</param>
    /// <returns>An IActionResult representing the status of the request.</returns>
    [HttpDelete("id={id:int}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult Delete(int id)
    {
        var categoria = _categoriaRepository.GetById(id);
        if (null == categoria)
        {
            return NotFound("Id informado não encotrado ou vazio.");
        }
        _categoriaRepository.Delete(categoria);
        return Ok();
    }

    /// <summary>
    /// Updates a Categoria object in the repository.
    /// </summary>
    /// <param name="categoria">The Categoria object to update. Cannot be null.</param>
    /// <returns>An IActionResult representing the result of the update operation. Returns BadRequestObjectResult if categoria is null, or OkResult if the update operation is successful.</returns>
    [HttpPut]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult Update(Categoria categoria)
    {
        if (null == categoria)
        {
            return BadRequest("Objeto fornecido não pode ser nulo ou vazio.");
        }
        _categoriaRepository.Alter(categoria);
        return Ok();
    }
}