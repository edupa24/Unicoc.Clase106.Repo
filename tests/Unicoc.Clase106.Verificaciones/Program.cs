using Unicoc.Biblioteca.Infrastructure.Services;
using Unicoc.Inventario.Infrastructure.Services;
using Unicoc.MesaAyuda.Infrastructure.Services;

var total = 0;
void Verificar(bool condicion, string caso)
{
    if (!condicion) throw new Exception($"FALLO: {caso}");
    total++;
    Console.WriteLine($"OK: {caso}");
}

var libros = new LibroService();
var libro = libros.Listar()[0];
Verificar(libros.Prestar(libro.Id).Exito && !libro.Disponible, "Prestar libro disponible");
Verificar(!libros.Prestar(libro.Id).Exito, "Rechazar préstamo duplicado");
Verificar(libros.Devolver(libro.Id).Exito && libro.Disponible, "Devolver libro");
Verificar(!libros.Devolver(libro.Id).Exito, "Rechazar devolución duplicada");
Verificar(!libros.Crear(" ", "Autor").Exito, "Rechazar título vacío");
Verificar(!libros.Crear(new string('a', 101), "Autor").Exito, "Rechazar título largo");
Verificar(!libros.Prestar(Guid.NewGuid()).Exito, "Rechazar libro inexistente");
Verificar(libros.Crear("  Libro nuevo  ", "  Autor  ").Exito &&
    libros.Listar().Any(x => x.Nombre == "Libro nuevo" && x.Detalle == "Autor"), "Crear y normalizar libro");

var productos = new ProductoService();
var producto = productos.Listar()[0];
Verificar(!productos.Retirar(producto.Id).Exito && producto.Existencias == 0, "Impedir stock negativo");
Verificar(productos.Reponer(producto.Id).Exito && producto.Existencias == 1, "Ingresar unidad");
Verificar(productos.Retirar(producto.Id).Exito && producto.Existencias == 0, "Retirar unidad");
Verificar(!productos.Crear("Producto", " ").Exito, "Validar categoría");
Verificar(!productos.Reponer(Guid.NewGuid()).Exito, "Rechazar producto inexistente");
Verificar(productos.Crear("Marcador", "Papelería").Exito &&
    productos.Listar().Any(x => x.Nombre == "Marcador" && x.Existencias == 0), "Crear producto");

var solicitudes = new SolicitudService();
var solicitud = solicitudes.Listar()[0];
Verificar(solicitudes.Resolver(solicitud.Id).Exito && solicitud.Resuelta, "Resolver solicitud");
Verificar(!solicitudes.Resolver(solicitud.Id).Exito, "Rechazar resolución duplicada");
Verificar(!solicitudes.Crear("Asunto", " ").Exito, "Validar solicitante");
Verificar(!solicitudes.Resolver(Guid.NewGuid()).Exito, "Rechazar solicitud inexistente");
Verificar(solicitudes.Crear("Consulta", "Alumno").Exito &&
    solicitudes.Listar().Any(x => x.Nombre == "Consulta" && !x.Resuelta), "Crear solicitud pendiente");
Console.WriteLine($"{total} verificaciones correctas.");
