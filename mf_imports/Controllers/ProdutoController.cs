using mf_imports.DAL;
using mf_imports.DAL.Interfaces;
using mf_imports.Model;
using Microsoft.AspNetCore.Mvc;

namespace mf_imports.Controllers;

[ApiController]
[Route("api/v1/Produto")]
public class ProdutoController : ControllerBase
{
    private IProdutoRepository _produtoRepository;

    public ProdutoController(IProdutoRepository produtoRepository)
    {
        _produtoRepository = produtoRepository;
    }

    [HttpPost]
    public IActionResult Add(Produto produto)
    {
        _produtoRepository.Add(produto);
        return Created();
    }
    
    [HttpGet]
    public IActionResult Get()
    {
        var produtos = _produtoRepository.GetAll();
        return Ok(produtos);
    }

    [HttpGet("id={id:int}")]
    public IActionResult Get(int id)
    {
        var produto = _produtoRepository.GetById(id);
        return Ok(produto);
    }

    [HttpGet("nome={nome}")]
    public IActionResult Get(string nome)
    {
        var produtos = _produtoRepository.GetByName(nome);
        return Ok(produtos);
    }

    [HttpPut]
    public IActionResult Update(Produto produto)
    {
        _produtoRepository.Update(produto);
        return Ok();
    }

    [HttpDelete("id={id:int}")]
    public IActionResult Delete(int id)
    {
        var prod_remove = _produtoRepository.GetById(id);
        _produtoRepository.Remove(prod_remove);
        return Ok();
    }
}