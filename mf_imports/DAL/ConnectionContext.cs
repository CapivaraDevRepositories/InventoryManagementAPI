using mf_imports.Model;
using Microsoft.EntityFrameworkCore;

namespace mf_imports.DAL;

public class ConnectionContext : DbContext
{
    public DbSet<Produto> Produtos { get; set; }
    public DbSet<Categoria> Categorias { get; set; }
    public DbSet<Conector> Conectores { get; set; }
    public DbSet<UnidadeMedida> UnidadeMedidas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        string server = "mvsr-oneway";
        string database = "mfautoparts";
        string user = "api_user";
        string password = "bHoiwym4oUGArVGh";
        optionsBuilder.UseSqlServer("Server=mvsr-oneway.database.windows.net;Database=mfautoparts;User=api_user;Password=bHoiwym4oUGArVGh");
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Categoria>()
            .HasMany<Produto>()
            .WithOne(e => e.Categoria)
            .HasForeignKey("CategoriaId")
            .IsRequired();
            
        base.OnModelCreating(modelBuilder);
    }
}