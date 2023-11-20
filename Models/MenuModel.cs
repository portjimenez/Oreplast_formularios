using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AccesoWindows.Models
{
    public class MenuModel : DbContext
    {
        [Key]
        public int? Opcion { get; set; }
        public string? Descripcion { get; set; }
        public string? Texto { get; set; }
        public string? Formulario { get; set; }
        public string? Jerarquia { get; set; }
        public int Nivel { get; set; }
    }
}
