using Microsoft.AspNetCore.Mvc;
using Unicoc.MesaAyuda.Core.Interfaces;
using Unicoc.MesaAyuda.Shared.Responses;
using Unicoc.MesaAyuda.Web.Models;

namespace Unicoc.MesaAyuda.Web.Controllers;

public sealed class HomeController(ISolicitudService servicio) : Controller
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
    public IActionResult Resolver(Guid id) => Mostrar(servicio.Resolver(id));

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
