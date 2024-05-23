using mf_imports.DAL.Interfaces;
using mf_imports.Model;
using Microsoft.EntityFrameworkCore;

namespace mf_imports.DAL;

public class CategoriaRepository : ICategoriaRepository
{
    private ConnectionContext _context = new ConnectionContext();
    
    public void Add(Categoria categoria)
    {
        _context.Categorias.Add(categoria);
        _context.SaveChanges();
    }

    public List<Categoria?> GetAll()
    {
        return _context.Categorias.ToList();
    }

    public Categoria GetById(int id)
    {
        return _context.Categorias.FirstOrDefault(c => c.Id == id);
    }

    public Categoria? GetByName(string name)
    {
        return _context.Categorias.FirstOrDefault(c => c.Nome.Equals(name));
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