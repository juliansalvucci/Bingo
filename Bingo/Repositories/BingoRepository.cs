using Bingo.Models;
using System;

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
                            nuevoNumero = random.Next(1, 10);
                        }
                        else if (columna == 8) //Columna 9
                        {
                            nuevoNumero = random.Next(80, 91);
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
                    carton[fila, columna] = nuevoNumero;
                }
            }

            var cartonConEspaciosVacios = GenerarVacios(carton);
            var cartonEnLista = new List<int>();

            for (var columna = 0; columna < 9; columna++)
            {
                for (var fila = 0; fila < 3; fila++)
                {
                    cartonEnLista.Add(cartonConEspaciosVacios[fila, columna]);
                }
            }

            return cartonConEspaciosVacios;
        }

        public int[,] GenerarVacios(int[,] carton)
        {
            var random = new Random();

            var borrados = 0;

            while (borrados < 12)
            {
                var filaABorrar = random.Next(0, 3);
                var columnaABorrar = random.Next(0, 9);

                if (carton[filaABorrar, columnaABorrar] == 0) //Si el valor en esa posición es 0, ya esta.
                {
                    continue; //Se resetea el while.
                }

                //contar 0s
                var cerosEnFila = 0;
                for (var c = 0; c < 9; c++)
                {
                    if (carton[filaABorrar, c] == 0)
                    {
                        cerosEnFila++;
                    }
                }

                var cerosEnColumna = 0;
                for (var f = 0; f < 3; f++)
                {
                    if (carton[f, columnaABorrar] == 0)
                    {
                        cerosEnColumna++;
                    }
                }

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

                if (cerosEnFila == 4 || cerosEnColumna == 2)
                {
                    continue;
                }

                if (columnasConUnSoloNumero == 3 && itemsPorColumna[columnaABorrar] != 3)
                {
                    continue;
                }

                carton[filaABorrar, columnaABorrar] = 0;
                borrados++;
            }

            return carton;
        }

        public int LanzarBolilla()
        {
            int min = 1;
            int max = 90;

            Random rnd = new Random();
            return rnd.Next(min, max + 1);
        }

        public void Sortear(List<int> carton)
        {
            var bolilla = LanzarBolilla();

            carton.Contains(bolilla);
        }
    }
}
