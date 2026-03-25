# Tutorial 01 — Git desde cero hasta tu primer push

Solo los pasos que necesitas en este proyecto. Nada más.

---

## 1. Instalar Git

Descarga desde: https://git-scm.com/download/win

Durante la instalación, deja todo en los valores por defecto.

Verifica que quedó bien:
```bash
git --version
# debe mostrar algo como: git version 2.x.x
```

---

## 2. Configuración inicial (una sola vez)

```bash
git config --global user.name "Tu Nombre"
git config --global user.email "tu.correo@ejemplo.com"
```

Usa el mismo correo que usas en GitHub.

---

## 3. Clonar el repositorio

```bash
git clone https://github.com/[usuario]/UDB-ArbolBST-2026.git
cd UDB-ArbolBST-2026
```

---

## 4. Crear tu rama de trabajo

Siempre partes desde `develop`:

```bash
git checkout develop
git pull origin develop
git checkout -b feature/nombre-de-tu-feature
```

Ejemplos de nombres:
- `feature/frontend-registro-busqueda`
- `feature/backend-arbol-avl`
- `feature/backend-reportes`

---

## 5. Hacer tu primer commit

```bash
git add nombre-del-archivo.cs
git commit -m "feat: descripción breve de lo que hiciste"
```

O para agregar todos los cambios del proyecto (con cuidado):
```bash
git add ArbolBST/
git commit -m "feat: descripción breve"
```

> Ver `docs/templates/commit.md` para el formato de mensajes de commit.

---

## 6. Subir tu rama a GitHub

```bash
git push origin feature/nombre-de-tu-feature
```

La primera vez, Git puede pedirte tus credenciales de GitHub.

---

## Resumen rápido

```bash
git clone [url]                         # una sola vez
git checkout develop && git pull        # antes de crear tu rama
git checkout -b feature/mi-feature      # crear rama
git add [archivo]                       # preparar cambios
git commit -m "tipo: descripción"       # guardar commit
git push origin feature/mi-feature      # subir a GitHub
```

> Siguiente paso: ver `docs/tutorials/03-pr-en-github.md` para abrir tu Pull Request.
