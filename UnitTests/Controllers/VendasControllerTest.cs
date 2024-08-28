using mf_imports.Controllers;
using mf_imports.DTO;
using mf_imports.Services.Interfaces;
using Moq;
using Microsoft.AspNetCore.Mvc;
using mf_imports.Model;

namespace UnitTests.Controllers
{
    [Trait("Category","VendasController")]
    public class VendasControllerTest
    {
        // Test for Post method
        [Fact] // Treating it as a fact because we are making assertions about a certain scenario.
        public void Post_ShouldReturnCreatedResult_WhenVendaIsCreatedNoExceptionRaised()
        {
            // Arrange
            var mockVendaService = new Mock<IVendaService>();
            var controller = new VendasController(mockVendaService.Object);
            var vendaDTO = new VendaDTO { ClienteId = 1, VendaProduto = new List<VendaProdutoDTO>() };

            // Act
            var result = controller.Post(vendaDTO);

            // Assert
            Assert.IsType<CreatedResult>(result);
        }

        [Fact]
        public void Post_ShouldReturnBadRequestResult_WhenVendaIsNotCreatedDueToException()
        {
            // Arrange
            var mockVendaService = new Mock<IVendaService>();
            mockVendaService.Setup(service => service.RealizarVenda(It.IsAny<VendaDTO>()))
                .Throws(new System.Exception());
            var controller = new VendasController(mockVendaService.Object);
            var vendaDTO = new VendaDTO { ClienteId = 1, VendaProduto = new List<VendaProdutoDTO>() };

            // Act
            var result = controller.Post(vendaDTO);

            // Assert
            Assert.IsType<BadRequestObjectResult>(result);
        }

        // Test for Get method
        [Fact]
        public void Get_ShouldReturnOkResultWithListOfVendas_WhenCalled()
        {
            // Arrange
            var mockVendaService = new Mock<IVendaService>();
            mockVendaService.Setup(service => service.GetAll()).Returns(new List<Venda>());
            var controller = new VendasController(mockVendaService.Object);

            // Act
            var result = controller.Get();

            // Assert
            Assert.IsType<OkObjectResult>(result);
            var objectResult = result as OkObjectResult;
            Assert.IsAssignableFrom<IEnumerable<Venda>>(objectResult.Value);
        }
    }
}