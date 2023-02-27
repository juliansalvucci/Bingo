using Bingo.Contexts;
using Bingo.Models;

namespace Bingo.Repositories
{
    public class BingoRepository
    {
        public int[,] CrearCarton()
        {
            var carton = new int[3, 9];  

            var random = new Random();

            //GENERACIÓN DE NÚMEROS PARA CARTÓN
            for (var columna = 0; columna < 9; columna++)
            {
                for (var fila = 0; fila < 3; fila++)
                {
                    var nuevoNumero = 0;
                    var nuevoEncontrado = false;

                    while (!nuevoEncontrado) //Mientras el número no exista
                    {
                        if (columna == 0) //Columna 1
                        {
                            nuevoNumero = random.Next(1, 10); //Para la columna 1, asignar número de 1 a 9.
                        }
                        else if (columna == 8) //Columna 9
                        {
                            nuevoNumero = random.Next(80, 91);  //Para la ultima columna asignar numero 80 a 90;
                        }
                        else //Otras columnas
                        {
                            nuevoNumero = random.Next(columna * 10, columna * 10 + 10); 
                        }

                        //Buscamos si el número existe en la columna.
                        nuevoEncontrado = true;
                        for (var filaActual = 0; filaActual < 3; filaActual++)
                        {
                            if (carton[filaActual, columna] == nuevoNumero)
                            {
                                nuevoEncontrado = false;
                                break;
                            }
                        }
                    }
                    carton[fila, columna] = nuevoNumero; //En caso de no existir, asignar numero.
                }
            }

            //Una vez generado el cartón, se procede a generar los espacios vacios.
            var cartonConEspaciosVacios = GenerarVacios(carton); 
            
            return cartonConEspaciosVacios;
        }

        public int[,] GenerarVacios(int[,] carton)
        {
            var random = new Random();

            var borrados = 0;

            while (borrados < 12)  //Los espacios vacios no deben superar los 12 lugares del cartón.
            {
                //Generar posiciones de forma aleatoria.
                var filaABorrar = random.Next(0, 3);
                var columnaABorrar = random.Next(0, 9);

                if (carton[filaABorrar, columnaABorrar] == 0) //Si el valor en esa posición es 0, resetear ciclo.
                {
                    continue; //Se resetea el while.
                }

                //contar 0s en filas.
                var cerosEnFila = 0;
                for (var c = 0; c < 9; c++)
                {
                    if (carton[filaABorrar, c] == 0)
                    {
                        cerosEnFila++;
                    }
                }

                //contar 0s en columnas.
                var cerosEnColumna = 0;
                for (var f = 0; f < 3; f++)
                {
                    if (carton[f, columnaABorrar] == 0)
                    {
                        cerosEnColumna++;
                    }
                }

                //Contar elementos diferentes de 0. Para borrar la cantidad que corresponda.
                var itemsPorColumna = new int[9]; 
                for (var c = 0; c < 9; c++)
                {
                    for (var f = 0; f < 3; f++)
                    {
                        if (carton[f, c] != 0)
                        {
                            itemsPorColumna[c]++;
                        }
                    }
                }

                var columnasConUnSoloNumero = 0;
                for (var c = 0; c < 9; c++)
                {
                    if (itemsPorColumna[c] == 1)
                    {
                        columnasConUnSoloNumero++;
                    }
                }

                //Si hay 4 0s en la fila, ya no se puede agregar otro 0 en esa fila.,
                //Si en la columna ya existen 2 0s; ya no se puede agregar otro 0 en dicha columna.
                if (cerosEnFila == 4 || cerosEnColumna == 2)
                {
                    continue; //resetear ciclo while.
                }

                //No pueden existir más de 3 columnas con un solo número.
                if (columnasConUnSoloNumero == 3 && itemsPorColumna[columnaABorrar] != 3)
                {
                    continue;
                }

                //Si no ha cumplido con las condiciones anteriores, asignar un 0 a la posición del cartón;
                carton[filaABorrar, columnaABorrar] = 0;
                borrados++;
            }

            return carton;
        }


        public async void GuardarHistorialBolilla(HistorialBolillero historialBolillero)
        {
            using (BingoContext _bingoContext = new BingoContext())
            {
                await _bingoContext.HistorialBolillero.AddAsync(historialBolillero);
                await _bingoContext.SaveChangesAsync();
            }   
        }

        public async void GuardarHistorialCartones(HistorialCartones historialCartones)
        {
            using(BingoContext _bingoContext = new BingoContext())
            {
                await _bingoContext.HistorialCartones.AddAsync(historialCartones);
                await _bingoContext.SaveChangesAsync();
            }
        }
    }
}
