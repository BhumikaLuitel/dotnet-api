using Microsoft.AspNetCore.Mvc;

namespace FirstC_.Controllers;

public class BankController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}