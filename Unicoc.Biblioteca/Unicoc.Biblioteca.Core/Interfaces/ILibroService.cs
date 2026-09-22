using Unicoc.Biblioteca.Core.Entities;
using Unicoc.Biblioteca.Shared.Responses;

namespace Unicoc.Biblioteca.Core.Interfaces;

public interface ILibroService
{
    IReadOnlyList<Libro> Listar();
    Resultado Crear(string nombre, string detalle);
    Resultado Prestar(Guid id);
    Resultado Devolver(Guid id);
}
