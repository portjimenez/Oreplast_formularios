using AccesoWindows.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace AccesoWindows.Controllers
{
    public class AccountController : Controller
    {
        private readonly AplicationDbContext _context;

        public AccountController(AplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _context.tbl_usuario
                    .SingleOrDefaultAsync(u => u.cuenta == model.Username && u.contrasena == model.Password);

                if (user != null)
                {
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, user.cuenta),
                        // Puedes agregar más reclamaciones según sea necesario
                    };

                    var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var principal = new ClaimsPrincipal(identity);

                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal,
                        new AuthenticationProperties
                        {
                            IsPersistent = model.RememberMe, // Configurar la persistencia de la cookie según la opción "Recordarme"
                            ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(20) // Configurar el tiempo de expiración de la cookie
                        });

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Nombre de usuario o contraseña incorrectos.");
                }
            }

            return View(model);
        }
    }
}