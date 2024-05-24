using mf_imports.DAL;
using mf_imports.DAL.Interfaces;
using mf_imports.Model;
using Microsoft.AspNetCore.Mvc;

namespace mf_imports.Controllers;

[ApiController]
[Route("api/v1/Categoria")]
public class CategoriaController : ControllerBase
{
    private readonly ICategoriaRepository _categoriaRepository = new CategoriaRepository();

    [HttpPost]
    public IActionResult Add(Categoria categoria)
    {
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
        return Ok(categoria);
    }

    [HttpGet("nome={nome}")]
    public IActionResult Get(string nome)
    {
        var categoria = _categoriaRepository.GetByName(nome);
        return Ok(categoria);
    }

    [HttpDelete("id={id:int}")]
    public IActionResult Delete(int id)
    {
        var categoria = _categoriaRepository.GetById(id);
        _categoriaRepository.Delete(categoria);
        return Ok();
    }

    [HttpPut]
    public IActionResult Update(Categoria categoria)
    {
        _categoriaRepository.Alter(categoria);
        return Ok();
    }
}