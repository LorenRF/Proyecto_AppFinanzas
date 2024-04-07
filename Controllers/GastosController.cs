using Microsoft.AspNetCore.Mvc;

namespace Proyecto_AppFinanzas.Controllers
{
    public class GastosController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
