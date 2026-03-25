# Tutorial 03 — Cómo abrir un Pull Request en GitHub

---

## Antes de abrir el PR

1. Asegúrate de que tu rama está actualizada con `develop`:
   ```bash
   git checkout develop && git pull origin develop
   git checkout feature/mi-feature
   git merge develop
   git push origin feature/mi-feature
   ```

2. Verifica que el proyecto compila sin errores en Visual Studio.

---

## Pasos en GitHub

### Paso 1 — Ir al repositorio
Abre: `https://github.com/[usuario]/UDB-ArbolBST-2026` (o el nombre real del repo BST)

---

### Paso 2 — Ir a Pull Requests
Clic en la pestaña **Pull requests** (barra superior del repositorio).

---

### Paso 3 — New Pull Request
Clic en el botón verde **New pull request**.

---

### Paso 4 — Seleccionar ramas

| Campo       | Valor                         |
|-------------|-------------------------------|
| **base**    | `develop`                     |
| **compare** | `feature/nombre-de-tu-feature`|

> IMPORTANTE: la base siempre es `develop`, nunca `main`.

GitHub te mostrará los commits y archivos que cambiaron. Revisa que tenga sentido.

---

### Paso 5 — Clic en "Create pull request"

Aparece el formulario del PR.

---

### Paso 6 — Llenar el formulario

**Título:** usa el formato de commit, por ejemplo:
```
feat: implementar FormRegistro con validaciones
```

**Descripción:** copia y pega la plantilla de `docs/templates/pull-request.md` y rellena cada sección.

---

### Paso 7 — Asignar revisor

En el panel derecho:
- **Reviewers** → clic en el engranaje → selecciona a **Josué López**

---

### Paso 8 — Crear el PR

Clic en **Create pull request**.

---

## Después de crear el PR

- Josué revisará el código y puede dejar comentarios.
- Si pide cambios, aplícalos en tu rama, haz commit y push — el PR se actualiza solo.
- Cuando Josué aprueba, él hace el merge.
- Después del merge, actualiza tu rama local:
  ```bash
  git checkout develop
  git pull origin develop
  ```

---

## Checklist antes de hacer clic en "Create"

- [ ] Base = `develop`, compare = tu rama
- [ ] Título sigue el formato de commit
- [ ] Plantilla de PR rellenada
- [ ] Revisor asignado (Josué López)
- [ ] Declaración de IA incluida (aunque sea "No usé IA en este PR")
