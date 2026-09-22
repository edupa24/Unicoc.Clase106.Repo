namespace Unicoc.Inventario.Core.Entities;

public sealed class Producto
{
    public Guid Id { get; }
    public string Nombre { get; }
    public string Detalle { get; }
    public int Existencias { get; private set; } = 0;

    public Producto(string nombre, string detalle)
    {
        if (string.IsNullOrWhiteSpace(nombre) || nombre.Trim().Length > 100)
            throw new ArgumentException("Nombre: ingrese entre 1 y 100 caracteres.");
        if (string.IsNullOrWhiteSpace(detalle) || detalle.Trim().Length > 100)
            throw new ArgumentException("Categoría: ingrese entre 1 y 100 caracteres.");
        Id = Guid.NewGuid();
        Nombre = nombre.Trim();
        Detalle = detalle.Trim();
    }

    public void Retirar()
    {
        if (Existencias == 0) throw new InvalidOperationException("No hay existencias para retirar.");
        Existencias--;
    }

    public void Reponer()
    {
        if (Existencias == int.MaxValue) throw new InvalidOperationException("Se alcanzó el límite de existencias.");
        Existencias++;
    }
}
