# Issue #1 — Josué López · Líder / Backend (BST núcleo)

**Asignado a:** Josué López  
**Rama:** `feature/bst-core-josue`  
**Área:** Backend  

---

## Objetivo

Crear el repositorio, la solución WinForms (.NET Framework 4.7.2), publicar `NodoBST` y la estructura de `ArbolBST` (stubs el **Día 1**) para que el equipo integre después, e implementar **Insertar**, **Buscar** (con registro del camino para el resaltado) e **InOrden** sin usar estructuras prohibidas por el enunciado en la lógica del árbol.

---

## Descripción

### 1. Setup del repositorio y la solución (Día 1 — primero)

**En GitHub**

1. Crear repositorio (ej. `UDB-ArbolBST-2026`)
2. `README.md` inicial
3. Rama `develop` desde `main`
4. Compartir enlace con el equipo

**En Visual Studio**

1. `File > New > Project > Windows Forms App (.NET Framework)`
2. Nombre sugerido: proyecto y solución `ArbolBST`
3. Framework: **.NET Framework 4.7.2**
4. Carpetas: `Models/`, `Services/`, `Forms/`

**Estructura objetivo**

```
UDB-ArbolBST-2026/
├── .gitignore
├── README.md
├── ArbolBST.sln
└── ArbolBST/
    ├── ArbolBST.csproj
    ├── Program.cs
    ├── Models/
    │   └── NodoBST.cs
    ├── Services/
    │   └── ArbolBST.cs
    └── Forms/
        ├── FormPrincipal.cs
        ├── FormPrincipal.Designer.cs
        └── FormPrincipal.resx
```

**`.gitignore` mínimo**

```
bin/
obj/
.vs/
*.user
*.suo
*.cache
```

---

### 2. `Models/NodoBST.cs` (Día 1)

```csharp
namespace ArbolBST.Models
{
    public class NodoBST
    {
        public int Dato;
        public NodoBST Izquierda;
        public NodoBST Derecha;

        public NodoBST(int dato)
        {
            Dato = dato;
            Izquierda = null;
            Derecha = null;
        }
    }
}
```

---

### 3. Stubs `Services/ArbolBST.cs` (Día 1 — publicar en `develop`)

Publicar firmas y cuerpos vacíos o mínimos para que compile. El equipo reemplazará la lógica contigo al integrar.

**Requisitos de implementación (Días 2–4)**

| Método | Comportamiento |
|--------|----------------|
| `Insertar(int valor)` | Regla BST; si el valor ya existe, **no insertar** (duplicado) |
| `Buscar(int valor, ...)` | Indicar si existe; además exponer el **camino** de valores visitados desde la raíz para que Gabriel resalte |
| InOrden | Producir salida ordenada ascendente (como `string` separado por comas o método que el equipo acuerde con Mario) |
| `Limpiar()` | Dejar árbol vacío |

**Pseudocódigo Insertar (referencia)**

```
Insertar(nodo, valor):
  si nodo es null → retornar new NodoBST(valor)
  si valor < nodo.Dato → nodo.Izquierda = Insertar(nodo.Izquierda, valor)
  si no, si valor > nodo.Dato → nodo.Derecha = Insertar(nodo.Derecha, valor)
  // si valor == nodo.Dato → duplicado: no hacer nada
  retornar nodo
```

**Para el camino de búsqueda:** cada vez que compares en un nodo, agrega `nodo.Dato` a una estructura acordada con el equipo (arreglo dinámico propio, `StringBuilder` con separadores, etc.) respetando la restricción de no usar `Stack<T>`, `Queue<T>`, `Dictionary<T>`.

---

### 4. `Program.cs`

Debe iniciar el formulario principal:

```csharp
Application.Run(new FormPrincipal());
```

---

### 5. Responsabilidades de liderazgo

- Revisar y aprobar PRs hacia `develop`
- Resolver conflictos de integración en la semana 3
- `develop` → `main` para entrega
- Mantener ramas fusionadas limpias

---

## Criterios de aceptación

- [ ] Repositorio con `main` y `develop`
- [ ] Solución compila desde el Día 1 con stubs
- [ ] `NodoBST` publicado según firma anterior
- [ ] `Insertar` respeta BST y **ignora duplicados**
- [ ] `Buscar` distingue encontrado / no encontrado y expone **camino** para la UI
- [ ] InOrden produce secuencia ordenada
- [ ] `Limpiar` reinicia el árbol
- [ ] Sin `Stack<T>`, `Queue<T>`, `Dictionary<T>` en la implementación del árbol (según enunciado)
- [ ] PR con pruebas manuales documentadas

---

## Pruebas manuales (documentar en el PR)

| Caso | Acción | Esperado |
|------|--------|----------|
| Raíz | Insertar `50` | Raíz = 50 |
| Izquierda / derecha | Insertar `30`, `70` | 30 izq de 50, 70 der |
| Duplicado | Insertar `50` otra vez | Árbol sin cambio |
| InOrden | Secuencia 50, 30, 70, 20 | Salida ordenada: 20, 30, 50, 70 |
| Buscar existente | Buscar `30` | Encontrado; camino incluye nodos visitados |
| Buscar inexistente | Buscar `99` | No encontrado; camino hasta hoja |

---

## Entregables

| Archivo | Descripción |
|---------|-------------|
| `ArbolBST.sln` | Solución |
| `Models/NodoBST.cs` | Nodo |
| `Services/ArbolBST.cs` | BST completo |
| `README.md` | Cómo clonar y compilar |

---

## Declaración de uso de IA (en el PR)

Usar la plantilla [`../templates/declaracion-ia.md`](../templates/declaracion-ia.md) o el bloque acordado por el equipo.
