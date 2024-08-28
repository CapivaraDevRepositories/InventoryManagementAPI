using Moq;
using mf_imports.Controllers;
using mf_imports.DAL.Interfaces;
using mf_imports.Model;
using Microsoft.AspNetCore.Mvc;


namespace UnitTests.Controllers;

[Trait("Category", "CategoriaController")]
public class CategoriaControllerTest
{
    private readonly Mock<IRepository<Categoria>> _repoMock;
    private readonly CategoriaController _controller;

    public CategoriaControllerTest()
    {
        _repoMock = new Mock<IRepository<Categoria>>();
        _controller = new CategoriaController(_repoMock.Object);
    }

    [Fact]
    public void Add_NullCategory_BadRequest()
    {
        var result = _controller.Add(null!);
        Assert.IsType<BadRequestObjectResult>(result);
    }

    [Fact]
    public void Add_ValidCategory_Created()
    {
        var categoria = new Categoria { Id = 1, Nome = "Test" };

        _repoMock.Setup(r => r.Add(It.IsAny<Categoria>()));

        var result = _controller.Add(categoria);

        Assert.IsType<CreatedResult>(result);
    }

    [Fact]
    public void Get_All_OK()
    {
        var categorias = new List<Categoria>
        {
            new Categoria { Id = 1, Nome = "Test1" },
            new Categoria { Id = 2, Nome = "Test2" }
        };

        _repoMock.Setup(r => r.GetAll()).Returns(categorias);

        var result = _controller.Get();

        var okResult = Assert.IsType<OkObjectResult>(result);
        var returnCategorias = Assert.IsType<List<Categoria>>(okResult.Value);

        Assert.Equal(2, returnCategorias.Count);
    }

    [Fact]
    public void Get_ById_Null_NotFound()
    {
        Categoria? returns = null;
        _repoMock.Setup(r => r.GetById(It.IsAny<int>())).Returns(returns!);

        var result = _controller.Get(6);

        Assert.IsType<NotFoundResult>(result);
    }

    [Fact]
    public void Get_ByNome_Null_NotFound()
    {
        List<Categoria>? returns = null;
        _repoMock.Setup(r => r.GetByName(It.IsAny<string>())).Returns(returns!);

        var result = _controller.Get("João");

        Assert.IsType<NotFoundResult>(result);
    }
    
    [Fact]
    public void Get_ById_Ok()
    {
        Categoria returns = new Categoria { Id = 1, Nome = "Test1" };
        _repoMock.Setup(r => r.GetById(It.IsAny<int>())).Returns(returns);

        var result = _controller.Get(1);

        var okObject = Assert.IsType<OkObjectResult>(result);
        Assert.IsType<Categoria>(okObject.Value);
    }
    
    [Fact]
    public void Get_ByNome_Ok()
    {
        var returns = new List<Categoria>
        {
            new Categoria { Id = 1, Nome = "Test1" },
            new Categoria { Id = 2, Nome = "Test2" }
        };
        _repoMock.Setup(r => r.GetByName(It.IsAny<string>())).Returns(returns);

        var result = _controller.Get("Test");

        var okResult = Assert.IsType<OkObjectResult>(result);
        var categoriaList = Assert.IsAssignableFrom<IEnumerable<Categoria>>(okResult.Value);
        Assert.Collection(categoriaList, 
            item => Assert.Equal(1, item.Id), 
            item => Assert.Equal(2, item.Id)
        );
    }

    [Fact]
    public void Delete_InvalidId_NotFound()
    {
        Categoria? returns = null;
        _repoMock.Setup(r => r.GetById(It.IsAny<int>())).Returns(returns!);

        var result = _controller.Delete(3);

        Assert.IsType<NotFoundObjectResult>(result);
    }
    
    [Fact]
    public void Delete_Id_Ok()
    {
        Categoria returns = new Categoria { Id = 1, Nome = "Test1" };
        _repoMock.Setup(r => r.GetById(It.IsAny<int>())).Returns(returns);

        var result = _controller.Delete(1);

        Assert.IsType<OkResult>(result);
    }

    [Fact]
    public void Update_NullCategory_BadRequest()
    {
        var result = _controller.Update(null!);
        Assert.IsType<BadRequestObjectResult>(result);
    }

    [Fact]
    public void Update_ValidCategory_Ok()
    {
        var categoria = new Categoria { Id = 1, Nome = "Test" };

        _repoMock.Setup(r => r.Alter(It.IsAny<Categoria>()));

        var result = _controller.Update(categoria);

        Assert.IsType<OkResult>(result);
    }
}