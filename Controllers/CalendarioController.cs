using Microsoft.AspNetCore.Mvc;

namespace Proyecto_AppFinanzas.Controllers
{
    public class CalendarioController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
