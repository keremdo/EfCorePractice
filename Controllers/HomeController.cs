using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using efcoreApp.Models;

namespace efcoreApp.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
   
}
