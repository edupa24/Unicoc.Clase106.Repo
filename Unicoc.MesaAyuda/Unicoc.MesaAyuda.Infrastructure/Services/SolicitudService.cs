using Unicoc.MesaAyuda.Core.Entities;
using Unicoc.MesaAyuda.Core.Interfaces;
using Unicoc.MesaAyuda.Shared.Responses;

namespace Unicoc.MesaAyuda.Infrastructure.Services;

// Singleton didáctico: la información se reinicia al detener la aplicación.
public sealed class SolicitudService : ISolicitudService
{
    private readonly object _candado = new();
    private readonly List<Solicitud> _items =
    [
        new("No puedo ingresar al aula virtual", "Estudiante de ejemplo"),
        new("El proyector no enciende", "Docente de ejemplo"),
    ];

    public IReadOnlyList<Solicitud> Listar()
    {
        lock (_candado) return _items.OrderBy(item => item.Nombre).ToArray();
    }

    public Resultado Crear(string nombre, string detalle)
    {
        try
        {
            var item = new Solicitud(nombre, detalle);
            lock (_candado) _items.Add(item);
            return new(true, "Registro creado.");
        }
        catch (ArgumentException error) { return new(false, error.Message); }
    }

    public Resultado Resolver(Guid id) => Aplicar(id, item => item.Resolver());

    private Resultado Aplicar(Guid id, Action<Solicitud> operacion)
    {
        lock (_candado)
        {
            var item = _items.Find(item => item.Id == id);
            if (item is null) return new(false, "El registro no existe.");
            try
            {
                operacion(item);
                return new(true, "Operación realizada.");
            }
            catch (InvalidOperationException error) { return new(false, error.Message); }
        }
    }
}
