using System.ComponentModel.DataAnnotations;

namespace Unicoc.Biblioteca.Web.Models;

public sealed class CrearViewModel
{
    [Required(ErrorMessage = "Este campo es obligatorio.")]
    [StringLength(100, ErrorMessage = "El máximo es de 100 caracteres.")]
    [Display(Name = "Título")]
    public string Nombre { get; set; } = "";

    [Required(ErrorMessage = "Este campo es obligatorio.")]
    [StringLength(100, ErrorMessage = "El máximo es de 100 caracteres.")]
    [Display(Name = "Autor")]
    public string Detalle { get; set; } = "";
}
