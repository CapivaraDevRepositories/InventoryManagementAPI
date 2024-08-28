using mf_imports.Controllers;
using mf_imports.DAL.Interfaces;
using mf_imports.Model;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace UnitTests.Controllers;

[Trait("Category", "ConectorController")]
public class ConectorControllerTest
{
    private readonly ConectorController _controller;
    private readonly Mock<IRepository<Conector>> _mockRepository;

    public ConectorControllerTest()
    {
        _mockRepository = new Mock<IRepository<Conector>>();
        _controller = new ConectorController(_mockRepository.Object);
    }

    [Fact]
    public void GetAllConectors_ReturnsOkResult()
    {
        // Arrange
        _mockRepository.Setup(repo => repo.GetAll()).Returns(new List<Conector>());

        // Act
        var result = _controller.GetAllConectors();

        // Assert
        Assert.IsType<OkObjectResult>(result);
    }

    [Fact]
    public void GetById_ExistingId_ReturnsOkResult()
    {
        // Arrange
        var conector = new Conector();
        _mockRepository.Setup(repo => repo.GetById(It.IsAny<int>())).Returns(conector);

        // Act
        var result = _controller.GetById(1);

        // Assert
        Assert.IsType<OkObjectResult>(result);
    }

    [Fact]
    public void GetById_UnknownId_ReturnsNotFoundResult()
    {
        Conector? returnedConector = null;
        // Arrange
        _mockRepository.Setup(repo => repo.GetById(It.IsAny<int>())).Returns(returnedConector!);

        // Act
        var result = _controller.GetById(1);

        // Assert
        Assert.IsType<NotFoundResult>(result);
    }

    [Fact]
    public void Remove_ExistingId_ReturnsOkResult()
    {
        // Arrange
        var conector = new Conector();
        _mockRepository.Setup(repo => repo.GetById(It.IsAny<int>())).Returns(conector);

        // Act
        var result = _controller.Remove(1);

        // Assert
        Assert.IsType<OkResult>(result);
    }

    [Fact]
    public void Remove_UnknownId_ReturnsNotFoundResult()
    {
        Conector? returnedConector = null;
        // Arrange
        _mockRepository.Setup(repo => repo.GetById(It.IsAny<int>())).Returns(returnedConector!);

        // Act
        var result = _controller.Remove(1);

        // Assert
        Assert.IsType<NotFoundResult>(result);
    }

    [Fact]
    public void Add_ValidConector_ReturnsCreatedResult()
    {
        // Arrange
        var conector = new Conector();

        // Act
        var result = _controller.Add(conector);

        // Assert
        Assert.IsType<CreatedResult>(result);
    }
}