using Unicoc.Biblioteca.Core.Entities;
using Unicoc.Biblioteca.Core.Interfaces;
using Unicoc.Biblioteca.Shared.Responses;

namespace Unicoc.Biblioteca.Infrastructure.Services;

// Singleton didáctico: la información se reinicia al detener la aplicación.
public sealed class LibroService : ILibroService
{
    private readonly object _candado = new();
    private readonly List<Libro> _items =
    [
        new("Cien años de soledad", "Gabriel García Márquez"),
        new("El principito", "Antoine de Saint-Exupéry"),
    ];

    public IReadOnlyList<Libro> Listar()
    {
        lock (_candado) return _items.OrderBy(item => item.Nombre).ToArray();
    }

    public Resultado Crear(string nombre, string detalle)
    {
        try
        {
            var item = new Libro(nombre, detalle);
            lock (_candado) _items.Add(item);
            return new(true, "Registro creado.");
        }
        catch (ArgumentException error) { return new(false, error.Message); }
    }

    public Resultado Prestar(Guid id) => Aplicar(id, item => item.Prestar());
    public Resultado Devolver(Guid id) => Aplicar(id, item => item.Devolver());

    private Resultado Aplicar(Guid id, Action<Libro> operacion)
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
