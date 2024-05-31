using mf_imports.DAL.Interfaces;
using mf_imports.Model;
using Microsoft.EntityFrameworkCore;

namespace mf_imports.DAL;

public class ConnectionContext : DbContext, IConnectionContext
{
    public DbSet<Produto> Produtos { get; set; }
    public DbSet<Categoria> Categorias { get; set; }
    public DbSet<Conector> Conectores { get; set; }
    public DbSet<UnidadeMedida> UnidadeMedidas { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Categoria>()
            .HasMany<Produto>()
            .WithOne(e => e.Categoria)
            .HasForeignKey("CategoriaId")
            .IsRequired();
            
        base.OnModelCreating(modelBuilder);
    }

    public ConnectionContext(DbContextOptions options) : base(options)
    {
    }
}