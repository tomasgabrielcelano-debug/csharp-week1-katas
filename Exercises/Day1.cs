namespace Exercises;

using Katas;
// Importa el namespace "Katas" para poder usar SumListKata.
// Sin esto, SumListKata no se reconoce (otro error de compilación).

public static class Day1
{
    public static void Run()
    {
        Console.WriteLine("Day1: Hello World!");

        Console.WriteLine(SumListKata.Sum(new[] { 1, 2, 3 }));
        // 1) new[] { 1, 2, 3 } crea un array de enteros: int[] {1,2,3}
        // 2) SumListKata.Sum(...) calcula la suma de esos números.
        // 3) Console.WriteLine(...) imprime el resultado en la consola.
        // Resultado esperado: imprime 6.
    }
}
