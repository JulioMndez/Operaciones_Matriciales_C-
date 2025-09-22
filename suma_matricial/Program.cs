using System;

class SumaMatricesMultiple
{
    static void Main()
    {
        Console.WriteLine("===== SUMA DE MULTIPLES MATRICES =====\n");

        int numMatrices = LeerEntero("Ingrese cuántas matrices desea sumar (mínimo 2): ", 2);

        int filas = LeerEntero("Ingrese el número de filas de las matrices: ");
        int columnas = LeerEntero("Ingrese el número de columnas de las matrices: ");

        int[][,] matrices = new int[numMatrices][,];

        // Ingreso de matrices
        for (int m = 0; m < numMatrices; m++)
        {
            matrices[m] = new int[filas, columnas];
            Console.WriteLine($"\nMATRIZ {m + 1}:");
            LeerMatriz(matrices[m], filas, columnas);
        }

        // Imprimir matrices ingresadas
        for (int m = 0; m < numMatrices; m++)
        {
            ImprimirMatrizConMarco(matrices[m], filas, columnas, $"MATRIZ {m + 1}");
        }

        // Sumar matrices
        int[,] resultado = new int[filas, columnas];
        for (int i = 0; i < filas; i++)
            for (int j = 0; j < columnas; j++)
                for (int m = 0; m < numMatrices; m++)
                    resultado[i, j] += matrices[m][i, j];

        // Imprimir resultado final
        ImprimirMatrizConMarco(resultado, filas, columnas, "RESULTADO FINAL");

        Console.WriteLine("\nPresiona cualquier tecla para salir...");
        Console.ReadKey();
    }

    static int LeerEntero(string mensaje, int minimo = 1)
    {
        int valor;
        while (true)
        {
            Console.Write(mensaje);
            if (int.TryParse(Console.ReadLine(), out valor) && valor >= minimo)
                return valor;
            Console.WriteLine($"Error: ingrese un número entero mayor o igual a {minimo}.");
        }
    }

    static void LeerMatriz(int[,] matriz, int filas, int columnas)
    {
        for (int i = 0; i < filas; i++)
            for (int j = 0; j < columnas; j++)
                matriz[i, j] = LeerEntero($"Elemento [{i},{j}]: ");
    }

    static void ImprimirMatrizConMarco(int[,] matriz, int filas, int columnas, string titulo)
    {
        // Título
        Console.WriteLine($"\n===== {titulo} =====");

        // Marco superior
        Console.Write("┌");
        for (int j = 0; j < columnas; j++)
            Console.Write("─────" + (j == columnas - 1 ? "" : "┬"));
        Console.WriteLine("┐");

        // Filas
        for (int i = 0; i < filas; i++)
        {
            Console.Write("│");
            for (int j = 0; j < columnas; j++)
                Console.Write($"{matriz[i, j],5}" + (j == columnas - 1 ? "" : "│"));
            Console.WriteLine("│");

            // Separador de fila
            if (i != filas - 1)
            {
                Console.Write("├");
                for (int j = 0; j < columnas; j++)
                    Console.Write("─────" + (j == columnas - 1 ? "" : "┼"));
                Console.WriteLine("┤");
            }
        }

        // Marco inferior
        Console.Write("└");
        for (int j = 0; j < columnas; j++)
            Console.Write("─────" + (j == columnas - 1 ? "" : "┴"));
        Console.WriteLine("┘");
    }
}
