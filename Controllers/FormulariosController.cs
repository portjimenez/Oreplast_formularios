using AccesoWindows.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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

        //Obtener columnas
        var nombreColumnas = ObtenerNombreColumnas();

        var lista = new ListaViewModel
        {
            rol = elementos.Select(c => new SelectListItem
            {
                Value = c.id_rol.ToString(),
                Text = c.descripcion
            }).ToList(),

            //asignar los nombres de las colunas al modelo
            Columnas = nombreColumnas,

            //con esto llamamos todos los campos de la tabla
            Propiedades = typeof(FrmRolModel).GetProperties().ToList()
        };



        return View(lista);
    }

    private List<string> ObtenerNombreColumnas()
    {
        var entityType = _context.Model.FindEntityType(typeof(FrmRolModel));
        var nombreColumnas = entityType.GetProperties().Select(p=> p.GetColumnName()).ToList();

        return nombreColumnas;
    }



}
