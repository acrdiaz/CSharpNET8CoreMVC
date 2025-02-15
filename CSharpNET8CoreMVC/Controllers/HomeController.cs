using Microsoft.AspNetCore.Mvc;

namespace CSharpNET8CoreMVC.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
