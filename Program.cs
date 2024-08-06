//Weather Forecast 2.0

weatherForescast2();

void weatherForescast2()
{
    int[,] temps = enterTemps();

    calculateTemps(temps);
}

int[,] enterTemps()
{
    //Matriz de 5x7 con temperatura del mes
    return new int[,] { { 26, 25, 27, 29, 28, 32, 30 }, { 26, 25, 27, 29, 28, 32, 30 }, { 26, 25, 27, 29, 28, 32, 30 }, { 26, 25, 27, 29, 28, 32, 30 }, { 26, 25, 27, 29, 28, 32, 30 } };
}

void calculateTemps(int[,] temps)
{
    for (int i = 0; i < temps.GetLength(0); i++) // Recorre las filas
    {
        for (int j = 0; j < temps.GetLength(1); j++) // Recorre las columnas
        {
            Console.WriteLine($"Elemento en [{i},{j}] = {temps[i, j]}");
        }
    }
}

/*
    int[,] arregloMultidimensional = { { 26, 25, 27, 29, 28, 32, 30 }, { 26, 25, 27, 29, 28, 32, 30 }, { 26, 25, 27, 29, 28, 32, 30 }, { 26, 25, 27, 29, 28, 32, 30 }, { 26, 25, 27, 29, 28, 32, 30 }};
    // Iteración para recorrer el arreglo multidimensional
    for (int i = 0; i < arregloMultidimensional.GetLength(0); i++) // Recorre las filas
    {
        for (int j = 0; j < arregloMultidimensional.GetLength(1); j++) // Recorre las columnas
        {
            Console.WriteLine($"Elemento en [{i},{j}] = {arregloMultidimensional[i, j]}");
        }
    }
    */