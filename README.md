# UDB-ArbolBST-2026

Simulador y visualizador de **Árbol Binario de Búsqueda (BST)** desarrollado en **C# · .NET Framework 4.7.2 · Windows Forms** para el curso **Programación con Estructuras de Datos** (Grupo G01T) de la Universidad Don Bosco.

La aplicación permite insertar enteros, dibujar el árbol en tiempo real con nodos circulares y líneas de conexión, buscar valores resaltando el camino recorrido y mostrar el recorrido **InOrden** en orden ascendente.

---

## Características

| Requisito | Descripción |
|-----------|-------------|
| BST propio | Clase `ArbolBST` con `Insertar`, `Buscar`, `ObtenerInOrdenComoTexto` y `Limpiar` — sin `Stack<T>`, `Queue<T>` ni `Dictionary<T>` en la lógica del árbol |
| Visualización | Dibujo con `System.Drawing` (`Graphics`): círculos, líneas padre-hijo, escala automática al redimensionar |
| Insertar | Botón y atajo `F2`; redibuja al instante; rechaza duplicados |
| Buscar | Botón y atajo `F3`; resalta camino (naranja), nodo encontrado (verde) o camino sin resultado (rojo) |
| InOrden | Panel de texto con valores ordenados; se actualiza al insertar |
| Validaciones | Campo vacío, no numérico, árbol vacío y duplicados con mensajes en `lblMensaje` |
| Portada | Pantalla de inicio con integrantes, materia y acceso al simulador |

---

## Requisitos del sistema

- **Windows** 10 o superior
- **Visual Studio 2022** o **2019** con la carga de trabajo **Desarrollo de escritorio con .NET**
- **.NET Framework 4.7.2** (incluido en el perfil de WinForms de Visual Studio)

---

## Instalación y ejecución

```bash
git clone https://github.com/JAPEREZ-L001/UDB-ArbolBST-2026.git
cd UDB-ArbolBST-2026
```

1. Abrir `ArbolBST.sln` en Visual Studio.
2. Compilar: **Ctrl+Shift+B**
3. Ejecutar: **F5**

La aplicación inicia en la **portada** del equipo. Pulsa **Iniciar simulador** para abrir el formulario principal.

### Atajos de teclado

| Tecla | Acción |
|-------|--------|
| `F2` | Insertar |
| `F3` | Buscar |
| `F5` | Mostrar InOrden |
| `F9` / `Esc` | Limpiar árbol |
| `Enter` (en el campo valor) | Insertar |

---

## Uso rápido

1. Escribe un **entero** en el campo *Valor*.
2. Pulsa **Insertar** — el nodo aparece en el panel derecho según la regla BST (`izquierda < nodo < derecha`).
3. Pulsa **Buscar** para localizar un valor; el camino se colorea en el dibujo.
4. El panel **Recorrido InOrden** muestra los valores en orden ascendente.
5. **Limpiar** vacía el árbol y reinicia el panel.

**Ejemplo para la defensa:** insertar `50`, `30`, `70`, `20` y buscar `30` (encontrado) y `99` (no encontrado).

---

## Estructura del proyecto

```
UDB-ArbolBST-2026/
├── ArbolBST.sln
├── README.md
├── .gitignore
└── ArbolBST/
    ├── Program.cs                 # Arranque en FormPortada
    ├── Models/
    │   └── NodoBST.cs             # Nodo del árbol (dato, izq, der)
    ├── Services/
    │   └── ArbolBST.cs            # BST, posiciones y camino de búsqueda
    ├── Forms/
    │   ├── FormPortada.cs         # Pantalla de inicio
    │   ├── FormPrincipal.cs       # Simulador (UI + Paint)
    │   └── Shortcuts.cs           # Atajos de teclado
    ├── Resources/
    │   └── logo_udb.jpg
    └── docs/                      # Documentación del equipo (ver abajo)
        ├── init/                  # Enunciado y plan de trabajo
        ├── issues/                # Tareas por integrante
        ├── tutorials/             # Git, PR, declaración IA
        ├── templates/
        ├── work/
        └── guion-demo.md          # Guion de exposición (7–10 min)
```

---

## Equipo y responsabilidades

| Integrante | Carnet | Área | Contribución principal |
|------------|--------|------|------------------------|
| Josué Adonaí Pérez López | PL250205 | Backend / Líder | Núcleo BST: insertar, buscar, integración |
| Paola Elizabeth Carballo Quijada | CQ250338 | Backend | InOrden, validaciones de negocio |
| Rodrigo Abel Joyar González | JG251114 | Backend | Cálculo de posiciones (X, Y) para el dibujo |
| Mario Alejandro Noubleau Callejas | NC250266 | Frontend | `FormPrincipal`, validación de entrada UI |
| Gabriel Ernesto López Breucop | LB250311 | Frontend | Dibujo con `Graphics`, colores del camino |

**Catedrático:** Ing. Rafael Torres Rodríguez

---

## Documentación

La carpeta [`ArbolBST/docs/`](ArbolBST/docs/) contiene el material de planificación y entrega del equipo:

| Recurso | Descripción |
|---------|-------------|
| [`docs/init/DESAFIO_PED.md`](ArbolBST/docs/init/DESAFIO_PED.md) | Enunciado oficial y rúbrica |
| [`docs/init/Plan_de_Trabajo_Equipo.md`](ArbolBST/docs/init/Plan_de_Trabajo_Equipo.md) | Cronograma, ramas e issues |
| [`docs/guion-demo.md`](ArbolBST/docs/guion-demo.md) | Guion de defensa oral (7–10 min) |
| [`docs/work/checklist-entrega.md`](ArbolBST/docs/work/checklist-entrega.md) | Pruebas manuales y empaquetado |
| [`docs/issues/`](ArbolBST/docs/issues/) | Especificación por integrante |

---

## Ramas Git

| Rama | Uso |
|------|-----|
| `main` | Versión estable para entrega |
| `develop` | Integración de features del equipo |

Flujo recomendado: rama `feature/*` → PR a `develop` → merge a `main` para la entrega final.

---

## Restricciones del enunciado

En la implementación del **árbol** no se utilizan colecciones genéricas prohibidas (`Stack<T>`, `Queue<T>`, `Dictionary<T>`). El recorrido y el camino de búsqueda usan **recursión**, `StringBuilder` y arreglos dimensionados con `ContarNodos`.

> La capa de interfaz (`Shortcuts.cs`) puede usar `Dictionary` y `List` solo para atajos de teclado, fuera de la lógica del BST.

---

## Declaración de uso de IA

| Ámbito | Uso de IA |
|--------|-----------|
| **Código de la aplicación** (`Models/`, `Services/`, `Forms/`, etc.) | Desarrollado por el equipo en Visual Studio, sin generación automática de la lógica del BST ni de la UI principal |
| **Carpeta `ArbolBST/docs/`** | **Cursor Agent** se utilizó únicamente para crear y organizar esta documentación: enunciados replicados, plan de trabajo, issues, tutoriales, plantillas, [`guion-demo.md`](ArbolBST/docs/guion-demo.md) y [`checklist-entrega.md`](ArbolBST/docs/work/checklist-entrega.md) |

El equipo revisó y adaptó el contenido de `docs/` antes de integrarlo al repositorio.

---

## Licencia y contexto académico

Proyecto académico — **Universidad Don Bosco**, Programación con Estructuras de Datos, 2026.  
Uso educativo; consultar al catedrático antes de redistribuir fuera del curso.
