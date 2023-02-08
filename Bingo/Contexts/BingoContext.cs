using Bingo.Models;
using Microsoft.EntityFrameworkCore;

namespace Bingo.Contexts
{
    public class BingoContext : DbContext
    {
        public BingoContext() { }
        public BingoContext(DbContextOptions<BingoContext> options): base(options) { }
        public DbSet<HistorialBolillero> HistorialBolilleros { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                
                optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=BingoTest;Trusted_Connection=True;");
              
                
                
            }
        }
    }
}
