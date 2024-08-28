using mf_imports.Controllers;
using Moq;
using mf_imports.DAL.Interfaces;
using mf_imports.Model;
using Microsoft.AspNetCore.Mvc;

namespace UnitTests.Controllers;

[Trait("Category", "UnidadeMedidaController")]
public class UnidadeMedidaControllerTest
{
    private readonly UnidadeMedidaController _controller;
    private readonly Mock<IRepository<UnidadeMedida>> _mockRepo;

    public UnidadeMedidaControllerTest()
    {
        _mockRepo = new Mock<IRepository<UnidadeMedida>>();
        _controller = new UnidadeMedidaController(_mockRepo.Object);
    }

    [Fact]
    public void Get_ReturnsAllUnidadeMedida()
    {
        // Arrange
        var returnItems = new List<UnidadeMedida> { new UnidadeMedida() };
        _mockRepo.Setup(repo => repo.GetAll()).Returns(returnItems);

        // Act
        var result = _controller.Get();

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        Assert.Equal(returnItems, okResult.Value);
    }

    [Fact]
    public void GetById_UnidadeMedidaExists_ReturnsCorrectUnidadeMedida()
    {
        // Arrange
        int testId = 1;
        var returnItem = new UnidadeMedida { Id = testId };
        _mockRepo.Setup(repo => repo.GetById(testId)).Returns(returnItem);

        // Act
        var result = _controller.Get(testId);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        Assert.Equal(returnItem, okResult.Value);
    }

    [Fact]
    public void GetById_UnidadeMedidaDoesNotExist_ReturnsNotFoundResponse()
    {
        UnidadeMedida? returnItem = null;
        // Arrange
        _mockRepo.Setup(repo => repo.GetById(It.IsAny<int>())).Returns(returnItem!);

        // Act
        var result = _controller.Get(9);

        // Assert
        Assert.IsType<NotFoundResult>(result);
    }


    // Add a new UnidadeMedida and verify it is added successfully
    [Fact]
    public void Add_ValidUnidadeMedida_ReturnsCreatedResponse()
    {
        // Arrange
        var newUnidadeMedida = new UnidadeMedida { Id = 2, Nome = "TestName" };
        _mockRepo.Setup(repo => repo.Add(It.IsAny<UnidadeMedida>())).Verifiable();

        // Act
        var result = _controller.Add(newUnidadeMedida);

        // Assert
        Assert.IsType<CreatedResult>(result);
    }

    // Update an existing UnidadeMedida and verify the update action
    [Fact]
    public void Update_ValidUnidadeMedida_ReturnsOkResponse()
    {
        // Arrange
        var updatedUnidadeMedida = new UnidadeMedida { Id = 1, Nome = "UpdatedName" };
        _mockRepo.Setup(repo => repo.Alter(It.IsAny<UnidadeMedida>())).Verifiable();

        // Act
        var result = _controller.Update(updatedUnidadeMedida);

        // Assert
        Assert.IsType<OkResult>(result);
        _mockRepo.Verify();
    }

    // Delete an existing UnidadeMedida and verify the delete action
    [Fact]
    public void Delete_UnidadeMedidaExists_ReturnsOkResponse()
    {
        // Arrange
        int testId = 1;
        var returnItem = new UnidadeMedida { Id = testId };
        _mockRepo.Setup(repo => repo.GetById(testId)).Returns(returnItem);
        _mockRepo.Setup(repo => repo.Delete(It.IsAny<UnidadeMedida>())).Verifiable();

        // Act
        var result = _controller.Delete(testId);

        // Assert
        Assert.IsType<OkResult>(result);
        _mockRepo.Verify();
    }

    // Try to delete a non-existing UnidadeMedida and return NotFound
    [Fact]
    public void Delete_UnidadeMedidaDoesNotExist_ReturnsNotFoundResponse()
    {
        UnidadeMedida? returnItem = null;
        // Arrange
        _mockRepo.Setup(repo => repo.GetById(It.IsAny<int>())).Returns(returnItem!);

        // Act
        var result = _controller.Delete(9);

        // Assert
        Assert.IsType<NotFoundResult>(result);
    }

    // Get UnidadeMedida by name when it exists
    [Fact]
    public void GetByName_UnidadeMedidaExists_ReturnsCorrectUnidadeMedida()
    {
        // Arrange
        string testName = "TestName";
        var returnItems = new List<UnidadeMedida> { new UnidadeMedida { Nome = testName } };
        _mockRepo.Setup(repo => repo.GetByName(testName)).Returns(returnItems);

        // Act
        var result = _controller.GetByName(testName);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        Assert.Equal(returnItems, okResult.Value);
    }

    // Get UnidadeMedida by name when it does not exist
    [Fact]
    public void GetByName_UnidadeMedidaDoesNotExist_ReturnsNotFoundResponse()
    {
        // Arrange
        string testName = "NonExistentName";
        _mockRepo.Setup(repo => repo.GetByName(testName)).Returns(new List<UnidadeMedida>());

        // Act
        var result = _controller.GetByName(testName);

        // Assert
        Assert.IsType<NotFoundResult>(result);
    }
}