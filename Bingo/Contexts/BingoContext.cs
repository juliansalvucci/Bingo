using Bingo.Models;
using Microsoft.EntityFrameworkCore;

namespace Bingo.Contexts
{
    public class BingoContext : DbContext
    {
        public BingoContext(DbContextOptions<BingoContext> options): base(options) { }

        public DbSet<HistorialBolillero> HistorialBolilleros { get; set; }
    }
}
