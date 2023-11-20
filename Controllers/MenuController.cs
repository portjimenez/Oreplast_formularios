using AccesoWindows.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Security.Principal;

namespace AccesoWindows.Controllers
{
    public class MenuController : Controller
    {
        private readonly AplicationDbContext dbContext;
        public MenuController(AplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public IActionResult Menu()
        {
            // Obtener el nombre de usuario de Windows actual
            WindowsIdentity windowsIdentity = HttpContext.User.Identity as WindowsIdentity;
            string usuario = windowsIdentity?.Name;

            //Verifica si el usuario es correcto
            if (string.IsNullOrEmpty(usuario))
            {
                return RedirectToAction("Error");
            }

            //estamos llamando al proceso almacenado
            var menu = dbContext.Menu.FromSqlRaw("EXEC pa_obtener_menu @usuario", new SqlParameter("@usuario", usuario))
            .ToList();

            return PartialView(menu);
        }
    }
}
