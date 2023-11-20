// MenuViewComponent.cs
using AccesoWindows.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Security.Principal;
using System.Threading.Tasks;

namespace AccesoWindows.Component
{
    public class MenuViewComponent : ViewComponent
    {
        private readonly AplicationDbContext dbContext;
        private readonly ILogger<MenuViewComponent> _logger;

        public MenuViewComponent(AplicationDbContext dbContext, ILogger<MenuViewComponent> logger)
        {
            this.dbContext = dbContext;
            _logger = logger;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            _logger.LogInformation("Invocando el componente de menú.");

            // Obtener el nombre de usuario de Windows actual
            WindowsIdentity windowsIdentity = HttpContext.User.Identity as WindowsIdentity;
            string usuario = windowsIdentity?.Name;

            // Verifica si el usuario es correcto
            if (string.IsNullOrEmpty(usuario))
            {
                _logger.LogError("Error: Usuario no válido.");
                // Puedes manejar este caso según tus necesidades
                return Content("Error: Usuario no válido");
            }

            var menu = dbContext.Menu.FromSqlRaw("EXEC pa_obtener_menu @usuario", new SqlParameter("@usuario", usuario))
                                     .ToList();

            _logger.LogInformation($"Número de elementos en el menú: {menu.Count}");

            return View("/Views/Shared/_MenuVista.cshtml", menu);
        }
    }
}
