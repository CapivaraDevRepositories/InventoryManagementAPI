using mf_imports.Model;

namespace mf_imports.DAL.Interfaces;

public interface IProdutoRepository
{
    void Add(Produto produto);
    IList<Produto> GetAll();
    Produto GetById(int id);
    IList<Produto> GetByName(string name);
    void Update(Produto produto);
    void Remove(Produto produto);
}