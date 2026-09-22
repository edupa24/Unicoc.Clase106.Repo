using Unicoc.Inventario.Core.Entities;
using Unicoc.Inventario.Core.Interfaces;
using Unicoc.Inventario.Shared.Responses;

namespace Unicoc.Inventario.Infrastructure.Services;

// Singleton didáctico: la información se reinicia al detener la aplicación.
public sealed class ProductoService : IProductoService
{
    private readonly object _candado = new();
    private readonly List<Producto> _items =
    [
        new("Teclado", "Periféricos"),
        new("Cuaderno", "Papelería"),
    ];

    public IReadOnlyList<Producto> Listar()
    {
        lock (_candado) return _items.OrderBy(item => item.Nombre).ToArray();
    }

    public Resultado Crear(string nombre, string detalle)
    {
        try
        {
            var item = new Producto(nombre, detalle);
            lock (_candado) _items.Add(item);
            return new(true, "Registro creado.");
        }
        catch (ArgumentException error) { return new(false, error.Message); }
    }

    public Resultado Retirar(Guid id) => Aplicar(id, item => item.Retirar());
    public Resultado Reponer(Guid id) => Aplicar(id, item => item.Reponer());

    private Resultado Aplicar(Guid id, Action<Producto> operacion)
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
