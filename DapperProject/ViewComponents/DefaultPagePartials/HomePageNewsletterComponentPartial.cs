using Microsoft.AspNetCore.Mvc;

namespace DapperProject.ViewComponents.DefaultPagePartials
{
    public class HomePageNewsletterComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
