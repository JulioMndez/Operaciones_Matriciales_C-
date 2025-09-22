using System;

class MultiplicacionMatricesMultiple
{
    static void Main()
    {
        Console.WriteLine("===== MULTIPLICACION DE MULTIPLES MATRICES =====\n");

        int numMatrices = LeerEntero("Ingrese cuántas matrices desea multiplicar (mínimo 2): ", 2);

        int[] filas = new int[numMatrices];
        int[] columnas = new int[numMatrices];
        int[][,] matrices = new int[numMatrices][,];

        // Ingreso de matrices
        for (int m = 0; m < numMatrices; m++)
        {
            Console.WriteLine($"\nMATRIZ {m + 1}:");

            filas[m] = LeerEntero($"Ingrese el número de filas de la matriz {m + 1}: ");
            columnas[m] = LeerEntero($"Ingrese el número de columnas de la matriz {m + 1}: ");

            // Validar compatibilidad con la matriz anterior
            if (m > 0 && filas[m] != columnas[m - 1])
            {
                Console.WriteLine($"Error: Las filas de la matriz {m + 1} deben ser iguales a las columnas de la matriz {m}.");
                m--; // repetir esta matriz
                continue;
            }

            matrices[m] = new int[filas[m], columnas[m]];

            Console.WriteLine($"Ingrese los elementos de la matriz {m + 1}:");
            LeerMatriz(matrices[m], filas[m], columnas[m]);
        }

        // Imprimir matrices ingresadas
        for (int m = 0; m < numMatrices; m++)
        {
            ImprimirMatrizConMarco(matrices[m], filas[m], columnas[m], $"MATRIZ {m + 1}");
        }

        // Multiplicación secuencial
        int[,] resultado = matrices[0];
        for (int m = 1; m < numMatrices; m++)
        {
            resultado = MultiplicarDosMatrices(resultado, matrices[m]);
        }

        // Imprimir resultado final
        ImprimirMatrizConMarco(resultado, resultado.GetLength(0), resultado.GetLength(1), "RESULTADO FINAL");

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

    static int[,] MultiplicarDosMatrices(int[,] A, int[,] B)
    {
        int filasA = A.GetLength(0);
        int columnasA = A.GetLength(1);
        int filasB = B.GetLength(0);
        int columnasB = B.GetLength(1);

        int[,] resultado = new int[filasA, columnasB];

        for (int i = 0; i < filasA; i++)
            for (int j = 0; j < columnasB; j++)
            {
                resultado[i, j] = 0;
                for (int k = 0; k < columnasA; k++)
                    resultado[i, j] += A[i, k] * B[k, j];
            }

        return resultado;
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
