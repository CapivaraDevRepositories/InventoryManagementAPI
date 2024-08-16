using System.Text.Json.Serialization;
using mf_imports.DAL;
using mf_imports.DAL.Interfaces;
using mf_imports.Model;
using mf_imports.Services;
using mf_imports.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var OrigensParaCors = "_OrigemParaCors";

builder.Services.AddCors(options =>
    options.AddPolicy(name: OrigensParaCors,
        policy =>
        {
            policy.WithOrigins(
                "http://localhost:4200",
                "http://127.0.0.1:4200",
                "http://localhost:3000"
            )
            .AllowAnyHeader()
            .AllowAnyMethod();
        }
    )
);

// Add services to the container.
builder.Services.AddDbContext<IConnectionContext, ConnectionContext>(
    options => options.UseSqlServer(
        builder.Configuration.GetConnectionString("Production")
    )
);

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// REPOSITORIES
builder.Services.AddTransient<IRepository<Categoria>, CategoriaRepository>();
builder.Services.AddTransient<IRepository<Cliente>, Repository<Cliente>>();
builder.Services.AddTransient<IRepository<CompraProduto>, CompraProdutoRepository>();
builder.Services.AddTransient<IRepository<Conector>, ConectorRepository>();
builder.Services.AddTransient<IRepository<Estoque>, Repository<Estoque>>();
builder.Services.AddTransient<IRepository<EstoqueLocal>, EstoqueLocalRepository>();
builder.Services.AddTransient<IRepository<EstoqueMovimenta>, Repository<EstoqueMovimenta>>();
builder.Services.AddTransient<IRepository<Produto>, ProdutoRepository>();
builder.Services.AddTransient<IRepository<UnidadeMedida>, UnidadeMedidaRepository>();
builder.Services.AddTransient<IRepository<Venda>, VendasRepository>();

// SERVICES
builder.Services.AddScoped<ICalculoImpostoService, CalculoImpostoService>();
builder.Services.AddScoped<ICompraProdutoService, CompraProdutoService>();
builder.Services.AddScoped<IVendaService, VendaService>();
var app = builder.Build();

// Configure the HTTP request pipeline.
// if (app.Environment.IsDevelopment())
// {
    app.UseSwagger();
    app.UseSwaggerUI();
// }

app.UseCors(OrigensParaCors);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
