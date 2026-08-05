using Microsoft.AspNetCore.Mvc;

namespace AiProjeKampi.WebUI.ViewComponents
{
    public class _NavbarDefaultComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
