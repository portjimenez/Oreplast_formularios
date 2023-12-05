using Microsoft.AspNetCore.Mvc.Rendering;
using System.Reflection;

namespace AccesoWindows.Models
{
    public class ListaViewModel
    {
        //llama a la tabla de rol
        public FrmRolModel? datos {  get; set; }
        
        public List<SelectListItem>? rol { get; set; }

        // se integra la lista de propiedades que deseo mostrar en el formulario
        public List<PropertyInfo>? Propiedades { get; set; }
    }
}
