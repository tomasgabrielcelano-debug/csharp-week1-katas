using System;
// Necesario para ArgumentNullException y ArgumentException.
// Si tu proyecto tiene "ImplicitUsings=enable", puede compilar igual.
// Pero es más claro tenerlo.

using System.Collections.Generic;
// Necesario para IEnumerable<int> (interfaz de colecciones enumerables).

namespace Katas;
// Namespace de tu librería de katas.

public static class SumListKata
// static: no necesitás instanciar (no hacés new SumListKata()).
// Llamás directo: SumListKata.Sum(...)
{
    public static int Sum(IEnumerable<int>? numbers)
    // Método público y estático que recibe una secuencia de ints.
    // IEnumerable<int>? significa:
    // - Puede ser una secuencia de ints
    // - Y además puede ser null (por el ?)
    {
        if (numbers is null)
            // Chequea si la referencia es null.
            throw new ArgumentNullException(nameof(numbers));
            // Lanza excepción específica para "argumento null".
            // nameof(numbers) genera el string "numbers", útil para mensajes claros.

        int sum = 0;
        // Variable acumuladora donde guardamos la suma.

        bool hasAny = false;
        // Bandera para detectar si la secuencia tenía al menos 1 elemento.
        // Arranca en false (asumimos vacío hasta demostrar lo contrario).

        foreach (var n in numbers)
        // Recorre cada elemento de la secuencia numbers.
        // var n es int (inferido).
        // IMPORTANTE: si numbers está vacío, este bloque NO se ejecuta nunca.
        {
            hasAny = true;
            // Si entramos acá, significa que hubo al menos un elemento.
            // Entonces ya no está vacío.

            sum += n;
            // sum = sum + n
            // Va acumulando todos los elementos.
        }

        if (!hasAny)
            // Si nunca entramos al foreach, hasAny sigue false -> era vacío.
            throw new ArgumentException("Sequence is empty.", nameof(numbers));
            // ArgumentException se usa cuando el argumento existe,
            // pero tiene un valor inválido para la regla (acá: vacío).

        return sum;
        // Devuelve la suma final.
    }
}
