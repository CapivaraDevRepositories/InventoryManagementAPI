using mf_imports.DAL.Interfaces;
using mf_imports.Model;

namespace mf_imports.DAL;

public class ConectorRepository : IConectorRepository
{
    private ConnectionContext _context = new ConnectionContext();
    
    public void Add(Conector conector)
    {
        _context.Conectores.Add(conector);
        _context.SaveChanges();
    }

    public List<Conector> GetAll()
    {
        return _context.Conectores.ToList();
    }

    public Conector GetById(int id)
    {
        return _context.Conectores.FirstOrDefault(c => c.Id == id);
    }

    public Conector GetByName(string name)
    {
        return _context.Conectores.FirstOrDefault(c => c.Nome.Equals(name));
    }

    public void Alter(Conector conector)
    {
        _context.Conectores.Update(conector);
        _context.SaveChanges();
    }

    public void Delete(Conector conector)
    {
        _context.Remove(conector);
        _context.SaveChanges();
    }
}