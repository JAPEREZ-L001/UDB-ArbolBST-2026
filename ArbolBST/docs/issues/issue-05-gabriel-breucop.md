# Issue #5 — Gabriel Breucop · Frontend (Graphics / dibujo del árbol)

**Asignado a:** Gabriel Breucop  
**Rama:** `feature/graphics-gabriel`  
**Área:** Frontend  
**Archivos sugeridos:** `Services/RenderizadoArbol.cs` y/o métodos en `FormPrincipal.cs` (coordinar con Mario)  

> Usa un **arreglo fijo de `PosicionNodo` mock** para desarrollar el dibujo. **No** necesitas a Rodrigo ni a Josué para pintar la primera versión.

---

## Objetivo

Dibujar el árbol con `Graphics`: **líneas** padre-hijo, **círculos** con el valor, **actualización automática** al invalidar el panel, y **resaltado** del camino de búsqueda y del nodo encontrado (colores distintos, p. ej. naranja camino, verde encontrado).

---

## 1. Datos mock (independiente) 

```csharp
private static PosicionNodo[] MockPosiciones()
{
    return new[]
    {
        new PosicionNodo { Dato = 50, X = 200, Y = 40,  DatoPadre = null },
        new PosicionNodo { Dato = 30, X = 120, Y = 100, DatoPadre = 50 },
        new PosicionNodo { Dato = 70, X = 280, Y = 100, DatoPadre = 50 },
        new PosicionNodo { Dato = 20, X = 80,  Y = 160, DatoPadre = 30 },
    };
}
```

Define `PosicionNodo` igual que Rodrigo (copia temporal en tu rama o referencia al proyecto).

---

## 2. Evento `Paint` del `panelArbol`

En integración, el handler vivirá en `FormPrincipal`; mientras tanto puedes usar un formulario de prueba `FormTestDibujo` en tu rama **opcional**.

**Orden de dibujo recomendado**

1. Líneas entre padre e hijo (color gris o negro).
2. Círculos (`DrawEllipse`) rellenos o contorno.
3. `DrawString` centrado con el `Dato`.

**Constantes sugeridas**

```csharp
const int RadioNodo = 22;
```

---

## 3. Resaltado

Parámetros sugeridos para el método de dibujo:

```csharp
public static void DibujarArbol(
    Graphics g,
    PosicionNodo[] nodos,
    int[] caminoBusqueda,  // valores visitados en orden; mock: new[] { 50, 30 }
    int? encontrado        // null si no hay nodo encontrado; si no, el valor
)
```

- Si `caminoBusqueda` contiene un `Dato`, usar color de **camino** para ese círculo.
- Si `Dato == encontrado`, usar color **encontrado** (prioridad sobre camino).

---

## 4. Redibujado automático

Cada vez que Mario llame `panelArbol.Invalidate()` tras insertar, buscar o limpiar, debe ejecutarse `Paint` de nuevo. No uses botón “refrescar” manual como única forma de actualizar.

---

## 5. Integración (semana 3)

- Reemplazar `MockPosiciones()` por `CalculoPosiciones.Calcular(raiz, panelArbol.ClientSize.Width, panelArbol.ClientSize.Height)`.
- Obtener `caminoBusqueda` y `encontrado` desde el resultado de `Buscar` en `ArbolBST`.

---

## Criterios de aceptación

- Nodos circulares con valor visible
- Líneas conectan padre e hijo de forma coherente con `DatoPadre` o lógica equivalente
- Diferencia visual entre camino de búsqueda y nodo encontrado
- Dibujo se actualiza al invalidar el panel después de operaciones (en integración)
- Sin errores de `Graphics` por objetos `Dispose` (usar `using` o `e.Graphics` del Paint)
- PR con captura de pantalla del mock y luego del árbol integrado

---

## Pruebas manuales (documentar en el PR)


| Caso          | Entrada visual                      | Esperado                                      |
| ------------- | ----------------------------------- | --------------------------------------------- |
| Mock 4 nodos  | Paint inicial                       | 4 círculos + líneas                           |
| Camino        | camino `{50,30}`, encontrado `30`   | 50 y 30 resaltados; 30 con color “encontrado” |
| No encontrado | camino `{50,70}`, encontrado `null` | Solo camino resaltado                         |


---

## Entregables


| Archivo                                                       | Descripción                            |
| ------------------------------------------------------------- | -------------------------------------- |
| `Services/RenderizadoArbol.cs` (recomendado)                  | `DibujarArbol` y helpers               |
| Cambios en `FormPrincipal.cs`                                 | Suscripción a `Paint` (en integración) |
| `docs/ComponenteGrafico.md` en el repo del equipo (si aplica) | Decisiones de color y tamaño           |


---

## Declaración de uso de IA (en el PR)

`[../templates/declaracion-ia.md](../templates/declaracion-ia.md)`