using mf_imports.Controllers;
using mf_imports.Model;
using mf_imports.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace UnitTests.Controllers;

[Trait("Category", "OrcamentoController")]
public class OrcamentoControllerTest
{
    private readonly Mock<ICalculoImpostoService> _mockCalculoImpostoService;
    private readonly OrcamentoController _controller;

    public OrcamentoControllerTest()
    {
        _mockCalculoImpostoService = new Mock<ICalculoImpostoService>();
        _controller = new OrcamentoController(_mockCalculoImpostoService.Object);
    }

    [Fact]
    public void GerarOrcamento_ShouldReturnBadRequest_WhenListaProdutosIsEmpty()
    {
        // Arrange
        var emptyListaProdutos = new List<Produto>();

        // Act
        var result = _controller.GerarOrcamento(emptyListaProdutos);

        // Assert
        var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
        Assert.Equal("A lista de produtos não pode estar vazia.", badRequestResult.Value);
    }

    [Fact]
    public void GerarOrcamento_ShouldReturnBadRequest_WhenListaProdutosIsNull()
    {
        // Arrange
        List<Produto> nullListaProdutos = null;

        // Act
        var result = _controller.GerarOrcamento(nullListaProdutos);

        // Assert
        var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
        Assert.Equal("A lista de produtos não pode estar vazia.", badRequestResult.Value);
    }

    [Fact]
    public void GerarOrcamento_ShouldReturnOk_WhenListaProdutosIsValid()
    {
        // Arrange
        var validListaProdutos = new List<Produto> { new Produto() };
        var expectedOrcamento = new Orcamento();
        _mockCalculoImpostoService.Setup(service => service.CalculoImposto(validListaProdutos)).Returns(expectedOrcamento);

        // Act
        var result = _controller.GerarOrcamento(validListaProdutos);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        Assert.Equal(expectedOrcamento, okResult.Value);
    }
}