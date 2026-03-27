# Issue #2 — Paola Carballo · Backend (InOrden y validaciones)

**Asignada a:** Paola Carballo  
**Rama:** `feature/bst-inorden-paola`  
**Área:** Backend  
**Archivos:** `Services/ArbolBST.Paola.cs` (clase parcial) o métodos que Josué integrará en `ArbolBST.cs`  

> Puedes trabajar **desde el Día 1** usando la definición de `NodoBST` de abajo. No necesitas esperar el PR de Josué para **escribir y probar** tu lógica en tu rama.

---

## Objetivo

Implementar el **recorrido InOrden** (valores ordenados) y las **validaciones** de negocio relacionadas: árbol vacío, intento de insertar duplicado (mensajes o flags que consuma la UI), y pruebas documentadas. Apoyar a **Rodrigo** (backend de posiciones) cuando tenga dudas sobre recorridos del árbol.

---

## Independencia: copia local de `NodoBST`

Pega temporalmente en tu rama (o referencia el del repo cuando exista):

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

## Descripción

### 1. InOrden

Implementar recorrido **izquierda → raíz → derecha** que produzca los valores en orden ascendente.

Opciones de salida (acordar con Mario en integración):

- `string` con valores separados por coma o espacio, p. ej. `"20, 30, 50, 70"`
- O método que reciba un `StringBuilder` o arreglo propio si el equipo evita colecciones genéricas

**Firma sugerida (partial class)**

```csharp
// ArbolBST.Paola.cs
namespace ArbolBST.Services
{
    public partial class ArbolBST
    {
        public string ObtenerInOrdenComoTexto()
        {
            // Implementar usando Raiz / acceso acordado con Josué
            throw new System.NotImplementedException();
        }
    }
}
```

> **Nota:** Si Josué aún no expuso `partial class`, trabaja en métodos `static` de prueba con `NodoBST raiz` y en integración se mueven a `ArbolBST`.

---

### 2. Validaciones

| Situación | Comportamiento esperado |
|-----------|-------------------------|
| Árbol vacío | InOrden devuelve cadena vacía o mensaje claro `"Árbol vacío"` |
| Insertar duplicado | No modificar el árbol; la UI puede mostrar mensaje (expón `bool` o excepción según convención del equipo) |

Documentar en comentarios cómo debe reaccionar `FormPrincipal` (Mario).

---

### 3. Pruebas en consola o formulario temporal

En tu rama, puedes crear un `FormTestPaola` temporal **no entregable** solo para probar, o pruebas manuales desde el depurador. Elimínalo o no lo merges si el equipo prefiere un solo formulario.

---

### 4. Mentoría a Rodrigo

Rodrigo recorre el árbol para posiciones: si te pregunta por niveles o recorridos, explica la relación entre **profundidad** y **coordenadas Y**.

---

## Criterios de aceptación

- [ ] InOrden correcto para árboles de al menos 7 nodos de prueba
- [ ] Caso árbol vacío manejado sin excepción
- [ ] Duplicados: comportamiento alineado con la implementación de Josué tras merge
- [ ] Código compila en tu rama (puede requerir stub mínimo de `ArbolBST` copiado del issue #1)
- [ ] PR con tabla de pruebas manuales

---

## Pruebas manuales (documentar en el PR)

| Caso | Árbol (inserciones) | InOrden esperado |
|------|---------------------|------------------|
| Vacío | — | Vacío o mensaje acordado |
| Un nodo | 50 | `50` |
| Varias | 50, 30, 70, 20 | `20, 30, 50, 70` |
| Duplicado | Insertar 50 dos veces | Misma salida que con uno |

---

## Entregables

| Archivo | Descripción |
|---------|-------------|
| `Services/ArbolBST.Paola.cs` o sección en `ArbolBST.cs` | InOrden + validaciones |
| Comentarios de integración | Qué debe llamar Mario desde el botón INORDEN |

---

## Declaración de uso de IA (en el PR)

[`../templates/declaracion-ia.md`](../templates/declaracion-ia.md)

