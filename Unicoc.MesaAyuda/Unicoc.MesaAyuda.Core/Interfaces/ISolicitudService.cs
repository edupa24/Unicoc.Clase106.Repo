using Unicoc.MesaAyuda.Core.Entities;
using Unicoc.MesaAyuda.Shared.Responses;

namespace Unicoc.MesaAyuda.Core.Interfaces;

public interface ISolicitudService
{
    IReadOnlyList<Solicitud> Listar();
    Resultado Crear(string nombre, string detalle);
    Resultado Resolver(Guid id);
}
