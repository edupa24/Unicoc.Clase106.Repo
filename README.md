# Unicoc · Clase 106

Tres aplicaciones independientes para practicar la estructura de Unicoc.CRM:

| Aplicación | Caso de estudio | Dirección local |
|---|---|---|
| [Biblioteca](Unicoc.Biblioteca/README.md) | Libros, préstamos y devoluciones | http://localhost:5101 |
| [Inventario](Unicoc.Inventario/README.md) | Productos, entradas y salidas | http://localhost:5102 |
| [Mesa de ayuda](Unicoc.MesaAyuda/README.md) | Solicitudes y resolución | http://localhost:5103 |

## Ejecutar

Requiere el SDK de .NET 10. No necesita SQL Server, credenciales ni paquetes NuGet adicionales.

Abra `Unicoc.Clase106.Repo.slnx` y seleccione un proyecto Web como inicio, o ejecute desde esta carpeta:

```powershell
dotnet build Unicoc.Clase106.Repo.slnx
dotnet run --project Unicoc.Biblioteca/Unicoc.Biblioteca.Web
```

Cambie Biblioteca por Inventario o MesaAyuda para ejecutar los otros ejemplos. Puede iniciarlos simultáneamente desde terminales distintas. Cada aplicación incluye también su propia solución.

## Arquitectura

- **Shared**: resultado común de las operaciones.
- **Core**: entidades, reglas de negocio e interfaces.
- **Infrastructure**: servicios y almacenamiento en memoria.
- **Web**: controladores MVC, modelos de formulario, vistas Razor y estilos.

Dependencias: Core → Shared; Infrastructure → Core y Shared; Web → Core, Infrastructure y Shared.

El controlador valida el formulario y llama al contrato del servicio. Infrastructure localiza la entidad y ejecuta sus reglas. El resultado vuelve a la vista mediante un mensaje. Las escrituras usan POST y protección antifalsificación.

Se conserva la organización del CRM de referencia, usando .NET 10 en lugar de .NET 8. Los datos ficticios se guardan en memoria y se pierden al reiniciar. Son ejemplos locales sin autenticación.

## Trabajo en clase

1. Identificar la responsabilidad de cada capa.
2. Ejecutar una aplicación y crear registros.
3. Seguir una acción desde el formulario hasta la entidad.
4. Implementar los ejercicios del README de la aplicación.
5. Presentar un caso aceptado y uno rechazado por una regla de negocio.

Distribuya una aplicación por equipo. Como ampliación, agregue persistencia y usuarios manteniendo los contratos y las reglas del dominio.

## Verificar reglas

```powershell
dotnet run --project tests/Unicoc.Clase106.Verificaciones
```

El ejecutable de verificación comprueba transiciones de estado, entradas inválidas y registros inexistentes, sin dependencias externas.
