using Microsoft.AspNetCore.Mvc;

namespace AiProjeKampi.WebUI.ViewComponents
{
    public class _AboutDefaultComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
