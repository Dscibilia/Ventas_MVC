using System.ComponentModel.DataAnnotations;

namespace Ventas_MVC.Models
{
    public class Producto
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public double Precio { get; set; }
    }
}
