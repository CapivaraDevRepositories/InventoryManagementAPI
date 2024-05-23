using mf_imports.Model;

namespace mf_imports.DAL.Interfaces;

public interface IProdutoRepository
{
    void Add(Produto produto);
    List<Produto> GetAll();
    Produto GetById(int id);
    Produto GetByName(string name);
    void Alter(Produto produto);
    void Delete(Produto produto);
}