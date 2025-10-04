using Microsoft.AspNetCore.Mvc;

namespace MVCApp.Controllers;
public class PokemonController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
