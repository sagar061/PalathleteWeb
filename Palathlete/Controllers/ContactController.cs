using Microsoft.AspNetCore.Mvc;

namespace Palathlete.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
