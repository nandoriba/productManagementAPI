using Microsoft.AspNetCore.Mvc;

namespace ProductManagement.API.Controllers
{
    public class HomeController : ControllerBase
    {
        public IActionResult Index()
        {
            return new RedirectResult("~/swagger");
        }
    }
}
