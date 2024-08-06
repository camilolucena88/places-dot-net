using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

public class PlacesController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}