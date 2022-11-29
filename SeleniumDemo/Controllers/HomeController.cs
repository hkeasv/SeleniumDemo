using System.Diagnostics;
using CalculatorLib;
using Microsoft.AspNetCore.Mvc;
using SeleniumDemo.Models;

namespace SeleniumDemo.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View(new CalculateViewModel());
    }

    [HttpPost]
    public IActionResult Index(CalculateViewModel model)
    {
        if (ModelState.IsValid)
        {
            Calculator calc = new Calculator();
            model.Result = calc.Add(model.FirstNumber, model.SecondNumber);
        }
        return View(model);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

