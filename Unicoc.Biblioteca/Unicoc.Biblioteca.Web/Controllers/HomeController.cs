using Microsoft.AspNetCore.Mvc;
using Unicoc.Biblioteca.Core.Interfaces;
using Unicoc.Biblioteca.Shared.Responses;
using Unicoc.Biblioteca.Web.Models;

namespace Unicoc.Biblioteca.Web.Controllers;

public sealed class HomeController(ILibroService servicio) : Controller
{
    public IActionResult Index() => View(servicio.Listar());

    [HttpGet]
    public IActionResult Crear() => View(new CrearViewModel());

    [HttpPost, ValidateAntiForgeryToken]
    public IActionResult Crear(CrearViewModel modelo)
    {
        if (!ModelState.IsValid) return View(modelo);
        var resultado = servicio.Crear(modelo.Nombre, modelo.Detalle);
        if (!resultado.Exito)
        {
            ModelState.AddModelError("", resultado.Mensaje);
            return View(modelo);
        }
        return Mostrar(resultado);
    }

    [HttpPost, ValidateAntiForgeryToken]
    public IActionResult Prestar(Guid id) => Mostrar(servicio.Prestar(id));

    [HttpPost, ValidateAntiForgeryToken]
    public IActionResult Devolver(Guid id) => Mostrar(servicio.Devolver(id));

    private IActionResult Mostrar(Resultado resultado)
    {
        TempData["Mensaje"] = resultado.Mensaje;
        TempData["Tipo"] = resultado.Exito ? "exito" : "error";
        return RedirectToAction(nameof(Index));
    }

    public IActionResult Error()
    {
        Response.StatusCode = 500;
        return View();
    }
}
