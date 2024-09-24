using Microsoft.AspNetCore.Mvc;

namespace DapperProject.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
