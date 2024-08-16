using mf_imports.DAL;
using mf_imports.DAL.Interfaces;
using mf_imports.Model;
using mf_imports.Services;
using mf_imports.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace mf_imports.Controllers;

[ApiController]
[Route("api/v1/Produto")]
public class ProdutoController : ControllerBase
{
    private IRepository<Produto> _produtoRepository;
    private ICalculoImpostoService _calculoImpostoService = new CalculoImpostoService();

    public ProdutoController(IRepository<Produto> produtoRepository)
    {
        _produtoRepository = produtoRepository;
    }

    [HttpPost]
    public IActionResult Add(Produto produto)
    {
        if (produto.PrecoVenda <= 0)
        {
            List<Produto> listaProdutos = new List<Produto>();
            listaProdutos.Add(produto);
            Orcamento orcamento = _calculoImpostoService.CalculoImposto(listaProdutos);
            produto.PrecoVenda = orcamento.ValorTotal + (orcamento.ValorTotal * .25m);
        }
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
        _produtoRepository.Alter(produto);
        return Ok();
    }

    [HttpDelete("id={id:int}")]
    public IActionResult Delete(int id)
    {
        var prod_remove = _produtoRepository.GetById(id);
        _produtoRepository.Delete(prod_remove);
        return Ok();
    }
}