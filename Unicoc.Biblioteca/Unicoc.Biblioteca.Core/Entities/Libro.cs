namespace Unicoc.Biblioteca.Core.Entities;

public sealed class Libro
{
    public Guid Id { get; }
    public string Nombre { get; }
    public string Detalle { get; }
    public bool Disponible { get; private set; } = true;

    public Libro(string nombre, string detalle)
    {
        if (string.IsNullOrWhiteSpace(nombre) || nombre.Trim().Length > 100)
            throw new ArgumentException("Título: ingrese entre 1 y 100 caracteres.");
        if (string.IsNullOrWhiteSpace(detalle) || detalle.Trim().Length > 100)
            throw new ArgumentException("Autor: ingrese entre 1 y 100 caracteres.");
        Id = Guid.NewGuid();
        Nombre = nombre.Trim();
        Detalle = detalle.Trim();
    }

    public void Prestar()
    {
        if (!Disponible) throw new InvalidOperationException("El libro ya está prestado.");
        Disponible = false;
    }

    public void Devolver()
    {
        if (Disponible) throw new InvalidOperationException("El libro no está prestado.");
        Disponible = true;
    }
}
