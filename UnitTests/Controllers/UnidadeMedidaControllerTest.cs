using mf_imports.Controllers;
using Moq;
using mf_imports.DAL.Interfaces;
using mf_imports.Model;
using Microsoft.AspNetCore.Mvc;

namespace UnitTests.Controllers
{
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
            // Arrange
            _mockRepo.Setup(repo => repo.GetById(It.IsAny<int>())).Returns((UnidadeMedida)null);

            // Act
            var result = _controller.Get(9);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }

        // Similar tests would be written for Add, Update, Delete, GetByName methods.
    }
}