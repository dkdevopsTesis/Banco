using Microsoft.AspNetCore.Mvc;

namespace Prueba.Controllers
{
    public class CuentaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
