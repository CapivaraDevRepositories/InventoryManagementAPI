using mf_imports.Controllers;
using mf_imports.DAL.Interfaces;
using mf_imports.Model;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace UnitTests.Controllers;

[Trait("Category", "ClienteController")]
public class ClienteControllerTest
{
    private readonly Mock<IRepository<Cliente>> _mockRepository;
    private readonly ClienteController _controller;

    public ClienteControllerTest()
    {
        _mockRepository = new Mock<IRepository<Cliente>>();
        _controller = new ClienteController(_mockRepository.Object);
    }

    [Fact]
    public void Get_WhenCalled_ReturnsAllItems()
    {
        _mockRepository.Setup(repo => repo.GetAll()).Returns(GetClientes());

        var result = _controller.Get();

        var okResult = Assert.IsType<OkObjectResult>(result);
        var returnValue = Assert.IsType<List<Cliente>>(okResult.Value);
        Assert.Equal(2, returnValue.Count);
    }

    [Fact]
    public void GetById_InvalidIdPassed_ReturnsNotFoundResult()
    {
        Cliente? returns = null;
        _mockRepository.Setup(repo => repo.GetById(0)).Returns(returns!);

        var result = _controller.Get(0);

        Assert.IsType<NotFoundResult>(result);
    }

    [Fact]
    public void GetById_ValidIdPassed_ReturnsOkResult()
    {
        var expectedCliente = GetClientes()[0];
        _mockRepository.Setup(repo => repo.GetById(1)).Returns(expectedCliente);

        var result = _controller.Get(1);

        var okResult = Assert.IsType<OkObjectResult>(result);
        var returnValue = Assert.IsType<Cliente>(okResult.Value);
        Assert.Equal(expectedCliente.Id, returnValue.Id);
    }

    [Fact]
    public void Add_ValidObjectPassed_ReturnsCreatedResponse()
    {
        var newCliente = new Cliente { Id = 3, Nome = "John Doe" };

        var result = _controller.Post(newCliente);

        var createdResult = Assert.IsType<CreatedAtActionResult>(result);
        var returnValue = Assert.IsType<Cliente>(createdResult.Value);
        Assert.Equal(newCliente.Id, returnValue.Id);
    }

    [Fact]
    public void Add_NullObjectPassed_ReturnsBadRequest()
    {
        var result = _controller.Post(null!);

        Assert.IsType<BadRequestObjectResult>(result);
    }

    [Fact]
    public void Update_ValidObjectPassed_ReturnsOkResult()
    {
        var clienteToUpdate = GetClientes()[0];
        _mockRepository.Setup(repo => repo.GetById(clienteToUpdate.Id)).Returns(clienteToUpdate);

        var result = _controller.Update(clienteToUpdate);

        Assert.IsType<OkResult>(result);
    }

    [Fact]
    public void Delete_IdUnknown_ReturnsNotFoundResult()
    {
        Cliente? returns = null;
        _mockRepository.Setup(repo => repo.GetById(0)).Returns(returns!);

        var result = _controller.Delete(0);

        Assert.IsType<NotFoundResult>(result);
    }

    [Fact]
    public void Delete_ValidIdPassed_ReturnsOkResult()
    {
        var clienteToDelete = GetClientes()[0];
        _mockRepository.Setup(repo => repo.GetById(1)).Returns(clienteToDelete);

        var result = _controller.Delete(1);

        Assert.IsType<OkResult>(result);
    }

    [Fact]
    public void GetByName_NameNotFound_ReturnsNotFoundResult()
    {
        List<Cliente>? returns = null;
        _mockRepository.Setup(repo => repo.GetByName("Unknown")).Returns(returns!);

        var result = _controller.GetByName("Unknown");

        Assert.IsType<NotFoundResult>(result);
    }

    [Fact]
    public void GetByName_ValidNamePassed_ReturnsOkResult()
    {
        var expectedClientes = GetClientes();
        var searchName = expectedClientes[0].Nome;
        _mockRepository.Setup(repo => repo.GetByName(searchName)).Returns(expectedClientes);

        var result = _controller.GetByName(searchName);

        var okResult = Assert.IsType<OkObjectResult>(result);
        var returnValue = Assert.IsType<List<Cliente>>(okResult.Value);
        Assert.Equal(expectedClientes.Count, returnValue.Count);
    }

    private List<Cliente> GetClientes()
    {
        return new List<Cliente>
        {
            new Cliente { Id = 1, Nome = "Bob" },
            new Cliente { Id = 2, Nome = "Alice" }
        };
    }
}