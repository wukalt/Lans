using Microsoft.AspNetCore.Mvc;

namespace Toplearn.Web.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
