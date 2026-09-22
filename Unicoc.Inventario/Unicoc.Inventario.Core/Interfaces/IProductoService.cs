using Unicoc.Inventario.Core.Entities;
using Unicoc.Inventario.Shared.Responses;

namespace Unicoc.Inventario.Core.Interfaces;

public interface IProductoService
{
    IReadOnlyList<Producto> Listar();
    Resultado Crear(string nombre, string detalle);
    Resultado Retirar(Guid id);
    Resultado Reponer(Guid id);
}
