using System.ComponentModel.DataAnnotations;

namespace SeguimientoDeCriptomonedas.Domain.DTOs
{
    public class AddFavoriteRequestDto
    {
        [Required(ErrorMessage = "El campo 'Nombre' es requerido")]
        public string Name { get; set; }
        [Required(ErrorMessage = "El campo 'Simbolo' es requerido")]
        public string Symbol { get; set; }
        [Required(ErrorMessage = "El campo 'Imagen' es requerido")]
        public string Image { get; set; }
    }
}
