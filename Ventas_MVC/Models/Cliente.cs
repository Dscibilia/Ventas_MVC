using System.ComponentModel.DataAnnotations;

namespace Ventas_MVC.Models
{
    public class Cliente
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Apellido { get; set; }
    }
}
