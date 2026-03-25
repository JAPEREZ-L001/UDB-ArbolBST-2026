# Tutorial 04 — Declaración de uso de IA

---

## ¿Qué es?

Es una sección que va dentro de cada Pull Request donde declaras honestamente si usaste alguna herramienta de IA (ChatGPT, Copilot, Claude, etc.) para generar o completar código.

---

## ¿Por qué es obligatoria?

- Transparencia académica: el equipo y el instructor saben qué fue código propio y qué fue asistido.
- No está prohibido usar IA, pero sí está prohibido ocultarlo.
- Si no usaste IA en ese PR, igual lo declaras: "No usé IA en este PR."

---

## ¿Cuándo aplica?

Siempre que:
- Una IA generó parte del código que estás subiendo
- Una IA te ayudó a resolver un bug específico
- Una IA generó el esqueleto de una clase o función

No aplica si:
- Solo usaste autocompletado básico del IDE (IntelliSense de Visual Studio)
- Buscaste la solución en Stack Overflow o la documentación oficial

---

## ¿Dónde va?

Dentro del PR, en la sección **Declaración de uso de IA** de la plantilla.

Ver: `docs/templates/declaracion-ia.md`

---

## Ejemplo real (Khaterine, FormRegistro)

Situación: Khaterine usó GitHub Copilot para generar el esqueleto del event handler del botón de registro.

Así queda la declaración en el PR:

```markdown
## Declaración de uso de IA

- **Herramienta:** GitHub Copilot
- **Qué generó:** el esqueleto inicial del método `btnRegistrar_Click`, incluyendo la
  estructura del try-catch y la llamada a `_arbol.Insertar(est)`
- **Revisión humana:** Sí — se ajustaron los mensajes de error para que digan el carnet
  afectado, se agregó la validación de rango de promedio (0–10) que Copilot no incluyó,
  y se corrigió el tipo de dato de `txtCarnet` (Copilot usó `int.Parse` sin manejo de
  excepción, se cambió a `int.TryParse`)
```

---

## Ejemplo cuando NO usaste IA

```markdown
## Declaración de uso de IA

No usé herramientas de IA en este PR. El código fue escrito manualmente.
```

---

## Resumen

| Campo             | Qué escribir                                          |
|-------------------|-------------------------------------------------------|
| Herramienta       | Nombre exacto (Copilot, ChatGPT, Claude, etc.)        |
| Qué generó        | Sé específico: función, clase, bloque de código       |
| Revisión humana   | Qué cambiaste, qué verificaste, qué corregiste        |
