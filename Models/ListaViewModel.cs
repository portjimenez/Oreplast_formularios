using Microsoft.AspNetCore.Mvc.Rendering;

namespace AccesoWindows.Models
{
    public class ListaViewModel
    {
        public FrmRolModel? datos {  get; set; }
        
        public List<SelectListItem>? rol { get; set; }
    }
}
