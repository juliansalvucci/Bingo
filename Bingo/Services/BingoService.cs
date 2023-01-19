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
    }
}
