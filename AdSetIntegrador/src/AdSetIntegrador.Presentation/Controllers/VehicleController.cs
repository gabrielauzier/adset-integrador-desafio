using Microsoft.AspNetCore.Mvc;

namespace AdSetIntegrador.Presentation.Controllers
{
    public class VehicleController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
