using Bingo.Models;
using Bingo.Repositories;

namespace Bingo.Services
{
    public class BingoService : IBingoService
    {
        public int[,] CrearCarton()
        {
            var repository = new BingoRepository();
            var carton = repository.CrearCarton();
            return carton;
        }

        public void GuardarHistorialBolilla(HistorialBolillero historialBolillero) 
        {
            var repository = new BingoRepository();
            repository.GuardarHistorialBolilla(historialBolillero);   
        }

        public void GuardarHistorialCartones(HistorialCartones historialCartones)
        {
            var repository = new BingoRepository();
            repository.GuardarHistorialCartones(historialCartones);
        }
    }
}
