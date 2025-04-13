using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Lans.Web.Controllers;

public class HomeController : Controller
{
    [Route("Test")]
    [Authorize]
    public IActionResult Test()
    {
        return View();
    }


    public IActionResult Index()
    {
        return View();
    }
    
    [Route("Features")]
    public IActionResult Features()
    {
        return View();
    }

    [Route("Pricing")]
    public IActionResult Pricing()
    {
        return View();
    }

    [Route("Blog")]
    public IActionResult Blog()
    {
        return View();
    }

    [Route("Contact")]
    public IActionResult Contact()
    {
        return View();
    }

}
