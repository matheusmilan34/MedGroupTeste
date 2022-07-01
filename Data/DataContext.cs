using MedGroupTeste.Models;
using Microsoft.EntityFrameworkCore;

namespace MedGroupTeste.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
              : base(options)
        {

        }

        public DbSet<Contato> Contatos { get; set; }
    }
}
