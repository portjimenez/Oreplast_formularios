using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace AccesoWindows.Models
{
    public class Usuarios : DbContext
    {
        [Key]
        public string? cuenta { get; set; }
        public string? descripcion { get; set; }
        public string? contrasena { get; set; }
    }
}
