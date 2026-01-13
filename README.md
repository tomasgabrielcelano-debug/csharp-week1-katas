# csharp-week1-katas

Práctica diaria de **C#** con enfoque en **TDD (xUnit)** usando una estructura simple:
- **Katas** (lógica) en una librería
- **Tests** en xUnit
- **Runner** (Console App) para ejecutar rápido desde consola
- **Exercises/** (enunciados) y **Notes/** (teoría / aprendizajes)

---

## Requisitos

- **.NET SDK (LTS)** instalado
- (Opcional) **VS Code** + extensión **C# Dev Kit**

Verificá:
```bash
dotnet --version
```

---

## Estructura del repo

```
/Exercises           -> enunciados y ejercicios del día (Markdown o .cs)
/Notes               -> notas/teoría del día (Markdown)
/src
  /Katas             -> implementación de katas (librería)
/src
  /Katas.Runner      -> consola para ejecutar (manual/run del día)
/tests
  /Katas.Tests       -> tests con xUnit
```

---

## Comandos

### Correr tests (TDD)
Desde la raíz del repo:
```bash
dotnet test
```

### Correr el Runner (consola)
```bash
dotnet run --project src/Katas.Runner
```

---

## Flujo recomendado (TDD)

1) **Enunciado**: crear/actualizar en `/Exercises/DayN-<Kata>.md`
2) **Test primero**: escribir el test en `/tests/Katas.Tests`
3) **Implementación mínima**: implementar en `/src/Katas`
4) Repetir:
   - `dotnet test` (Red → Green)
   - refactor (manteniendo tests verdes)
5) **Runner**: probar manual desde `/src/Katas.Runner` (opcional)

---

## Convenciones sugeridas

### Naming
- Katas: `XxxKata.cs` (ej: `SumListKata.cs`)
- Tests: `XxxKataTests.cs` (ej: `SumListKataTests.cs`)
- Notes: `Notes/DayN.md`
- Exercises: `Exercises/DayN-<Kata>.md`

### Commits (1 por día)
Ejemplos:
- `day1: kata HelloWorld (tests + impl + runner)`
- `day1: kata SumList (null/empty validation)`
- `day2: kata FizzBuzz (basic cases)`
- `day2: refactor FizzBuzz (cleanup)`

---

## Cómo agregar un nuevo día (plantilla rápida)

- `Exercises/Day2-<Kata>.md` → enunciado
- `Notes/Day2.md` → teoría/resumen
- `tests/Katas.Tests/<Kata>Tests.cs` → tests
- `src/Katas/<Kata>.cs` → implementación
- (Opcional) `Exercises/Day2.cs` + en el runner llamar `Day2.Run()`

---

## Tips para aprender (sin “copy paste”)

- Escribí primero **un test mínimo** y hacelo pasar con el **código más simple**.
- Si no entendés una línea: agregá un comentario en `Notes/DayN.md` (no en el código final).
- Preferí `dotnet test` frecuente antes que “codificar 1 hora sin correr nada”.

---
