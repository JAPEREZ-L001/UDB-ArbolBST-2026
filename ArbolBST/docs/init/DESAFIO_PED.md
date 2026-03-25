### **Imagen 1: Presentación y Enunciado**

**Tema 3 — Árbol BST**

Visualizador de Árbol Binario de Búsqueda: la regla es siempre menores a la izquierda, mayores a la derecha.

**Dificultad Media** (2 estrellas)

**ENUNCIADO DEL PROYECTO**

El estudiante desarrollará una aplicación que permita insertar números enteros y construir visualmente un **Árbol Binario de Búsqueda**. El árbol debe dibujarse dinámicamente en pantalla con nodos circulares y líneas que representen las conexiones entre nodos padre e hijo. El usuario podrá buscar un valor y ver el camino recorrido resaltado.

El árbol debe visualizarse correctamente distribuido por niveles, y cada operación de inserción o búsqueda debe reflejarse de inmediato en el dibujo sin necesidad de refrescar manualmente.

**ENTREGABLES**

1. **Código fuente completo en C#** (.sln y .csproj)
2. **Formulario Windows Forms** con árbol dibujado dinámicamente
3. **Defensa oral:** explicar la regla de inserción BST y demostrar la búsqueda

---

### **Imagen 2: Conceptos y Operaciones**

**¿Qué es un Árbol BST?**

Un **Árbol Binario de Búsqueda (BST)** organiza datos jerárquicamente. La regla: todo valor **menor al nodo va a la izquierda**, todo valor **mayor va a la derecha**. Esto permite buscar muy rápido sin recorrer todo.

- **Etiqueta del gráfico:** izquierda < nodo < derecha

**Operaciones Principales**

- **INSERT:** Inserta un nodo siguiendo la regla BST. ($O(\log n)$)
- **SEARCH:** Busca comparando en cada nivel. ($O(\log n)$)
- **INORDER:** Recorre produciendo valores ordenados. ($O(n)$)

---

### **Imagen 3: Diagrama de Flujo — Insertar**

**INSERT EN ÁRBOL BST — ¿DÓNDE VA CADA NODO?**

1. **INSERTAR VALOR**
2. **INICIO:** Insertar valor X
3. **¿Árbol vacío?**
  - **SÍ:** X es la raíz. FIN
    - **NO:** nodoActual = raíz
4. **¿X < nodoActual?**
  - **SÍ** $\rightarrow$ ir izquierda
    - **¿hijo izquierdo = nulo?**
      - **SÍ:** Insertar X como hijo izquierdo $\rightarrow$ **Redibujar árbol**
    - **NO en la dec anterior** $\rightarrow$ ir derecha, mismo proceso
5. **¿X = nodoActual?**
  - **SÍ:** Duplicado: ignorar

---

### **Imagen 4: Pseudocódigo y Requisitos**

**BST — Insertar y Buscar (Lógica)**

- **FUNCIÓN Insertar(nodo, valor)**
  - SI nodo = nulo $\rightarrow$ retornar nuevo nodo con valor
  - SI valor < nodo.dato $\rightarrow$ nodo.izquierda $\leftarrow$ Insertar(nodo.izquierda, valor)
  - SI NO SI valor > nodo.dato $\rightarrow$ nodo.derecha $\leftarrow$ Insertar(nodo.derecha, valor)
  - *// Si valor = nodo.dato: duplicado, no hacer nada*
  - retornar nodo
- **FUNCIÓN Buscar(nodo, valor)**
  - SI nodo = nulo $\rightarrow$ retornar "No encontrado"
  - SI valor = nodo.dato $\rightarrow$ retornar "Encontrado"
  - SI valor < nodo.dato $\rightarrow$ Buscar(nodo.izquierda, valor)
  - retornar Buscar(nodo.derecha, valor)

**Requisitos del Proyecto**

- **REQUISITO 1: Clase BST propia en C#.** Con Insert, Search, InOrder. Sin clases de árbol nativas.
- **REQUISITO 2: Dibujar el árbol con Graphics.** Nodos como círculos con valor, líneas de conexión, distribución por niveles.
- **REQUISITO 3: Botón INSERTAR.** Agrega un número y redibuja el árbol actualizado.
- **REQUISITO 4: Botón BUSCAR.** Resalta el camino recorrido hasta el nodo (o muestra que no existe).
- **REQUISITO 5: Resultado InOrden visible.** Mostrar los valores ordenados en un panel (resultado del recorrido InOrden).
- **REQUISITO 6: Árbol vacío y duplicados.** Manejar correctamente el primer nodo (raíz) y rechazar duplicados.

**PREGUNTA TÍPICA EN LA DEFENSA**

*"Si insertas 50, 30, 70, 20 — ¿dónde queda cada uno y por qué?"*

## **Rúbrica General de Evaluación**

*Aplica para todos los temas por igual. Nota máxima: **100 puntos** = 20% de la nota final.*

---

### **📋 DATOS DEL PROYECTO**


|                 |                                                                                                         |                  |                                |
| --------------- | ------------------------------------------------------------------------------------------------------- | ---------------- | ------------------------------ |
| **Duración**    | 3 semanas de desarrollo                                                                                 | **Defensa oral** | 10 minutos por equipo          |
| **Equipos**     | Máximo 2 personas                                                                                       | **Lenguaje**     | C# con Windows Forms + Drawing |
| **Restricción** | \No usar `Stack<T>`, `Queue<T>`, `Dictionary<T>` u otras estructuras nativas. Clase propia obligatoria. |                  |                                |


---

### **1. Implementación de la Estructura de Datos (35 pts)**

- **EXCELENTE (35 PTS):** Clase propia con todos los métodos requeridos funcionando correctamente. No usa ninguna clase nativa de C#.
- **BUENO (25 PTS):** Clase propia implementada. Algún método menor faltante o con un error leve que no afecta la funcionalidad principal.
- **REGULAR (15 PTS):** Usa clases nativas de C# o la implementación tiene errores importantes en la lógica de la estructura.

---

### **2. Visualización Gráfica con Drawing (25 pts)**

- **EXCELENTE (25 PTS):** La estructura se dibuja claramente y se actualiza en tiempo real con cada operación. Colores y etiquetas bien utilizados.
- **BUENO (18 PTS):** Visualización presente pero no siempre actualizada, o con algunos elementos faltantes en el dibujo.
- **REGULAR (10 PTS):** Visualización mínima o estática (dibujada una sola vez y no se actualiza al operar).

---

### **3. Funcionalidad de Botones y Operaciones (20 pts)**

- **EXCELENTE (20 PTS):** Todos los botones requeridos funcionan correctamente. Entradas validadas (campos vacíos, tipos incorrectos).
- **BUENO (14 PTS):** La mayoría de botones funcionan. Validación básica presente.
- **REGULAR (8 PTS):** Algunos botones funcionan. Sin validación de entradas.

---

### **4. Defensa Oral — Comprensión del Tema (15 pts)**

- **EXCELENTE (15 PTS):** Explica claramente qué es la estructura, cómo funciona y por qué la eligió para su problema. Responde con seguridad.
- **BUENO (10 PTS):** Explica con algunas dudas. Responde preguntas básicas aunque necesita ayuda en las más técnicas.
- **REGULAR (5 PTS):** No logra explicar con claridad cómo funciona la estructura que implementó.

---

### **5. Orden y Presentación del Código (5 pts)**

- **EXCELENTE (5 PTS):** Código limpio, comentado en partes clave y con nombres de variables descriptivos.
- **BUENO (3 PTS):** Código medianamente ordenado. Pocos comentarios pero funcional.
- **REGULAR (1 PT):** Código desorganizado, sin comentarios ni nombres descriptivos.



