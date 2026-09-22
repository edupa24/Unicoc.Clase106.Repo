# Unicoc.MesaAyuda

Registrar solicitudes de soporte y resolver casos pendientes.

## Ejecutar

Desde la raíz del repositorio:

```powershell
dotnet run --project Unicoc.MesaAyuda/Unicoc.MesaAyuda.Web
```

Abra http://localhost:5103. También puede abrir `Unicoc.MesaAyuda.slnx` y seleccionar el proyecto Web como inicio.

## Recorrido para la clase

1. Examine la entidad `Solicitud` en Core y sus reglas de negocio.
2. Lea el contrato `ISolicitudService` y su implementación en Infrastructure.
3. Siga la solicitud desde HomeController hasta el servicio y la vista Razor.
4. Cree un registro y ejecute las acciones del listado.
5. Pruebe una operación inválida y explique el mensaje mostrado.

## Práctica propuesta

Agregar prioridades, asignar un responsable y permitir filtrar por estado.

Criterios de entrega: validar entradas en servidor, mantener las reglas en Core, usar inyección de dependencias y demostrar un caso correcto y uno rechazado. Como ampliación, sustituir el almacenamiento en memoria por una base de datos sin cambiar el controlador.

## Alcance

Datos ficticios en memoria compartidos por los visitantes del mismo proceso. Se reinician al cerrar la aplicación. No incluye autenticación ni persistencia; se ejecuta localmente como ejemplo de clase.
