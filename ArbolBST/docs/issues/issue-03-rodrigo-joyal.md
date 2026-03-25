# Issue #3 — Rodrigo Joyal · Backend (Posiciones para el dibujo)

**Asignado a:** Rodrigo Joyal  
**Rama:** `feature/bst-posiciones-rodrigo`  
**Área:** Backend  
**Archivos:** `Models/PosicionNodo.cs`, `Services/CalculoPosiciones.cs`  

> Trabaja con un **árbol mock (Un arbol de prueba)** construido a mano en código. **No** necesitas el `ArbolBST` terminado de Josué para desarrollar ni probar tu algoritmo.

---

## Objetivo

Calcular coordenadas `(X, Y)` de cada nodo para que el árbol se dibuje **por niveles**, sin solapamientos graves, y entregar un contrato claro para **Gabriel** (lista/arreglo de `PosicionNodo`).

---

## 1. `Models/PosicionNodo.cs`

```csharp
namespace ArbolBST.Models
{
    public class PosicionNodo
    {
        public int Dato { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        /// <summary>Opcional: para trazar líneas padre-hijo</summary>
        public int? DatoPadre { get; set; }
    }
}
```

---

## 2. Árbol mock para desarrollo independiente

Construye en `CalculoPosiciones` o en tests un árbol equivalente a insertar `50, 30, 70, 20`:

```csharp
// Ejemplo: raíz 50, hijo izq 30, hijo der 70, 20 hijo izq de 30
var raiz = new NodoBST(50);
raiz.Izquierda = new NodoBST(30);
raiz.Derecha = new NodoBST(70);
raiz.Izquierda.Izquierda = new NodoBST(20);
```

Usa la misma clase `NodoBST` que en el issue #1 (copia temporal en tu rama si hace falta).

---

## 3. `Services/CalculoPosiciones.cs`

**Responsabilidad:** dado `NodoBST raiz` y el tamaño del área de dibujo (`ancho`, `alto`), asignar `X`, `Y` a cada nodo.

**Sugerencia de algoritmo (simple y válido para el curso):**

1. Calcular **altura** del árbol (recursivo).
2. `Y` proporcional al nivel (nivel 0 arriba o abajo según convención del equipo; lo usual en WinForms es aumentar `Y` hacia abajo).
3. `X`: repartir el ancho disponible entre nodos del mismo nivel (puedes hacer un recorrido por nivel con cola **prohibida** — usa recursión y asignación por subárbol: “espacio izquierdo/derecho”).

Si no puedes usar cola, usa **recursión con retorno de subanchura** (técnica típica de layout de árboles).

**Firma orientativa**

```csharp
namespace ArbolBST.Services
{
    public static class CalculoPosiciones
    {
        public static PosicionNodo[] Calcular(NodoBST raiz, int anchoPanel, int altoPanel)
        {
            // Retornar arreglo propio o tamaño conocido; evitar List<T> si el equipo lo exige
            throw new System.NotImplementedException();
        }
    }
}
```

---

## 4. Contrato para Gabriel

Documentar en el PR:

- Orden del arreglo (por ejemplo: recorrido preorden o por niveles).
- Unidades: píxeles relativos al `Panel` / `PictureBox`.
- Cómo identificar padre para dibujar líneas (`DatoPadre` o segunda pasada).

---

## 5. Integración (semana 3)

Sustituir el árbol mock por `arbol.Raiz` (o getter acordado) del `ArbolBST` real de Josué. El tamaño del panel puede obtenerse de `panelArbol.ClientSize`.

---

## Criterios de aceptación

- `PosicionNodo` definido y usado
- Para el mock 50-30-70-20, hay **4 posiciones** sin coordenadas idénticas
- `Y` distingue niveles (profundidad)
- `X` separa subárbol izquierdo y derecho de forma visible
- Funciona con árbol de altura ≥ 4 en pruebas adicionales
- PR con capturas o tabla de coordenadas de prueba
- Sin depender del código de Gabriel para cerrar tu PR

---

## Pruebas manuales (documentar en el PR)


| Caso          | Entrada           | Esperado                                  |
| ------------- | ----------------- | ----------------------------------------- |
| Mock 4 nodos  | Árbol del ejemplo | 4 `PosicionNodo`, niveles distintos en Y  |
| Raíz null     | `null`            | Arreglo vacío o sin excepción             |
| Ancho pequeño | ancho 200         | Sin salirse del rango o documentar mínimo |


---

## Entregables


| Archivo                         | Descripción                                |
| ------------------------------- | ------------------------------------------ |
| `Models/PosicionNodo.cs`        | Modelo de posición                         |
| `Services/CalculoPosiciones.cs` | Algoritmo de layout                        |
| PR                              | Sección “Cómo consume Gabriel estos datos” |


---

## Declaración de uso de IA (en el PR)

`[../templates/declaracion-ia.md](../templates/declaracion-ia.md)`