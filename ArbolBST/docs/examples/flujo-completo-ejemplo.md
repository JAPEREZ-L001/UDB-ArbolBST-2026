# Ejemplo: un día de trabajo completo (BST)

Este archivo muestra cómo se vería el flujo real de **Mario** trabajando en `FormPrincipal` del visualizador BST. Úsalo como referencia para comparar con lo que tú estás haciendo.

---

## 1. Mario crea su carpeta en `work/`

Crea la carpeta (fecha de ejemplo):

```
docs/work/2026-03-24_ui-form-mario/
```

Dentro crea `notas.md` usando la plantilla [`../templates/notas-work.md`](../templates/notas-work.md):

```markdown
# Notas — ui-form-mario
**Fecha:** 2026-03-24
**Feature:** FormPrincipal + mocks de botones

## Objetivo del día
Dejar el formulario con todos los controles y validación de txtValor.

## Qué hice
- Coloqué controles según issue #4 (txtValor, btnInsertar, panelArbol, lblInOrden, lblMensaje).
- Implementé TryReadValor con mensajes de error.
- Conecté btnInsertar a mock + panelArbol.Invalidate().

## Qué falta
- Pulir tamaños y fuentes.
- Coordinar con Gabriel el handler Paint del panelArbol.

## Bloqueos
Ninguno: uso mocks, no espero a Josué.
```

---

## 2. Mario trabaja en Visual Studio

Edita `Forms/FormPrincipal.cs` y el diseñador. Commits pequeños:

```bash
git add ArbolBST/Forms/FormPrincipal.Designer.cs
git commit -m "feat: agrega panelArbol y botones INSERTAR BUSCAR INORDEN LIMPIAR"
```

```bash
git add ArbolBST/Forms/FormPrincipal.cs
git commit -m "feat: valida txtValor vacío y no numérico"
```

```bash
git add ArbolBST/Forms/FormPrincipal.cs
git commit -m "feat: mocks de insertar/buscar e Invalidate del panel"
```

> Commits pequeños y frecuentes: mejor que un solo commit gigante.

---

## 3. Antes del PR: actualizar con develop

```bash
git checkout develop
git pull origin develop
git checkout feature/ui-form-mario
git merge develop
git push
```

---

## 4. Mario abre el Pull Request en GitHub

Usa [`../templates/pull-request.md`](../templates/pull-request.md). Ejemplo:

```
Título: feat: formulario principal BST con validación y mocks

## Qué hace este PR
Agrega FormPrincipal con controles del issue #4, validación de entrada
y handlers mock hasta la integración con ArbolBST.

## Issue relacionado
Issue #4 — Mario Noubleou (Frontend)

## Cambios principales
- [x] FormPrincipal.cs — eventos y TryReadValor
- [x] FormPrincipal.Designer.cs — layout
- [x] FormPrincipal.resx

## Pruebas manuales
| Caso           | Entrada        | Esperado              | Resultado |
|----------------|----------------|------------------------|-----------|
| Vacío          | INSERTAR       | Mensaje rojo           | OK        |
| No numérico    | abc            | Mensaje rojo           | OK        |
| Mock insertar  | 10             | Mensaje mock + Invalidate | OK   |

## Declaración de uso de IA
- Herramienta: [si aplica]
- Revisión humana: Sí

## Checklist
- [x] Compila
- [x] Sin bin/obj/.vs
- [x] merge develop antes del PR
```

---

## 5. Josué revisa y pide un cambio

Ejemplo de comentario:

> "Renombra el TextBox a `txtValor` como en el issue; ahora figura como `textBox1`."

Mario corrige en el diseñador, commit y push:

```bash
git add ArbolBST/Forms/FormPrincipal.Designer.cs
git commit -m "fix: renombra TextBox a txtValor según issue #4"
git push
```

---

## 6. Josué aprueba y hace merge a develop

Mario actualiza su copia local:

```bash
git checkout develop
git pull origin develop
```

---

## 7. Qué queda en `work/`

```
docs/work/2026-03-24_ui-form-mario/
└── notas.md
```

La carpeta `work/` es personal; no sustituye la documentación del PR ni el código.

---

## Variante backend (Rodrigo)

Si eres **Rodrigo**, el flujo es el mismo (rama propia, commits, PR), pero editas `CalculoPosiciones.cs` y pruebas con un **árbol mock** en código en lugar de mocks de UI. Ver [`../issues/issue-03-rodrigo-joyal.md`](../issues/issue-03-rodrigo-joyal.md).
