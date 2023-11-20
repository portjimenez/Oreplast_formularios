using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace AccesoWindows.Models
{
    public class FormulariosMenuModel : DbContext
    {
        [Key]
        public int? id_opcion { get; set; }
        public string? descripcion { get; set; }
        public string? texto { get; set; }
        public string? jerarquia { get; set; }
        public int? id_opcion_padre { get; set; }
    }
}
