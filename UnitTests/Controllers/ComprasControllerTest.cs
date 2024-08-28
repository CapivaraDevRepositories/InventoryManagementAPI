using Moq;
using mf_imports.Services.Interfaces;
using mf_imports.DTO;
using mf_imports.Model;
using Microsoft.AspNetCore.Mvc;
using mf_imports.Controllers;

namespace UnitTests.Controllers;

[Trait("Category", "ComprasController")]
public class ComprasControllerTest
{
    private readonly ComprasController _controller;
    private readonly Mock<ICompraProdutoService> _mockService;

    public ComprasControllerTest()
    {
        _mockService = new Mock<ICompraProdutoService>();
        _controller = new ComprasController(_mockService.Object);
    }

    [Fact]
    public void RegistrarCompra_ReturnsOkResult_WhenPurchaseIsSuccessful()
    {
        // Arrange
        var compraProdutoList = new List<ProdutoCompraDTO>
        {
            new ProdutoCompraDTO { ProdutoId = 1, Quantidade = 10, NumeroNF = 123, SerieNF = 456, DataCompra = DateTime.Now, Usuario = "testuser", IdEstoqueLocalDestino = 1}
        };

        // Act
        var result = _controller.RegistrarCompra(compraProdutoList);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        Assert.Equal("Compra registrada com sucesso.", okResult.Value);
    }

    [Fact]
    public void RegistrarCompra_ReturnsBadRequest_WhenExceptionIsThrown()
    {
        // Arrange
        var compraProdutoList = new List<ProdutoCompraDTO>();
        _mockService.Setup(service => service.RegistrarCompra(compraProdutoList)).Throws(new Exception("Test exception"));

        // Act
        var result = _controller.RegistrarCompra(compraProdutoList);

        // Assert
        var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
        Assert.Equal("Test exception", badRequestResult.Value);
    }

    [Fact]
    public void GetCompras_ReturnsOkResult_WithListOfCompraProduto()
    {
        // Arrange
        var comprasList = new List<CompraProduto>
        {
            new CompraProduto { Id = 1, IdProduto = 1, Quantidade = 10, NumeroNF = 123, SerieNF = 456, DataCompra = DateTime.Now, Usuario = "testuser" }
        };
        _mockService.Setup(service => service.GetCompraProdutos()).Returns(comprasList);

        // Act
        var result = _controller.GetCompras();

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        var returnValue = Assert.IsType<List<CompraProduto>>(okResult.Value);
        Assert.Equal(1, returnValue.Count);
    }

    [Fact]
    public void GetCompras_ReturnsBadRequest_WhenExceptionIsThrown()
    {
        // Arrange
        _mockService.Setup(service => service.GetCompraProdutos()).Throws(new Exception("Test exception"));

        // Act
        var result = _controller.GetCompras();

        // Assert
        var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
        Assert.Equal("Test exception", badRequestResult.Value);
    }
}