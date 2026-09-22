using Microsoft.AspNetCore.Mvc;
using Unicoc.Inventario.Core.Interfaces;
using Unicoc.Inventario.Shared.Responses;
using Unicoc.Inventario.Web.Models;

namespace Unicoc.Inventario.Web.Controllers;

public sealed class HomeController(IProductoService servicio) : Controller
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
    public IActionResult Retirar(Guid id) => Mostrar(servicio.Retirar(id));

    [HttpPost, ValidateAntiForgeryToken]
    public IActionResult Reponer(Guid id) => Mostrar(servicio.Reponer(id));

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
