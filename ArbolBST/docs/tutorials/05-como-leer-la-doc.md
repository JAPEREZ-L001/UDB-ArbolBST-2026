# Tutorial 05 — Cómo leer la documentación sin abrumarse

---

## La regla de oro

**Lee solo lo que necesitas en este momento.** No tienes que leer todo antes de empezar.

---

## Guía de 5 pasos

### Paso 1 — Empieza por tu issue

Lee únicamente el archivo que corresponde a tu issue:

| Quién             | Archivo                                      |
|-------------------|----------------------------------------------|
| Josué López       | `docs/issues/issue-01-josue-lopez.md`      |
| Paola Carballo    | `docs/issues/issue-02-paola-carballo.md`   |
| Rodrigo Joyal     | `docs/issues/issue-03-rodrigo-joyal.md`    |
| Mario Noubleou    | `docs/issues/issue-04-mario-noubleou.md`   |
| Gabriel Breucop   | `docs/issues/issue-05-gabriel-breucop.md`  |

Tu issue tiene todo lo que necesitas: qué hacer, qué archivos crear, qué controles poner, y qué métodos implementar.

---

### Paso 2 — Sigue el flujo de trabajo cuando vayas a hacer commit o PR

Cuando termines algo y quieras guardarlo:

1. `docs/templates/commit.md` → formato del mensaje de commit
2. `docs/tutorials/01-git-desde-cero.md` → si es la primera vez con Git
3. `docs/tutorials/03-pr-en-github.md` → cuando vayas a abrir el PR
4. `docs/templates/pull-request.md` → para llenar el formulario del PR

---

### Paso 3 — Usa las plantillas, no las inventes

Las plantillas están vacías y listas para rellenar. No pierdas tiempo creando formato:

| Necesitas                     | Plantilla                               |
|-------------------------------|-----------------------------------------|
| Escribir un commit            | `docs/templates/commit.md`              |
| Abrir un PR                   | `docs/templates/pull-request.md`        |
| Declarar uso de IA            | `docs/templates/declaracion-ia.md`      |
| Tomar notas en work/          | `docs/templates/notas-work.md`          |

---

### Paso 4 — Consulta tutorials solo si te atascas

Si algo no te sale, busca en los tutoriales:

| Problema                              | Tutorial                              |
|---------------------------------------|---------------------------------------|
| Primera vez con Git                   | `01-git-desde-cero.md`                |
| Algo salió mal con Git                | `02-problemas-git.md`                 |
| No sé cómo abrir un PR                | `03-pr-en-github.md`                  |
| No sé cómo llenar la declaración de IA| `04-declaracion-ia.md`                |

---

### Paso 5 — Si nada funciona, pregunta a Josué

Josué es el líder del proyecto. Pero primero:
1. ¿Revisaste tu issue completo?
2. ¿Revisaste el tutorial correspondiente?
3. ¿Revisaste `docs/examples/flujo-completo-ejemplo.md`?

Si la respuesta es sí a los 3, entonces pregunta.

---

## Mapa rápido: ¿qué archivo leer en cada situación?

```
"¿Qué tengo que hacer?"         → docs/issues/issue-0X-tu-nombre.md
"¿Cómo hago un commit?"         → docs/templates/commit.md
"¿Cómo abro un PR?"             → docs/tutorials/03-pr-en-github.md
"Git me dio un error"           → docs/tutorials/02-problemas-git.md
"¿Cómo se ve un día de trabajo?"→ docs/examples/flujo-completo-ejemplo.md
"Primera vez con Git"           → docs/tutorials/01-git-desde-cero.md
"¿Dónde dejo mis notas?"        → docs/work/ + docs/templates/notas-work.md
```
