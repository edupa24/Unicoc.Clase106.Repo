# Unicoc.Inventario

Registrar productos y controlar entradas y salidas de unidades.

## Ejecutar

Desde la raíz del repositorio:

```powershell
dotnet run --project Unicoc.Inventario/Unicoc.Inventario.Web
```

Abra http://localhost:5102. También puede abrir `Unicoc.Inventario.slnx` y seleccionar el proyecto Web como inicio.

## Recorrido para la clase

1. Examine la entidad `Producto` en Core y sus reglas de negocio.
2. Lea el contrato `IProductoService` y su implementación en Infrastructure.
3. Siga la solicitud desde HomeController hasta el servicio y la vista Razor.
4. Cree un registro y ejecute las acciones del listado.
5. Pruebe una operación inválida y explique el mensaje mostrado.

## Práctica propuesta

Agregar un stock mínimo, mostrar alertas y registrar el historial de movimientos.

Criterios de entrega: validar entradas en servidor, mantener las reglas en Core, usar inyección de dependencias y demostrar un caso correcto y uno rechazado. Como ampliación, sustituir el almacenamiento en memoria por una base de datos sin cambiar el controlador.

## Alcance

Datos ficticios en memoria compartidos por los visitantes del mismo proceso. Se reinician al cerrar la aplicación. No incluye autenticación ni persistencia; se ejecuta localmente como ejemplo de clase. Los productos empiezan con cero unidades: use Ingresar unidad antes de retirar.
