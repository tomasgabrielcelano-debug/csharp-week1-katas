# Day 1 — null, empty y `string?` (Nullable)

## Idea clave (1 línea)
- **`null`** = no hay dato / no existe el objeto
- **empty** (`""`, `[]`) = el objeto existe, pero está vacío

---

## 1) `null` vs `""` (string)

### Ejemplos
```csharp
string? a = null; // no hay string (ausencia real)
string b = "";    // hay string, pero vacío (contenido 0)
string c = " ";   // hay string, pero con espacios (casi siempre equivale a “vacío”)
```

### Validación típica
```csharp
if (string.IsNullOrEmpty(s)) { /* null o "" */ }
if (string.IsNullOrWhiteSpace(s)) { /* null, "" o "   " */ }
```

---

## 2) ¿Qué significa `string?`
`string?` NO significa “no existe”.

Significa:
> “**Esta variable PUEDE ser null**”.

O sea, es **opcional**.

```csharp
string? nombre = null;     // ahora mismo no lo tengo
nombre = "Tomás";          // después sí lo tengo
```

---

## 3) ¿Qué significa `string` (sin `?`)
`string` (sin `?`) significa:
> “**No debería ser null**” (dato obligatorio)

```csharp
string nombre = "Tomás";
```

Si tenés Nullable habilitado, esto te debería marcar warning/error:
```csharp
string nombre = null; // NO recomendado
```

---

## 4) Regla práctica para no confundirte

### Usá `string?` cuando:
- El dato **puede no existir** (no aplica / no lo tengo)
  - Ej: segundo teléfono, apodo, observación opcional

### Usá `string` cuando:
- El dato **es obligatorio**
  - Ej: nombre del cliente (si tu sistema lo requiere)

### Y además:
- Si el dato es obligatorio, normalmente también validás que no sea vacío:
```csharp
if (string.IsNullOrWhiteSpace(nombre))
    throw new ArgumentException("Nombre requerido", nameof(nombre));
```

---

## 5) Colecciones (List / arrays): casi siempre devolvé vacío, no null
- “No hay resultados” => **lista vacía** `[]`
- `null` en listas suele complicar el código con checks innecesarios.

```csharp
var resultados = new List<int>(); // 0 items, pero existe (bien)
```

---

## 6) (Opcional) Habilitar Nullable en el proyecto
En el `.csproj`:
```xml
<PropertyGroup>
  <Nullable>enable</Nullable>
</PropertyGroup>
```

Con eso, C# te avisa cuando estás usando `null` donde no corresponde.

---

## Resumen
- `string? x = null` => **x puede ser null**, y ahora mismo está “sin dato”.
- `string x = ""` => **hay string**, pero está vacío.
- Para listas: preferí **vacío** antes que `null`.
