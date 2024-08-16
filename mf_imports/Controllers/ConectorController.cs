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

    [HttpGet]
    public IActionResult GetAllConectors()
    {
        var conectors = _conectorRepository.GetAll();
        return Ok(conectors);
    }
    
    [HttpGet("id={id:int}")]
    public IActionResult GetById(int id)
    {
        var conector = _conectorRepository.GetById(id);
        if (conector == null)
            return NotFound();
        return Ok(conector);
    }
    
    [HttpDelete("id={id:int}")]
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
    
    [HttpPost]
    public IActionResult Add(Conector conector)
    {
        _conectorRepository.Add(conector);
        return Created();
    }
    
    [HttpPut]
    public IActionResult Update(Conector conector)
    {
        // if (null == _conectorRepository.GetById(conector.Id))
        // {
        //     return NotFound();
        // }
        _conectorRepository.Alter(conector);
        return Ok();
    }
    
    [HttpGet("nome={nome}")]
    public IActionResult GetByName(string nome)
    {
        var conectors = _conectorRepository.GetByName(nome);
        return Ok(conectors);
    }
}