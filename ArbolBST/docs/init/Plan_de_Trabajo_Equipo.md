# Plan de Trabajo — Visualizador de Árbol BST

**Proyecto:** Desafío de Programación con Estructura de Datos — Tema 3 (Árbol Binario de Búsqueda)  
**Repositorio sugerido:** `UDB-ArbolBST-2026` (nombre exacto lo define Josué)  
**Líder:** Josué López  
**Equipo:** Josué López · Paola Carballo · Rodrigo Joyal · Mario Noubleou · Gabriel Breucop  
**Stack:** C# · .NET Framework 4.7.2 · WinForms · `System.Drawing` · Git · GitHub  

**Restricción del enunciado:** no usar `Stack<T>`, `Queue<T>`, `Dictionary<T>` u otras estructuras de datos nativas para **implementar el BST**. La clase del árbol debe ser propia. Para la capa WinForms, si necesitan colecciones auxiliares para el dibujo o el camino de búsqueda, acordarlo con el docente; lo ideal es minimizar dependencias de colecciones genéricas en la lógica del árbol.

---

## ¿Por dónde empiezo?

**Paso 1 — Lee tu issue.** Tiene objetivos, mocks para trabajar en paralelo, criterios de aceptación y pruebas manuales.

| Miembro | Tu issue |
|---------|----------|
| Josué López | [`../issues/issue-01-josue-lopez.md`](../issues/issue-01-josue-lopez.md) |
| Paola Carballo | [`../issues/issue-02-paola-carballo.md`](../issues/issue-02-paola-carballo.md) |
| Rodrigo Joyal | [`../issues/issue-03-rodrigo-joyal.md`](../issues/issue-03-rodrigo-joyal.md) |
| Mario Noubleou | [`../issues/issue-04-mario-noubleou.md`](../issues/issue-04-mario-noubleou.md) |
| Gabriel Breucop | [`../issues/issue-05-gabriel-breucop.md`](../issues/issue-05-gabriel-breucop.md) |

**Paso 2 — Git.** Si es tu primera vez: [`../tutorials/01-git-desde-cero.md`](../tutorials/01-git-desde-cero.md)

**Paso 3 — Rama y commits.** Plantillas: [`../templates/commit.md`](../templates/commit.md), [`../templates/pull-request.md`](../templates/pull-request.md)

**Paso 4 — Ejemplo de un día completo:** [`../examples/flujo-completo-ejemplo.md`](../examples/flujo-completo-ejemplo.md)

---

## Mapa de la documentación

```
docs/
├── init/
│   ├── Plan_de_Trabajo_Equipo.md   ← estás aquí (plan de trabajo del equipo)
│   └── DESAFIO_PED.md              ← enunciado y rúbrica
├── issues/                         ← trabajo por persona
├── tutorials/
├── templates/
├── examples/
└── work/                           ← notas personales (opcional)
```

---

## Arquitectura del proyecto

```
UDB-ArbolBST-2026/
├── .gitignore
├── README.md
├── ArbolBST.sln
└── ArbolBST/
    ├── ArbolBST.csproj
    ├── Program.cs
    ├── Models/
    │   ├── NodoBST.cs              ← Josué (Día 1)
    │   └── PosicionNodo.cs         ← Rodrigo (backend)
    ├── Services/
    │   ├── ArbolBST.cs             ← Josué (stubs Día 1 → implementación)
    │   └── CalculoPosiciones.cs    ← Rodrigo (backend)
    └── Forms/
        ├── FormPrincipal.cs        ← Mario (frontend lead)
        ├── FormPrincipal.Designer.cs
        └── FormPrincipal.resx
```

**Dónde vive el dibujo:** Gabriel puede implementar `DibujarArbol` en `Services/RenderizadoArbol.cs` o como métodos coordinados con Mario en `FormPrincipal`. Contrato de datos: arreglo de `PosicionNodo` + datos del camino de búsqueda a resaltar.

---

## División Backend / Frontend

| Área | Personas | Responsabilidad principal |
|------|----------|---------------------------|
| **Backend** | Josué, Paola, Rodrigo | BST (insertar, buscar, InOrden), validaciones, cálculo de coordenadas por nivel |
| **Frontend** | Mario, Gabriel | Formulario, validación de entrada UI, `Paint`/Graphics, colores del camino |

---

## Principio: trabajo independiente + integración al final

Cada integrante puede avanzar en su rama **sin esperar** el código final de otro, usando **mocks** descritos en su issue. La **integración** (conectar mocks con código real) ocurre en la **semana 3**, coordinada por Josué.

| Persona | Independencia |
|---------|----------------|
| Paola | `NodoBST` inline en el issue; InOrden sin esperar a Josué |
| Rodrigo | Árbol mock hardcodeado para `CalcularPosiciones()` |
| Mario | Handlers mock en botones; `FormPrincipal` sin BST real |
| Gabriel | Posiciones mock para `DibujarArbol()` |

---

## Contratos públicos (orientativos)

### `ArbolBST` (Josué)

Métodos: insertar, buscar (con camino para resaltado), InOrden como texto o equivalente, limpiar. Ver issue #1.

### `CalculoPosiciones` (Rodrigo)

```csharp
public static PosicionNodo[] Calcular(NodoBST raiz, int anchoPanel, int altoPanel);
```

### `PosicionNodo` (Rodrigo)

Propiedades mínimas: `Dato`, `X`, `Y` (y opcional `DatoPadre` para líneas).

---

## Ramas de trabajo

```
main
└── develop
    ├── feature/bst-core-josue
    ├── feature/bst-inorden-paola
    ├── feature/bst-posiciones-rodrigo
    ├── feature/ui-form-mario
    └── feature/graphics-gabriel
```

| Rama | Merge a `develop` |
|------|-------------------|
| `main` | Solo Josué (entrega) |
| `develop` | Josué, vía PR aprobado |

---

## Cronograma (15 días hábiles)

### Semanas 1 y 2 — Desarrollo paralelo

| Día | Josué (backend) | Paola (backend) | Rodrigo (backend) | Mario (frontend) | Gabriel (frontend) |
|-----|------------------|-----------------|-------------------|------------------|-------------------|
| 1 | Repo + `NodoBST` + stub `ArbolBST` → `develop` | Rama + InOrden borrador | `PosicionNodo` + árbol mock | Layout `FormPrincipal` | Form prueba + posiciones mock |
| 2 | `Insertar()` | InOrden completo | X,Y nivel raíz (mock) | Controles UI | `DrawEllipse` mock |
| 3 | `Buscar()` + camino | Validación vacío | Niveles 1–2 (mock) | Handlers mock | Líneas mock |
| 4 | PR BST | PR validaciones | PR `CalcularPosiciones` | PR form + validación | PR resaltado mock |
| 5 | Review + merge | — | — | — | — |
| 6–7 | Ajustes / review | Docs | Árbol profundo | Pulido UI | Colores encontrado |
| 8–10 | Merge limpio en `develop` | — | — | PR dibujo completo | — |

### Semana 3 — Integración

| Día | Actividades |
|-----|-------------|
| 11 | Conectar formulario a `ArbolBST` real; posiciones reales; dibujo integrado |
| 12 | Pruebas integradas |
| 13 | Limpieza, `develop` → `main`, empaquetado |
| 14 | Ensayo defensa (10 min) |
| 15 | Entrega `.zip` + PDF + evidencia GitHub |

---

## Criterios para aprobar un PR

- [ ] Compila sin errores
- [ ] Cumple el issue correspondiente
- [ ] Pruebas manuales en el PR
- [ ] Sin `bin/`, `obj/`, `.vs/` en el commit
- [ ] Declaración de IA si aplica ([`../templates/declaracion-ia.md`](../templates/declaracion-ia.md))

---

## Enlaces en esta carpeta

| Archivo | Uso |
|---------|-----|
| [`DESAFIO_PED.md`](DESAFIO_PED.md) | Enunciado, requisitos y rúbrica |
| **Plan_de_Trabajo_Equipo.md** (este archivo) | Planificación del equipo, issues y cronograma |

Guía ampliada del equipo (opcional): `../../DESAFIO_PED_GuiaDeEquipo (1).md`

---

*Versión 1.0 — plan de trabajo alineado a documentación por issues y trabajo en paralelo con mocks.*
