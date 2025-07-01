using Microsoft.EntityFrameworkCore;
using CadastroClientes.Api.Models;

namespace CadastroClientes.Api.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        public DbSet<Cliente> Clientes { get; set; }
    }
}
