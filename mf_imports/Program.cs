using mf_imports.DAL;
using mf_imports.DAL.Interfaces;
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


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<ICategoriaRepository, CategoriaRepository>();
builder.Services.AddTransient<IProdutoRepository, ProdutoRepository>();
builder.Services.AddTransient<IConectorRepository, ConectorRepository>();
builder.Services.AddTransient<IUnidadeMedidaRepository, UnidadeMedidaRepository>();
builder.Services.AddTransient<ICalculoImpostoService, CalculoImpostoService>();
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
