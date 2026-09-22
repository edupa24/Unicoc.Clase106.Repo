namespace Unicoc.MesaAyuda.Core.Entities;

public sealed class Solicitud
{
    public Guid Id { get; }
    public string Nombre { get; }
    public string Detalle { get; }
    public bool Resuelta { get; private set; } = false;

    public Solicitud(string nombre, string detalle)
    {
        if (string.IsNullOrWhiteSpace(nombre) || nombre.Trim().Length > 100)
            throw new ArgumentException("Asunto: ingrese entre 1 y 100 caracteres.");
        if (string.IsNullOrWhiteSpace(detalle) || detalle.Trim().Length > 100)
            throw new ArgumentException("Solicitante: ingrese entre 1 y 100 caracteres.");
        Id = Guid.NewGuid();
        Nombre = nombre.Trim();
        Detalle = detalle.Trim();
    }

    public void Resolver()
    {
        if (Resuelta) throw new InvalidOperationException("La solicitud ya está resuelta.");
        Resuelta = true;
    }

    
}
