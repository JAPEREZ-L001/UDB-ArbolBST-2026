# Tutorial 02 — 5 problemas frecuentes en Git

---

## Problema 1: Mi rama está desactualizada con `develop`

**Síntoma:** Josué hizo cambios en `develop` que yo necesito, pero mi rama no los tiene.

**Solución:**
```bash
git checkout develop
git pull origin develop
git checkout feature/mi-feature
git merge develop
```

Si hay conflictos, Git te muestra los archivos afectados. Ábrelos, resuelve las secciones marcadas con `<<<<<<<`, guarda y haz:
```bash
git add [archivos-resueltos]
git commit -m "fix: resolver conflicto con develop"
```

---

## Problema 2: Hice commit en la rama equivocada

**Síntoma:** Hice un commit en `develop` o `main` sin querer.

**Solución:**
```bash
# Ver el hash del último commit
git log --oneline -3

# Guardar ese hash, por ejemplo: abc1234
# Ir a tu rama correcta
git checkout feature/mi-feature

# Traer ese commit a tu rama
git cherry-pick abc1234

# Volver a develop y deshacer el commit (sin perder los cambios)
git checkout develop
git reset HEAD~1
```

---

## Problema 3: Subí la carpeta `bin/` u `obj/` al repo

**Síntoma:** En GitHub aparecen carpetas `bin/`, `obj/`, `.vs/` que no deberían estar.

**Solución:**
```bash
# Eliminar del seguimiento de git (no borra los archivos locales)
git rm -r --cached ArbolBST/bin/
git rm -r --cached ArbolBST/obj/
git rm -r --cached .vs/

git commit -m "fix: remover carpetas generadas del repositorio"
git push
```

Asegúrate de que el `.gitignore` incluye estas líneas:
```
bin/
obj/
.vs/
*.user
```

---

## Problema 4: `git push` fue rechazado

**Síntoma:** Error `rejected` o `non-fast-forward` al hacer push.

**Causa más común:** Alguien más subió cambios a la misma rama antes que tú.

**Solución:**
```bash
git pull origin feature/mi-feature
# Si hay conflictos, resuélvelos
git push origin feature/mi-feature
```

Si la rama es solo tuya (nadie más trabaja en ella), también puedes usar:
```bash
git pull --rebase origin feature/mi-feature
git push
```

---

## Problema 5: Necesito deshacer cambios sin hacer commit todavía

**Síntoma:** Modifiqué un archivo y quiero volver al estado del último commit.

**Solución:**
```bash
# Descartar cambios en un archivo específico
git checkout -- ArbolBST/Forms/FormPrincipal.cs

# Descartar TODOS los cambios sin guardar (cuidado, es irreversible)
git checkout -- .
```

Si ya hiciste `git add` pero aún no el commit:
```bash
git restore --staged ArbolBST/Forms/FormPrincipal.cs
```
