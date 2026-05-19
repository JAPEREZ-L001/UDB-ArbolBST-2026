# Guion de demo — Visualizador BST (defensa oral)

**Duración objetivo:** 9 minutos · **Máximo permitido:** 10 minutos  
**Materia:** Programación con Estructuras de Datos · Grupo G01T  
**Herramienta:** aplicación WinForms ya compilada (`ArbolBST.exe`)

> Ensayen con cronómetro. Si van por encima de 9:30, acorten la sección 4 (Rodrigo) o la 7 (cierre). Dejen **1 minuto de colchón** para una pregunta breve del catedrático.

---

## Reparto por integrante

| Integrante | Rol en el proyecto | Tiempo aprox. | Bloques |
|------------|-------------------|---------------|---------|
| **Mario Noubleou** | Frontend · `FormPrincipal` | 1 min 15 s | Apertura + validación UI |
| **Josué Pérez López** | Líder · núcleo BST | 2 min 30 s | Concepto + inserción en vivo |
| **Paola Carballo** | Backend · InOrden y validaciones | 1 min 45 s | Recorrido, duplicados, vacío |
| **Rodrigo Joyar** | Backend · posiciones del dibujo | 1 min 15 s | Cómo se distribuye el árbol en pantalla |
| **Gabriel Breucop** | Frontend · dibujo y resaltado | 2 min | Búsqueda con camino coloreado |
| **Todos** | Cierre coordinado | 30 s | Despedida y ofrecer preguntas |

**Total hablado:** ~9 min · **Colchón:** hasta 10 min

---

## Antes de subir a exponer (2 minutos, no cuentan en los 10)

- [ ] Proyector conectado; resolución mínima 1280×720.
- [ ] App abierta en la **portada** (no en el simulador todavía).
- [ ] Árbol **limpio** (si ensayaron antes, pulsar **Limpiar**).
- [ ] Valores de la demo anotados en un post-it: `50 → 30 → 70 → 20 → 40 → 60 → 80` · buscar `30` y `99`.
- [ ] Solo **una persona** maneja el mouse; los demás hablan sin tocar la PC.

---

## Bloque A — Apertura (0:00 – 1:15) · **Mario**

**Pantalla:** Portada del simulador.

**Qué decir:**

> Buenas [tardes/noches], catedrático [Torres] y compañeros. Somos el grupo G01T de Programación con Estructuras de Datos.  
> Presentamos el **Simulador de Árbol Binario de Búsqueda** para la Universidad Don Bosco.  
> El equipo está integrado por: Mario Noubleou, Josué Pérez López, Paola Carballo, Rodrigo Joyar y Gabriel Breucop.  
> Yo, Mario, me encargué del formulario principal: controles, validación de entrada y la coordinación con el panel donde se dibuja el árbol.  
> Ahora Josué les explicará qué es un BST y comenzará la demostración.

**Acción en pantalla:**

1. Señalar brevemente la portada (integrantes y materia).
2. Clic en **Iniciar simulador**.

**Pase la palabra a:** Josué.

---

## Bloque B — Concepto y primera inserción (1:15 – 3:45) · **Josué**

**Pantalla:** `FormPrincipal` vacío.

**Qué decir:**

> Un **árbol binario de búsqueda** organiza enteros con una regla simple: todo valor **menor** va a la **izquierda** y todo valor **mayor** a la **derecha**.  
> Eso permite buscar sin recorrer todos los datos; en promedio es **O(log n)** si el árbol está balanceado.  
> Nosotros implementamos la estructura **desde cero** en C#: clase `NodoBST` y servicio `ArbolBST`, **sin** usar `Stack`, `Queue` ni `Dictionary` en la lógica del árbol, según el enunciado.  
> Voy a insertar la secuencia del ejemplo clásico del proyecto: **50, 30, 70 y 20**.

**Acción en pantalla (hablar mientras inserta):**

| Valor | Qué decir al insertar |
|-------|------------------------|
| `50` | «El árbol estaba vacío; **50** queda como **raíz**.» |
| `30` | «**30** es menor que 50 → va a la **izquierda**.» |
| `70` | «**70** es mayor que 50 → va a la **derecha**.» |
| `20` | «**20** es menor que 50, vamos a la izquierda; **20** es menor que 30 → queda como hijo izquierdo de 30.» |

**Señalar:** panel derecho (dibujo) y `txtResultado` que ya muestra el InOrden actualizado.

> Fíjense que el recorrido ordenado aparece abajo sin pulsar otro botón: eso lo implementó Paola con el recorrido **InOrden**.

**Pase la palabra a:** Paola.

---

## Bloque C — InOrden, duplicados y árbol vacío (3:45 – 5:30) · **Paola**

**Pantalla:** Árbol con 50, 30, 70, 20.

**Qué decir:**

> El recorrido **InOrden** visita: subárbol izquierdo, raíz, subárbol derecho. Por la regla del BST, eso produce los valores en **orden ascendente**.  
> Con lo insertado deberíamos ver: **20, 30, 50, 70**.

**Acción:**

1. Señalar `txtResultado` (debe coincidir). Si hace falta, pulsar **InOrden** una vez y confirmar en voz alta.
2. Insertar `50` otra vez.

> Si intentamos un **duplicado**, el árbol **no cambia**. El mensaje en rojo indica que el valor ya existe; la inserción devuelve `false` y no altera la estructura.

3. Pulsar **Limpiar**.

> Al limpiar, reiniciamos la raíz a `null`. Si pedimos InOrden con el árbol vacío, el sistema muestra **"Árbol vacío"**.

**Acción:** pulsar **InOrden** con el panel vacío; mostrar el texto.

4. Volver a insertar solo `50`, `30`, `70` (rápido, sin 20) para dejar el árbol listo para Rodrigo y Gabriel.

> «Dejo el árbol preparado; Rodrigo explica cómo calculamos las coordenadas del dibujo.»

**Pase la palabra a:** Rodrigo.

---

## Bloque D — Distribución visual del árbol (5:30 – 6:45) · **Rodrigo**

**Pantalla:** Árbol con al menos 50, 30, 70 (idealmente también 20).

**Qué decir:**

> Para que Gabriel y Mario puedan pintar, el backend calcula la posición **X, Y** de cada nodo antes del evento `Paint`.  
> Usamos un arreglo de `PosicionNodo` con el dato y las referencias a hijos izquierdo y derecho para trazar las líneas.  
> La **Y** aumenta por nivel hacia abajo; la **X** se reparte con un **offset** que se divide a la mitad en cada nivel — técnica recursiva, sin cola, respetando la restricción del curso.  
> El formulario **escala y centra** el dibujo si cambiamos el tamaño de la ventana.

**Acción:**

1. Señalar un nodo y su línea hacia el hijo.
2. Redimensionar ligeramente la ventana (2–3 segundos) para mostrar que el árbol se reajusta.

> «Con esto el árbol no se solapa de forma grave en los casos de la materia. Gabriel muestra la búsqueda con resaltado.»

**Pase la palabra a:** Gabriel.

---

## Bloque E — Búsqueda con camino resaltado (6:45 – 8:45) · **Gabriel**

**Pantalla:** Mismo árbol; si falta densidad, insertar rápido `40` y `60` (opcional, solo si van adelantados en tiempo).

**Qué decir:**

> La operación **Buscar** compara en cada nodo y registra el **camino** visitado. Ese camino lo pintamos con colores distintos en `Graphics`:  
> — **Naranja:** nodos del camino mientras buscamos.  
> — **Verde:** nodo **encontrado**.  
> — **Rojo:** camino cuando el valor **no existe**.

**Acción 1 — Buscar valor existente:**

1. Escribir `30` → **Buscar**.
2. Leer `lblMensaje`: «Encontrado. Camino: 50, 30» (o similar).
3. Señalar nodos resaltados en el panel.

> «Comparamos en 50, bajamos a la izquierda porque 30 es menor, y encontramos 30.»

**Acción 2 — Buscar valor inexistente:**

1. Escribir `99` → **Buscar**.

> «**99** no está: el camino muestra hasta dónde llegamos y el resaltado en rojo indica que no hubo coincidencia.»

**Pregunta típica del enunciado (15 s, si hay tiempo):**

> Si insertamos **50, 30, 70, 20**, cada uno va donde la regla lo manda: raíz 50; 30 a la izquierda; 70 a la derecha; 20 a la izquierda de 30. Eso es exactamente lo que ven en pantalla.

**Pase la palabra a:** Mario.

---

## Bloque F — Validación de entrada y cierre (8:45 – 9:30) · **Mario**

**Pantalla:** Simulador.

**Qué decir (validación, ~25 s):**

> En la interfaz validamos que el campo no esté vacío y que sea un **entero**. Los mensajes aparecen en `lblMensaje` sin bloquear la app con ventanas emergentes en cada acción.

**Acción (rápida):**

1. Borrar `txtValor` → **Insertar** → mostrar mensaje de error.
2. Escribir `abc` → **Insertar** → mostrar mensaje de valor inválido.

**Qué decir (cierre, ~20 s):**

> Con esto cumplimos insertar, buscar con camino visible, InOrden en panel, manejo de vacío y duplicados, y dibujo dinámico con `System.Drawing`.  
> Quedamos atentos a sus preguntas. Gracias.

**Todos:** asentir / quedarse de pie si el catedrático pregunta.

---

## Colchón y preguntas (9:30 – 10:00)

Usar solo si el catedrático pregunta en el mismo bloque de 10 minutos. Respuestas cortas (**máx. 20 s cada una**):

| Pregunta probable | Quién responde | Respuesta clave |
|-----------------|----------------|-----------------|
| ¿Por qué InOrden ordena? | Paola | Izquierda → raíz → derecha; izquierda tiene menores. |
| ¿Duplicados? | Josué | No se insertan; `valor == nodo` no modifica el árbol. |
| ¿Sin Stack ni Queue? | Josué | Recursión + `StringBuilder` + arreglos con tamaño `ContarNodos`. |
| ¿Cómo dibujan líneas y círculos? | Gabriel | `DrawLine` entre padre e hijo; `DrawEllipse` + texto centrado. |
| ¿Complejidad de insertar/buscar? | Josué | O(log n) promedio; O(n) peor caso si el árbol degenera. |

Si no hay preguntas, **terminar a los 9:30** y no rellenar con más demo.

---

## Diagrama de referencia (decir en voz alta en el bloque B o E)

```
        50
       /  \
      30   70
     /
    20
```

Tras insertar también `40` y `60` (opcional en ensayo):

```
        50
       /  \
      30   70
     /  \  / \
   20  40 60  80
```

---

## Checklist rápido por persona

**Mario**

- [ ] Presentar al equipo y abrir el simulador.
- [ ] Demo de validación vacío / no numérico.
- [ ] Cierre de 20 segundos.

**Josué**

- [ ] Explicar regla BST y restricción sin colecciones nativas en el árbol.
- [ ] Insertar 50, 30, 70, 20 narrando cada paso.
- [ ] Responder preguntas técnicas de estructura.

**Paola**

- [ ] Explicar InOrden y mostrar texto ordenado.
- [ ] Demostrar duplicado y árbol vacío.

**Rodrigo**

- [ ] Explicar X/Y por nivel y offset recursivo.
- [ ] Redimensionar ventana una vez.

**Gabriel**

- [ ] Buscar 30 (encontrado) y 99 (no encontrado).
- [ ] Nombrar colores del camino.

---

## Enlaces útiles

- Enunciado y rúbrica: [`init/DESAFIO_PED.md`](init/DESAFIO_PED.md)
- Pruebas manuales detalladas: [`work/checklist-entrega.md`](work/checklist-entrega.md)
- Plan del equipo: [`init/Plan_de_Trabajo_Equipo.md`](init/Plan_de_Trabajo_Equipo.md)

---

*Versión 1.0 — guion para defensa oral de 7–10 minutos con participación equitativa de los cinco integrantes.*
