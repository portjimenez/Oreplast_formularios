using AccesoWindows.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;

public class FormulariosController : Controller
{
    private readonly AplicationDbContext _context;

    public FormulariosController(AplicationDbContext context)
    {
        _context = context;
    }

    public IActionResult FormularioRol()
    {
        var elementos = _context.tbl_rol.ToList();

        var lista = new ListaViewModel
        {
            rol = elementos.Select(c => new SelectListItem
            {
                Value = c.id_rol.ToString(),
                Text = c.descripcion
            }).ToList()
        };

        return View(lista);
    }
    

}
