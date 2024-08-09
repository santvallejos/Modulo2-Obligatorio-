//Weather Forecast 2.0

weatherForescast2();

void weatherForescast2()
{   
    //Ingresar temperaturas
    int[,] temps = enterTemps();

    //Muestra el menu y selecciona una opcion
    menu();
    var option = intParse();
    
    while (option != 8)
    {
        switch (option)
        {
            case 1:
                tempDay(temps);//Consultar temperatura por dia
                break;
            case 2:
                averageWeeks(temps);//Calcular el promedio de temperaturas por semanas
                break;
            case 3:
                threshold(temps);//Mostrar temperaturas superadas el umbral
                break;
            case 4:
                averageTempsMonth(temps);//Calcular el promedio de temperatura del mes
                break;
            case 5:
                tempsHigher(temps);//Temperatura mas alta
                break;
            case 6:
                tempsLess(temps);//Temperatura mas baj
                break;
            case 7:
                generateTempNext5(temps);//Proximas temperaturas
                break;
            default:
                Console.WriteLine("Error al ingresar una opción!!");
                break;
        }

        Console.WriteLine("Desea consultar alguna otra opción?");
        option = intParse();
    }

    Console.WriteLine("Saliendo!...");
}

int[,] enterTemps()
{
    //Matriz de 5x7 con temperatura del mes
    return new int[,] { { 13, 15, 11, 16, 20, 24, 25 },
                        { 29, 30, 32, 32, 26, 22, 20 }, 
                        { 19, 18, 14, 15, 15, 16, 15 }, 
                        { 17, 21, 24, 20, 19, 24, 25 }, 
                        { 25, 25, 26,  0,  0,  0, 0} };
}

void menu()
{
    Console.WriteLine(
        "\nMarque una opción para continuar con el programa: " +
        "\n1.Consultar la temperatura de un día\n2.Promedio de temperaturas de cada semana\n3.Temperaturas por encima del Umbral\n4.Promedio de temperatura del mes\n5.Temperatura Mayor\n6.Temperatura Menor\n7.Pronóstico de los siguientes 5 días\n8.Salir"
    );
}

int intParse()
{
    var option = Console.ReadLine();
    int optionInt;
    Int32.TryParse(option, out optionInt);
    return optionInt;
}

void tempDay(int[,] temps)
{
    Console.WriteLine("\nIngresa el día del mes (1-31):");
        var day = intParse();

        // Verificar que el día esté dentro del rango válido
        if (day < 1 || day > 31)
        {
            Console.WriteLine("\nDía no válido. Por favor ingresa un número entre 1 y 31.");
        }
        else
        {
            // Calcular la fila y la columna correspondientes al día
            int fila = (day - 1) / 7;
            int columna = (day - 1) % 7;

            // Obtener la temperatura del día
            int temp = temps[fila, columna];
            
            Console.WriteLine($"\nLa temperatura del día {day} es: {temp}°.");
        }
}

void averageWeeks(int[,] temps)
{
    List<double> averageTempsWeeks = new List<double>();//Declaracion de lista

    for (int i = 0; i < temps.GetLength(0); i++) // Recorre las filas
    {
        int sum = 0;//Declaracion del contenedor de la suma

        for (int j = 0; j < temps.GetLength(1); j++) // Recorre las columnas
        {
            //suma todos los valores de cada columna de una fila y los guarda en la variable sum
            sum += temps[i, j];
        }

        double average; //Variable de promedio por semana sin inicializar

        if (i == temps.GetLength(0) - 1)
        {
            average = sum / 3;
        }
        else
        {
            average = sum / 7;
        }

        averageTempsWeeks.Add(average);//Lo inserta en la lista

        Console.WriteLine($"\nEl promedio de la semana {i + 1} es: {averageTempsWeeks[i]}");
    }
}

void threshold(int[,] temps)
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

    Console.WriteLine("\nLas temperaturas que superaron el umbral son: ");
    foreach (var item in threshold)
    {
        Console.WriteLine($"{item}°");
    }
}

void averageTempsMonth(int[,] temps)
{
    int sum = 0;
    foreach (var item in temps)
    {
        sum += item;
    }
    double averageTempsMonth = sum / 31;

    Console.WriteLine($"\nEl promedio de temperatura del mes es: {averageTempsMonth}");
}

void tempsHigher(int[,] temps)
{
    int max = temps[0, 0];

        // Recorremos la matriz para encontrar el valor máximo
        for (int i = 0; i < temps.GetLength(0); i++)
        {
            for (int j = 0; j < temps.GetLength(1); j++)
            {
                if (temps[i, j] > max)
                {
                    max = temps[i, j];
                }
            }
        }
    
    Console.WriteLine($"\nLa temperatura mas alta del mes es: {max}°");
}

void tempsLess(int[,] temps)
{
    int min = temps[0, 0];

    for (int i = 0; i < temps.GetLength(0); i++)
        {
            for (int j = 0; j < temps.GetLength(1); j++)
            {
                if (temps[i, j] < min && temps[i,j] != 0)
                {
                    min = temps[i, j];
                }
            }
        }

    Console.WriteLine($"La temperatura mas baja del mes es: {min}°");
}

void generateTempNext5(int[,] temps)
{
    var tempEnd = temps[4, 2];
    Console.WriteLine("\nLa temperatura de los siguientes dias son:");
    for(int i = 1; i < 4; i++)
    {
        tempEnd++;
        Console.WriteLine($"Dia {i}: {tempEnd}°");
    }
    Console.WriteLine($"\nDia 4: {tempEnd}°\nDia 5: {tempEnd - 1}°");
}