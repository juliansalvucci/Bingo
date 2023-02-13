using Bingo.Models;

namespace Bingo.Services
{
    public interface IBingoService
    {
        int[,] CrearCarton();
        public void GuardarHistorialBolilla(HistorialBolillero historialBolillero);
        public void GuardarHistorialCartones(HistorialCartones historialCartones);
    }
}
