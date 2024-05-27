using mf_imports.DAL.Interfaces;
using mf_imports.Model;

namespace mf_imports.DAL;

public class ProdutoRepository : IProdutoRepository
{
    private ConnectionContext _context = new ConnectionContext();
    
    public void Add(Produto produto)
    {
        //produto.Categoria = new CategoriaRepository().GetById(produto.CategoriaId);
        _context.Produtos.Add(produto);
        _context.SaveChanges();
    }

    public IList<Produto> GetAll()
    {
        return _context.Produtos.ToList();
    }

    public Produto GetById(int id)
    {
        return _context.Produtos.FirstOrDefault(p => p.Id == id);
    }

    public IList<Produto> GetByName(string name)
    {
        return _context.Produtos.Where(p => p.Nome.ToLower().Contains(name.ToLower())).ToList();
    }

    public void Update(Produto produto)
    {
        _context.Produtos.Update(produto);
        _context.SaveChanges();
    }

    public void Remove(Produto produto)
    {
        _context.Produtos.Remove(produto);
        _context.SaveChanges();
    }
}