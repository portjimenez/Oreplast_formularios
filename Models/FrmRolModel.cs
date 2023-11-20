using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace AccesoWindows.Models
{
    public class FrmRolModel : DbContext
    {
        [Key]
        public int? id_rol {  get; set; }
        public string? descripcion { get; set; }
    }
}
