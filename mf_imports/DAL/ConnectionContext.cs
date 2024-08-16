using mf_imports.DAL.Interfaces;
using mf_imports.Model;
using Microsoft.EntityFrameworkCore;

namespace mf_imports.DAL;

public class ConnectionContext : DbContext, IConnectionContext
{
    public DbSet<Categoria> Categorias { get; set; }
    public DbSet<Cliente> Clientes { get; set; }
    public DbSet<CompraProduto> CompraProduto { get; set; }
    public DbSet<Conector> Conectores { get; set; }
    public DbSet<Estoque> Estoque { get; set; }
    public DbSet<EstoqueLocal> EstoqueLocais { get; set; }
    public DbSet<EstoqueMovimenta> EstoqueMovimenta { get; set; }
    public DbSet<Produto> Produtos { get; set; }
    public DbSet<UnidadeMedida> UnidadeMedidas { get; set; }
    public DbSet<Venda> Vendas { get; set; }
    public DbSet<VendaProdutos> VendaProdutos { get; set; }

    public ConnectionContext(DbContextOptions options) : base(options) { }
    
    public DbSet<T> Set<T>() where T : class => base.Set<T>();
    public int SaveChanges() => base.SaveChanges();
    public TEntity Find<TEntity>(params object[] keyValues) where TEntity : class => base.Find<TEntity>(keyValues);
    public void Remove<TEntity>(TEntity entity) where TEntity : class => base.Set<TEntity>().Remove(entity);
    public void Update<TEntity>(TEntity entity) where TEntity : class => base.Set<TEntity>().Update(entity);
    public void Add<TEntity>(TEntity entity) where TEntity : class => base.Set<TEntity>().Add(entity);
    
}