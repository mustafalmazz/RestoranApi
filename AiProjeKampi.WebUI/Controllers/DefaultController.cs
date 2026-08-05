using Microsoft.AspNetCore.Mvc;

namespace AiProjeKampi.WebUI.Controllers
{
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
