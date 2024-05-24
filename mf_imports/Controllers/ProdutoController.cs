using mf_imports.DAL;
using mf_imports.DAL.Interfaces;
using mf_imports.Model;
using Microsoft.AspNetCore.Mvc;

namespace mf_imports.Controllers;

[ApiController]
[Route("api/v1/Produto")]
public class ProdutoController : ControllerBase
{
    private IProdutoRepository _produtoRepository = new ProdutoRepository();

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
}