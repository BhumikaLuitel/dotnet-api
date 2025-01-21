using Microsoft.AspNetCore.Mvc;

namespace FirstC_.Controllers;

public class TodoController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}