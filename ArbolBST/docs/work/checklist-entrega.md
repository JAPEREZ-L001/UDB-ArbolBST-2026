# Checklist de entrega — Visualizador BST

Documento guía para cerrar el desafío. Cubre las tres últimas etapas del plan: pruebas manuales, empaquetado y defensa oral.

> Marca cada casilla con `[x]` al validar el caso. Reemplaza `_____` con el resultado real al ejecutar la app.

---

## 1. Pruebas manuales (Requisito de Issue #1)

Ejecuta la app desde Visual Studio (`F5`). Empieza con la portada y pulsa **Iniciar simulador**.

### 1.1 Casos funcionales

| # | Caso | Acción | Esperado | Resultado |
|---|------|--------|----------|-----------|
| 1 | Raíz | Insertar `50` | Nodo único en el panel, `lblMensaje` "Insertado: 50", `txtResultado` muestra `50` | `_____` |
| 2 | Hijos | Insertar `30`, `70` | `30` aparece a la izquierda de `50`, `70` a la derecha. `txtResultado`: `30, 50, 70` | `_____` |
| 3 | Profundidad | Insertar `20`, `40`, `60`, `80` | Árbol balanceado por nivel; `txtResultado`: `20, 30, 40, 50, 60, 70, 80` | `_____` |
| 4 | Duplicado | Insertar `50` otra vez | Sin cambios visuales. `lblMensaje` rojo "Duplicado: 50 ya existe..." | `_____` |
| 5 | Buscar existente | Buscar `40` | Camino resaltado `50 -> 30 -> 40`, nodo `40` en verde. `lblMensaje`: "Encontrado. Camino: 50, 30, 40" | `_____` |
| 6 | Buscar inexistente | Buscar `99` | Camino hasta hoja en rojo. `lblMensaje`: "No encontrado. Camino: 50, 70, 80" | `_____` |
| 7 | InOrden manual | Pulsar **InOrden** | `txtResultado` muestra valores ordenados | `_____` |
| 8 | Limpiar | Pulsar **Limpiar** | Panel vacío, `txtResultado` vacío, `lblMensaje`: "Árbol vaciado." | `_____` |
| 9 | Vacío + InOrden | Limpiar y luego pulsar **InOrden** | `txtResultado`: `Árbol vacío` | `_____` |

### 1.2 Validación de entrada

| # | Caso | Acción | Esperado | Resultado |
|---|------|--------|----------|-----------|
| 10 | Campo vacío | Pulsar **Insertar** sin texto | `lblMensaje` rojo: "Ingrese un valor numérico." | `_____` |
| 11 | Texto no numérico | Escribir `abc` y pulsar **Insertar** | `lblMensaje` rojo: "Ingrese un número entero válido." | `_____` |
| 12 | Negativos | Insertar `-5`, `-10`, `-1` | Se aceptan y se posicionan correctamente | `_____` |

### 1.3 Volumen y estabilidad

| # | Caso | Acción | Esperado | Resultado |
|---|------|--------|----------|-----------|
| 13 | Muchos nodos | Insertar `1, 2, 3, ..., 50` (degenerado) | Árbol se dibuja con escala automática; sin excepciones | `_____` |
| 14 | Redimensionar | Cambiar tamaño de la ventana con árbol cargado | El dibujo se recentra y reescala | `_____` |
| 15 | Atajos | Probar `F2` insertar, `F3` buscar, `F5` InOrden, `F9`/`Esc` limpiar | Cada atajo ejecuta su acción | `_____` |

### 1.4 Capturas para el PDF

Toma al menos cuatro capturas y guárdalas en esta misma carpeta `docs/work/`:

- [ ] `01-portada.png` — pantalla de portada con integrantes
- [ ] `02-arbol-insertar.png` — árbol con 50, 30, 70, 20, 40, 60, 80
- [ ] `03-buscar-encontrado.png` — nodo verde + camino naranja
- [ ] `04-buscar-no-encontrado.png` — camino en rojo

---

## 2. Empaquetado y entrega Git

### 2.1 Antes de mergear

- [ ] La app compila en Visual Studio (`Ctrl+Shift+B`) sin errores ni warnings nuevos.
- [ ] No hay `bin/`, `obj/` ni `.vs/` rastreados (`.gitignore` ya los excluye).
- [ ] Todos los integrantes tienen al menos un PR mergeado a `develop`.

### 2.2 Merge final (responsabilidad del líder, Josué)

```bash
git checkout develop
git pull
git checkout main
git pull
git merge --no-ff develop -m "release: entrega final desafío BST"
git push origin main
git tag v1.0 -m "Entrega final"
git push origin v1.0
```

### 2.3 Generar el ZIP

Excluye carpetas de build manualmente al comprimir. Desde PowerShell:

```powershell
cd C:\Users\japer\Desktop
Compress-Archive `
  -Path UDB-ArbolBST-2026\ArbolBST.sln, UDB-ArbolBST-2026\ArbolBST, UDB-ArbolBST-2026\README.md, UDB-ArbolBST-2026\.gitignore `
  -DestinationPath UDB-ArbolBST-2026-Entrega.zip `
  -Force
```

> Si el cmdlet `Compress-Archive` deja vacías las subcarpetas `bin/`, `obj/`, `.vs/`, bórralas a mano del proyecto **antes** de comprimir (no del repo, solo del directorio de trabajo).

### 2.4 PDF de entrega

Contenido sugerido (1–3 páginas):

1. Portada con integrantes, materia, ciclo, catedrático (la misma de `FormPortada`).
2. Descripción breve del proyecto y reglas BST.
3. Capturas de la sección 1.4.
4. Tabla resumen de pruebas manuales (sección 1.1).
5. Declaración de uso de IA (copiar de [`../templates/declaracion-ia.md`](../templates/declaracion-ia.md)).
6. Enlace al repositorio GitHub.

### 2.5 Declaración de IA

Cada integrante completa su bloque en el PR final, o se consolida uno en el PDF:

```
## Declaración de uso de IA
- Herramienta: __________
- Qué generó: __________
- Revisión humana: __________
```

---

## 3. Defensa oral (10 minutos)

### 3.1 Guion sugerido

| Tiempo | Sección | Quién | Contenido |
|--------|---------|-------|-----------|
| 0:00–1:00 | Presentación | Cualquiera | Integrantes y rol de cada uno |
| 1:00–2:30 | Concepto BST | Josué/Paola | Regla `izq < nodo < der`, complejidad O(log n) |
| 2:30–5:00 | Demo en vivo | Mario/Gabriel | Insertar `50, 30, 70, 20, 40, 60, 80`; mostrar InOrden ordenado |
| 5:00–7:00 | Buscar con camino | Cualquiera | Buscar `40` (encontrado) y `99` (no encontrado), explicar resaltado |
| 7:00–8:30 | Validaciones y duplicados | Cualquiera | Mostrar mensajes; explicar manejo del árbol vacío |
| 8:30–10:00 | Preguntas | Todos | Preparados para responder |

### 3.2 Pregunta típica del enunciado

> "Si insertas 50, 30, 70, 20 — ¿dónde queda cada uno y por qué?"

Respuesta modelo:

1. `50` es la raíz porque el árbol estaba vacío.
2. `30 < 50` → hijo izquierdo de `50`.
3. `70 > 50` → hijo derecho de `50`.
4. `20 < 50` → ir a la izquierda; `20 < 30` → hijo izquierdo de `30`.

Resultado:

```
        50
       /  \
      30   70
     /
    20
```

### 3.3 Otras preguntas frecuentes

- **¿Qué pasa con duplicados?** Se rechazan; la regla BST es estricta (`<` izq, `>` der).
- **¿Cómo recorrieron sin Stack/Queue?** Recursión + `StringBuilder` + arreglos propios dimensionados con `ContarNodos`.
- **¿Por qué InOrden produce orden ascendente?** Porque visita primero todo el subárbol izquierdo (menores), luego la raíz, luego el derecho (mayores).
- **¿Cómo dibujan el árbol?** `Graphics.DrawEllipse` para cada nodo, `Graphics.DrawLine` entre padre e hijo, posiciones calculadas en `CalcularPosiciones` por subárbol izquierdo/derecho con `offset` decreciente por nivel.

---

## 4. Resumen final

- [ ] Todas las pruebas de la sección 1 marcadas como exitosas.
- [ ] PR de entrega aprobado y mergeado a `main`.
- [ ] ZIP generado sin carpetas de build.
- [ ] PDF con capturas y declaración de IA.
- [ ] Defensa oral ensayada al menos una vez en equipo.
