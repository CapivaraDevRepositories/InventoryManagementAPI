using mf_imports.DAL;
using mf_imports.DAL.Interfaces;
using mf_imports.Model;
using Microsoft.AspNetCore.Mvc;

namespace mf_imports.Controllers;

[ApiController]
[Route("api/v1/conector")]
public class ConectorController : ControllerBase
{
    private IRepository<Conector> _conectorRepository;

    public ConectorController(IRepository<Conector> conectorRepository)
    {
        _conectorRepository = conectorRepository;
    }

    /// <returns>A IActionResult object representing the HTTP response.</returns>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IActionResult GetAllConectors()
    {
        var conectors = _conectorRepository.GetAll();
        return Ok(conectors);
    }

    /// <summary>
    /// Retrieves a Conector by its ID.
    /// </summary>
    /// <param name="id">The ID of the Conector.</param>
    /// <returns>An IActionResult object representing the HTTP response. Returns the Conector with the specified ID if found, or NotFound if not found.</returns>
    [HttpGet("id={id:int}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult GetById(int id)
    {
        var conector = _conectorRepository.GetById(id);
        if (conector == null)
            return NotFound();
        return Ok(conector);
    }

    /// <summary>
    /// Removes a Conector from the repository by its ID.
    /// </summary>
    /// <param name="id">The ID of the Conector to be removed.</param>
    /// <returns>An IActionResult object representing the HTTP response. Returns Ok if the Conector was removed successfully, or NotFound if the Conector with the specified ID does not exist.</returns>
    [HttpDelete("id={id:int}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult Remove(int id)
    {
        var conector = _conectorRepository.GetById(id);
        if (null == conector)
        {
            return NotFound();
        }

        _conectorRepository.Delete(conector);
        return Ok();
    }

    /// <summary>
    /// Adds a new Conector to the repository.
    /// </summary>
    /// <param name="conector">The Conector object to be added.</param>
    /// <returns>An IActionResult object representing the HTTP response.</returns>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public IActionResult Add(Conector conector)
    {
        _conectorRepository.Add(conector);
        return Created();
    }

    /// <summary>
    /// Updates the information of a Conector in the repository.
    /// </summary>
    /// <param name="conector">The updated Conector object.</param>
    /// <returns>An IActionResult object representing the HTTP response.</returns>
    [HttpPut]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IActionResult Update(Conector conector)
    {
        // if (null == _conectorRepository.GetById(conector.Id))
        // {
        //     return NotFound();
        // }
        _conectorRepository.Alter(conector);
        return Ok();
    }

    /// <summary>
    /// Retrieves a list of Conectors with the specified name.
    /// </summary>
    /// <param name="name">The name of the Conectors to retrieve.</param>
    /// <returns>An IActionResult object representing the HTTP response. Returns the list of Conectors with the specified name if found, or NotFound if none are found.</returns>
    [HttpGet("nome={nome}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IActionResult GetByName(string nome)
    {
        var conectors = _conectorRepository.GetByName(nome);
        return Ok(conectors);
    }
}