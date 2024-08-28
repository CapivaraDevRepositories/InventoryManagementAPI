using mf_imports.Controllers;
using mf_imports.DAL.Interfaces;
using mf_imports.Model;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace UnitTests.Controllers;

[Trait("Category","ProdutoController")]
public class ProdutoControllerTest
{
    private readonly ProdutoController _controller;
    private readonly Mock<IRepository<Produto>> _mockRepository;
    private readonly Produto _produto;

    public ProdutoControllerTest()
    {
        _mockRepository = new Mock<IRepository<Produto>>();
        _controller = new ProdutoController(_mockRepository.Object);
        _produto = new Produto();
    }

    [Fact]
    public void AddTest_ValidProduto_AddedToRepository()
    {
        _controller.Add(_produto);
        _mockRepository.Verify(r => r.Add(_produto), Times.Once);
    }

    [Fact]
    public void GetAllTest_ReturnsAllProdutos()
    {
        var list = new List<Produto>() { new Produto(), new Produto() };
        _mockRepository.Setup(r => r.GetAll()).Returns(list);

        var result = _controller.Get();

        Assert.IsType<OkObjectResult>(result);
    }

    [Fact]
    public void GetByIdTest_ReturnsCorrectProduto()
    {
        _mockRepository.Setup(r => r.GetById(1)).Returns(_produto);

        var result = _controller.Get(1);

        Assert.IsType<OkObjectResult>(result);
    }

    [Fact]
    public void GetByNameTest_ReturnsCorrectProdutos()
    {
        var list = new List<Produto>() { new Produto() { Nome = "Test" }, new Produto() { Nome = "Test" } };
        _mockRepository.Setup(r => r.GetByName("Test")).Returns(list);

        var result = _controller.Get("Test");

        Assert.IsType<OkObjectResult>(result);
    }

    [Fact]
    public void UpdateTest_ValidProduto_UpdateRepository()
    {
        _controller.Update(_produto);
        _mockRepository.Verify(r => r.Alter(_produto), Times.Once);
    }

    [Fact]
    public void DeleteTest_ValidProduto_DeleteRepository()
    {
        _produto.Id = 1;
        _mockRepository.Setup(r => r.GetById(1)).Returns(_produto);

        _controller.Delete(1);
        _mockRepository.Verify(r => r.Delete(_produto), Times.Once);
    }
}