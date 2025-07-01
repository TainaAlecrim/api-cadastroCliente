using CadastroClientes.Api.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// 1) Registrar o DbContext com InMemory:
builder.Services.AddDbContext<AppDbContext>(opt =>
    opt.UseInMemoryDatabase("ClientesDb"));

// 2) Habilitar controllers:
builder.Services.AddControllers();

// 3) (Opcional) Habilitar Swagger para documentação:
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// 4) Middleware:
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

// 5) Mapear controllers:
app.MapControllers();

app.Run();
