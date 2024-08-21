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

    [HttpPost]
    public IActionResult Add(Categoria categoria)
    {
        if (null == categoria)
        {
            return BadRequest("Objeto fornecido não pode ser nulo ou vazio.");
        }
        _categoriaRepository.Add(categoria);
        return Created();
    }

    [HttpGet]
    public IActionResult Get()
    {
        var categorias = _categoriaRepository.GetAll();
        return Ok(categorias);
    }

    [HttpGet("id={id:int}")]
    public IActionResult Get(int id)
    {
        var categoria = _categoriaRepository.GetById(id);
        if (null == categoria)
        {
            return NotFound();
        }
        return Ok(categoria);
    }

    [HttpGet("nome={nome}")]
    public IActionResult Get(string nome)
    {
        var categoria = _categoriaRepository.GetByName(nome);
        if (null == categoria)
        {
            return NotFound();
        }
        return Ok(categoria);
    }

    [HttpDelete("id={id:int}")]
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

    [HttpPut]
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