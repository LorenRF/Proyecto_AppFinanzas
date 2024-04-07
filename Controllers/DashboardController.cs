using Microsoft.AspNetCore.Mvc;

namespace Proyecto_AppFinanzas.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
