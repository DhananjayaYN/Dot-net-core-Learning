using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ArchitectureDemo.Models;

namespace ArchitectureDemo.Controllers;

public class HomeController : Controller
{
    // private readonly ILogger<HomeController> _logger;

    // public HomeController(ILogger<HomeController> logger)
    // {
    //     _logger = logger;
    // }

    // public IActionResult Index()
    // {
    //     return View();
    // }

    // public IActionResult Privacy()
    // {
    //     return View();
    // }

    //testing----------
    private readonly ILogger<HomeController> _logger;
    private readonly IGreetingService _greetingService;
    public HomeController(ILogger<HomeController> logger, IGreetingService greetingService)
    {
        _logger = logger;
        _greetingService = greetingService;
    }
    public IActionResult Index()
    {
        ViewBag.Greeting = _greetingService.GetGreeting("Developer");
        return View();
    }


    //-----------------

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
