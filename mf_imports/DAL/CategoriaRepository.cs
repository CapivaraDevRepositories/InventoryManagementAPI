using mf_imports.DAL.Interfaces;
using mf_imports.Model;
using Microsoft.EntityFrameworkCore;

namespace mf_imports.DAL;

public class CategoriaRepository : ICategoriaRepository
{
    private ConnectionContext _context;

    public CategoriaRepository(ConnectionContext context)
    {
        _context = context;
    }

    public void Add(Categoria categoria)
    {
        _context.Categorias.Add(categoria);
        _context.SaveChanges();
    }

    public IList<Categoria> GetAll()
    {
        return _context.Categorias.ToList();
    }

    public Categoria GetById(int id)
    {
        return _context.Categorias.FirstOrDefault(c => c.Id == id);
    }

    public IList<Categoria> GetByName(string name)
    {
        return _context.Categorias.Where(c => c.Nome.ToLower().Contains(name)).ToList();
    }

    public void Alter(Categoria categoria)
    {
        _context.Categorias.Update(categoria);
        _context.SaveChanges();
    }

    public void Delete(Categoria categoria)
    {
        _context.Categorias.Remove(categoria);
        _context.SaveChanges();
    }
}