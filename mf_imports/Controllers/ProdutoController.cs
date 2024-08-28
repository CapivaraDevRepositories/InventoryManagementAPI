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

    /// <summary>
    /// Adds a new product to the repository.
    /// If the product's selling price is less than or equal to 0, the method calculates the selling price based on the product's cost and adds import taxes and a percentage as a profit margin before storing it in the repository.
    /// </summary>
    /// <param name="produto">The product to be added.</param>
    /// <returns>An <see cref="IActionResult"/> representing the HTTP response after adding the product.</returns>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
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

    /// <summary>
    /// Retrieves all products from the repository.
    /// </summary>
    /// <returns>An <see cref="IActionResult"/> representing the HTTP response with the list of products.</returns>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IActionResult Get()
    {
        var produtos = _produtoRepository.GetAll();
        return Ok(produtos);
    }

    /// <summary>
    /// Retrieves a product from the repository based on its ID.
    /// </summary>
    /// <param name="id">The ID of the product to retrieve.</param>
    /// <returns>An <see cref="IActionResult"/> representing the HTTP response with the product.</returns>
    [HttpGet("id={id:int}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IActionResult Get(int id)
    {
        var produto = _produtoRepository.GetById(id);
        return Ok(produto);
    }

    /// <summary>
    /// Retrieves all products from the repository.
    /// </summary>
    /// <returns>An IActionResult representing the HTTP response with the list of products.</returns>
    [HttpGet("nome={nome}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IActionResult Get(string nome)
    {
        var produtos = _produtoRepository.GetByName(nome);
        return Ok(produtos);
    }

    /// <summary>
    /// Updates an existing product in the repository.
    /// </summary>
    /// <param name="produto">The updated product.</param>
    /// <returns>An <see cref="IActionResult"/> representing the HTTP response after updating the product.</returns>
    [HttpPut]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IActionResult Update(Produto produto)
    {
        _produtoRepository.Alter(produto);
        return Ok();
    }

    /// <summary>
    /// Deletes a product from the repository based on its ID.
    /// </summary>
    /// <param name="id">The ID of the product to be deleted.</param>
    /// <returns>An <see cref="IActionResult"/> representing the HTTP response after deleting the product.</returns>
    [HttpDelete("id={id:int}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IActionResult Delete(int id)
    {
        var prod_remove = _produtoRepository.GetById(id);
        _produtoRepository.Delete(prod_remove);
        return Ok();
    }
}