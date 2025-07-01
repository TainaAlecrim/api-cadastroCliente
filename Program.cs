using CadastroClientes.Api.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// 1) Registrar o DbContext com InMemory:
builder.Services.AddDbContext<AppDbContext>(opt =>
    opt.UseInMemoryDatabase("ClientesDb"));

// 2) Habilitar controllers:
builder.Services.AddControllers();

// ** Adicionar a configuração do CORS aqui **
builder.Services.AddCors(options =>
{
    options.AddPolicy("PermitirFrontEnd", policy =>
    {
        policy.WithOrigins("http://localhost:5173")  // URL do seu front-end Blazor
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

// 3) (Opcional) Habilitar Swagger para documentação:
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// 4) Middleware:

// Usar CORS logo após criar o app, antes de mapear controllers
app.UseCors("PermitirFrontEnd");

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

// 5) Mapear controllers:
app.MapControllers();

app.Run();
