# Issue #4 — Mario Noubleou · Frontend Lead (FormPrincipal)

**Asignado a:** Mario Noubleou  
**Rama:** `feature/ui-form-mario`  
**Área:** Frontend  
**Archivos:** `Forms/FormPrincipal.cs`, `FormPrincipal.Designer.cs`, `FormPrincipal.resx`  

> Puedes montar toda la UI y la validación de entrada usando **mocks** en los botones. **No** necesitas `ArbolBST` ni `CalculoPosiciones` listos para avanzar.

---

## Objetivo

Diseñar el **formulario principal** con todos los controles del enunciado, validar entradas (vacío, no numérico), y coordinar con **Gabriel** el evento de **redibujado** (`Invalidate` / `Paint`) tras insertar, buscar o limpiar.

---

## Controles requeridos (Diseñador de VS)

| Control | Tipo | Name (propiedad Name) | Text / notas |
|---------|------|----------------------|--------------|
| Entrada | `TextBox` | `txtValor` | Valor a insertar / buscar |
| Botón | `Button` | `btnInsertar` | `INSERTAR` |
| Botón | `Button` | `btnBuscar` | `BUSCAR` |
| Botón | `Button` | `btnInOrden` | `INORDEN` |
| Botón | `Button` | `btnLimpiar` | `LIMPIAR` |
| Área dibujo | `Panel` | `panelArbol` | `BackColor` claro; aquí pintará Gabriel |
| Salida InOrden | `Label` o `TextBox` ReadOnly | `lblInOrden` o `txtInOrden` | Muestra recorrido |
| Mensajes | `Label` | `lblMensaje` | Errores / éxito |

Opcional: `PictureBox` en lugar de `Panel` si el equipo prefiere; coordinar con Gabriel.

---

## Comportamiento con mocks (Días 1–4)

Hasta la integración, los handlers pueden hacer lo siguiente:

```csharp
private void btnInsertar_Click(object sender, EventArgs e)
{
    if (!TryReadValor(out int valor)) return;
    lblMensaje.Text = $"[MOCK] Insertar {valor}";
    lblMensaje.ForeColor = Color.DarkGreen;
    panelArbol.Invalidate(); // Gabriel escucha Paint
}

private void btnBuscar_Click(object sender, EventArgs e)
{
    if (!TryReadValor(out int valor)) return;
    lblMensaje.Text = valor == 50 ? "[MOCK] Encontrado" : "[MOCK] No encontrado";
    panelArbol.Invalidate();
}

private void btnInOrden_Click(object sender, EventArgs e)
{
    lblInOrden.Text = "[MOCK] 20, 30, 50, 70";
}

private void btnLimpiar_Click(object sender, EventArgs e)
{
    txtValor.Clear();
    lblInOrden.Text = "";
    lblMensaje.Text = "";
    panelArbol.Invalidate();
}

private bool TryReadValor(out int valor)
{
    valor = 0;
    if (string.IsNullOrWhiteSpace(txtValor.Text))
    {
        lblMensaje.ForeColor = Color.Red;
        lblMensaje.Text = "Ingrese un número.";
        return false;
    }
    if (!int.TryParse(txtValor.Text, out valor))
    {
        lblMensaje.ForeColor = Color.Red;
        lblMensaje.Text = "El valor debe ser un entero.";
        return false;
    }
    lblMensaje.Text = "";
    return true;
}
```

---

## Integración (semana 3)

- Sustituir mocks por instancia de `ArbolBST` (Josué / Paola).
- `btnInsertar` → `arbol.Insertar(valor)`
- `btnBuscar` → `arbol.Buscar(...)` y pasar a Gabriel la lista de nodos del **camino** para colores
- `btnInOrden` → texto desde Paola / Josué
- `btnLimpiar` → `arbol.Limpiar()`
- Tras cada operación: `panelArbol.Invalidate()`

---

## Coordinación con Gabriel

- Definir nombres de métodos o eventos: p. ej. `panelArbol_Paint` en `FormPrincipal` delega en `RenderizadoArbol.Dibujar(g, posiciones, caminoResaltado)`.
- Exponer propiedades públicas o internas que Gabriel necesite: `ArbolActual`, `CaminoBusqueda`, etc. (según arquitectura final).

---

## Criterios de aceptación

- [ ] Todos los controles con `Name` exactos o documentados en el PR
- [ ] Validación: vacío y no numérico muestran mensaje visible
- [ ] Los cuatro botones ejecutan lógica (mock o real)
- [ ] `panelArbol` se invalida tras operaciones que cambian el dibujo
- [ ] Interfaz legible y ordenada
- [ ] PR con captura de pantalla del formulario
- [ ] Revisión del código de Gabriel antes del PR final (acuerdo de equipo)

---

## Pruebas manuales (documentar en el PR)

| Caso | Acción | Esperado |
|------|--------|----------|
| Vacío | INSERTAR con txt vacío | Mensaje de error rojo |
| No número | texto `abc` | Mensaje de error |
| Mock insertar | número válido | Mensaje mock verde + Invalidate |
| Limpiar | LIMPIAR | Campos limpios |

---

## Entregables

| Archivo | Descripción |
|---------|-------------|
| `Forms/FormPrincipal.cs` | Lógica de eventos |
| `FormPrincipal.Designer.cs` | Generado por VS |
| `FormPrincipal.resx` | Recursos |

---

## Declaración de uso de IA (en el PR)

[`../templates/declaracion-ia.md`](../templates/declaracion-ia.md)
