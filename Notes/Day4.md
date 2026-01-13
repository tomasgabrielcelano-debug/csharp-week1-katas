# Day 4 — Kata: MinMaxSafe (lista vacía no revienta)

## QUÉ hice (resultado final)
Implementé una kata que devuelve **mínimo y máximo** de una secuencia de enteros **sin explotar si está vacía**:

- Método: `MinMaxSafeKata.MinMaxSafe(IEnumerable<int>? numbers)`
- Retorno: `(int? Min, int? Max)`
- Reglas:
  - `numbers == null` → `throw new ArgumentNullException(...)`
  - `numbers` vacío → devuelve `(null, null)`
  - con valores → devuelve `(min, max)`

---

## POR QUÉ está diseñado así (decisiones)
- Uso `int?` porque necesito representar “no hay mínimo/máximo” cuando la lista está vacía.
- No uso `numbers.Min()` / `numbers.Max()` de LINQ porque **tiran excepción** en secuencias vacías.
- Recorro con `GetEnumerator()` para:
  - detectar vacío con `MoveNext()`
  - inicializar min/max con el primer elemento real
  - recorrer el resto una sola vez

---

## Código final (sin comentarios "qué hace")
### `src/Katas/MinMaxSafeKata.cs`
```csharp
using System;
using System.Collections.Generic;

namespace Katas;

public static class MinMaxSafeKata
{
    public static (int? Min, int? Max) MinMaxSafe(IEnumerable<int>? numbers)
    {
        if (numbers is null)
            throw new ArgumentNullException(nameof(numbers));

        using var e = numbers.GetEnumerator();
        if (!e.MoveNext())
            return (null, null);

        int min = e.Current;
        int max = e.Current;

        while (e.MoveNext())
        {
            int n = e.Current;
            if (n < min) min = n;
            if (n > max) max = n;
        }

        return (min, max);
    }
}
```

### `tests/Katas.Tests/MinMaxSafeKataTests.cs`
```csharp
using System;
using Xunit;
using Katas;

namespace Katas.Tests;

public class MinMaxSafeKataTests
{
    [Fact]
    public void MinMaxSafe_WhenNull_ThrowsArgumentNullException()
    {
        Assert.Throws<ArgumentNullException>(() => MinMaxSafeKata.MinMaxSafe(null));
    }

    [Fact]
    public void MinMaxSafe_WhenEmpty_ReturnsNullNull()
    {
        var (min, max) = MinMaxSafeKata.MinMaxSafe(Array.Empty<int>());
        Assert.Null(min);
        Assert.Null(max);
    }

    [Fact]
    public void MinMaxSafe_WithOneElement_ReturnsThatElement()
    {
        var (min, max) = MinMaxSafeKata.MinMaxSafe(new[] { 7 });
        Assert.Equal(7, min);
        Assert.Equal(7, max);
    }

    [Fact]
    public void MinMaxSafe_WithMany_ReturnsMinAndMax()
    {
        var (min, max) = MinMaxSafeKata.MinMaxSafe(new[] { 3, -2, 10, 4 });
        Assert.Equal(-2, min);
        Assert.Equal(10, max);
    }
}
```

---

## Explicación línea por línea (POR QUÉ) — MinMaxSafeKata.cs

> No es “qué hace”, es **por qué existe esa línea**.

1. `using System;`  
   Porque necesito `ArgumentNullException`.
2. `using System.Collections.Generic;`  
   Porque `IEnumerable<int>` vive ahí.
3. `namespace Katas;`  
   Mantengo todas las katas agrupadas en el mismo namespace.
4. `public static class MinMaxSafeKata`  
   Static para no instanciar objetos (kata = función pura).
5. Firma `public static (int? Min, int? Max) MinMaxSafe(IEnumerable<int>? numbers)`  
   - `IEnumerable<int>?` para aceptar cualquier colección y permitir null (regla de la kata).  
   - `(int? Min, int? Max)` para poder devolver “no hay min/max” en vacío sin excepciones.
6. `if (numbers is null) throw ...`  
   Diferencio “no me pasaron nada” (null) de “me pasaron vacío” (empty).
7. `using var e = numbers.GetEnumerator();`  
   Uso enumerador porque `IEnumerable` no garantiza `Count` ni índices.
8. `if (!e.MoveNext()) return (null, null);`  
   Si no hay primer elemento → la secuencia está vacía → retorno seguro.
9. `int min = e.Current; int max = e.Current;`  
   Inicializo con el primer elemento real (evita valores “inventados” tipo `int.MaxValue`).
10. `while (e.MoveNext()) { ... }`  
    Recorro el resto una sola vez.
11. `if (n < min) ...` / `if (n > max) ...`  
    Actualizo límites sin ordenar ni crear listas nuevas.
12. `return (min, max);`  
    Devuelvo la tupla final.

---

## Explicación línea por línea (POR QUÉ) — MinMaxSafeKataTests.cs

1. `using System;`  
   Para `ArgumentNullException` y `Array.Empty<int>()`.
2. `using Xunit;`  
   Para `[Fact]` y `Assert.*`.
3. `using Katas;`  
   Para acceder a `MinMaxSafeKata`.
4. `Assert.Throws<ArgumentNullException>(...)`  
   Verifica la regla “null revienta con la excepción correcta”.
5. `Array.Empty<int>()`  
   Genera una secuencia vacía explícita, distinta de null.
6. `Assert.Null(min); Assert.Null(max);`  
   Contrato del vacío: no hay min/max, pero no hay crash.
7. Casos “1 elemento” y “muchos”  
   Cubren que el algoritmo inicializa bien y actualiza bien.

---

## Commit completo (paso a paso)

1) Asegurate de estar en la raíz del repo:
```bash
cd csharp-week1-katas
```

2) Corré tests (si esto falla, NO comitees):
```bash
dotnet test
```

3) Mirá qué cambió:
```bash
git status
```

4) Agregá todo:
```bash
git add -A
```

5) Commit:
```bash
git commit -m "day4: kata MinMaxSafe (no-throw on empty)"
```

6) Push (si ya tenés remoto configurado):
```bash
git push
```

---

## Limpieza que hice (repo más prolijo)
- Saqué comentarios “qué hace” de archivos que se habían ensuciado.
- Eliminé carpetas `bin/` y `obj/` que son build artifacts (no deben ir al repo).
- Moví el test de MinMaxSafe al proyecto correcto: `tests/Katas.Tests/`.
