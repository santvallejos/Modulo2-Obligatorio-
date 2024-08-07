//Weather Forecast 2.0

weatherForescast2();

void weatherForescast2()
{
    int[,] temps = enterTemps();

    calculateTemps(temps);

    List<double> averageTemps = calculateTemps(temps);

    evaluateThreshold(temps);

    calculateTempsMonth(temps);

    tempsHigherAndLess(temps);
}

int[,] enterTemps()
{
    //Matriz de 5x7 con temperatura del mes
    return new int[,] { { 26, 25, 27, 29, 28, 32, 30 },
                        { 26, 25, 27, 29, 28, 32, 30 }, 
                        { 26, 25, 27, 29, 28, 32, 30 }, 
                        { 26, 25, 27, 29, 28, 32, 30 }, 
                        { 26, 25, 27, 29, 28, 32, 30 } };
}

//Funcion de tipo lista<double> retorna una lista con los promedios de temperatura semanales
List<double> calculateTemps(int[,] temps)
{
    List<double> averageTemps = new List<double>();//Declaracion de lista

    for (int i = 0; i < temps.GetLength(0); i++) // Recorre las filas
    {
        int sum = 0;//Declaracion del contenedor de la suma

        for (int j = 0; j < temps.GetLength(1); j++) // Recorre las columnas
        {
            //suma todos los valores de cada columna de una fila y los guarda en la variable sum
            sum += temps[i, j];
        }

        double averageTempsWeeks = sum / 7; //Promedio por semana
        averageTemps.Add(averageTempsWeeks);//Lo inserta en la lista

        Console.WriteLine($"El promedio de la semana {i + 1} es: " + averageTemps[i]);
    }
    return averageTemps;
}

void evaluateThreshold(int[,] temps)
{
    //Declaracion de la variable umbral sin inicializar
    List<double> threshold = new List<double>();

    for (int i = 0; i < temps.GetLength(0); i++) //Recorre las filas
    {
        for (int j = 0; j < temps.GetLength(1); j++) // Recorre las columnas
        {
            //Si el valor es mayor a 20 se guarda en el umbral
            if(temps[i, j] > 20)
            {
                threshold.Add(temps[i, j]);
            }
        }
    }
}

void calculateTempsMonth(int[,] temps)
{
    int sum = 0;
    foreach (var item in temps)
    {
        sum += item;
    }
    double averageTempsMonth = sum / 31;

    Console.WriteLine($"El promedio de la del mes es: " + averageTempsMonth);
}

void tempsHigherAndLess(int[,] temps)
{
    // Inicializamos los valores mínimo y máximo con el primer elemento de la matriz
        int min = temps[0, 0];
        int max = temps[0, 0];

        // Recorremos la matriz para encontrar el valor mínimo y máximo
        for (int i = 0; i < temps.GetLength(0); i++)
        {
            for (int j = 0; j < temps.GetLength(1); j++)
            {
                if (temps[i, j] < min)
                {
                    min = temps[i, j];
                }

                if (temps[i, j] > max)
                {
                    max = temps[i, j];
                }
            }
        }
}