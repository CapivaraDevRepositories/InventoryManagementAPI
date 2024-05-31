using mf_imports.DAL;
using mf_imports.DAL.Interfaces;
using mf_imports.Model;
using Microsoft.AspNetCore.Mvc;

namespace mf_imports.Controllers;

[ApiController]
[Route("api/v1/unidadeMedida")]
public class UnidadeMedidaController : ControllerBase
{
    private readonly IUnidadeMedidaRepository _unidadeMedidaRepository;

    public UnidadeMedidaController(IUnidadeMedidaRepository unidadeMedidaRepository)
    {
        _unidadeMedidaRepository = unidadeMedidaRepository;
    }

    [HttpGet]
    public ActionResult Get()
    {
        return Ok(_unidadeMedidaRepository.GetAll());
    }
    
    [HttpGet("id={id:int}")]
    public ActionResult Get(int id)
    {
        var unidadeMedida = _unidadeMedidaRepository.GetById(id);
        if (unidadeMedida == null)
        {
            return NotFound();
        }

        return Ok(unidadeMedida);
    }
    
    [HttpPost]
    public ActionResult Add(UnidadeMedida unidadeMedida)
    {
        _unidadeMedidaRepository.Add(unidadeMedida);
        return Ok();
    }
    
    [HttpPut]
    public ActionResult Update(UnidadeMedida unidadeMedida)
    {
        _unidadeMedidaRepository.Alter(unidadeMedida);
        return Ok();
    }
    
    [HttpDelete("id={id:int}")]
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
    
    [HttpGet("nome={nome}")]
    public ActionResult GetByName(string nome)
    {
        var unidadeMedida = _unidadeMedidaRepository.GetByName(nome);
        if (unidadeMedida == null)
        {
            return NotFound();
        }
        return Ok(unidadeMedida);
    }
    
}