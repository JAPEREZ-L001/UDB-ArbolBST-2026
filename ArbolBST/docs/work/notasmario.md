# Notas — ui-form-mario
**Fecha:** 2026-03-26
**Feature:** Interfaz FormPrincipal + validaciones + conexión con lógica

## Objetivo del día
Implementar una interfaz funcional del formulario principal que permita interactuar con el árbol BST y mejorar la estructura interna del código.

## Qué hice
- Diseñé la interfaz en FormPrincipal:
  - TextBox (txtValor)
  - Botones (Insertar, Buscar, Recorridos, Limpiar)
  - Panel para dibujar el árbol
- Validé la entrada de datos:
  - Campo vacío
  - Valores no numéricos
- Implementé eventos de botones:
  - Insertar
  - Buscar
  - Recorridos
- Conecté la UI con la lógica del árbol.
- Forcé el redibujado del panel usando Invalidate().
- Renombré controles siguiendo buenas prácticas.
- Agregué constructores en las clases del árbol para inicialización adecuada.
- Comenté todo el código para mejorar la legibilidad y mantenimiento.

## Qué falta
- Mejorar el diseño visual.
- Completar el dibujo del árbol en el panel.
- Afinar mensajes al usuario.

## Bloqueos
Ninguno.