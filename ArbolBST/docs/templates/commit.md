# Plantilla de mensaje de commit

## Formato

```
tipo: descripción breve en presente (máx 72 caracteres)
```

## Tipos permitidos

| Tipo       | Cuándo usarlo                                         |
|------------|-------------------------------------------------------|
| `feat`     | Agregas nueva funcionalidad                           |
| `fix`      | Corriges un bug o error                               |
| `refactor` | Reorganizas código sin cambiar el comportamiento      |
| `docs`     | Solo cambios en documentación                         |
| `style`    | Cambios de formato/espaciado que no afectan la lógica |

## Ejemplos

```
feat: agregar controles y layout de FormRegistro
feat: conectar btnRegistrar con ArbolEstudiantes.Insertar
fix: corregir validación de rango de promedio en FormRegistro
refactor: extraer lógica de validación a método privado
docs: actualizar notas de progreso en work/
```

## Plantilla para copiar

```
[tipo]: [descripción breve]
```
