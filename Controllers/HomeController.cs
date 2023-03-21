using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using bobesponja.Models;
using bobesponja.Service;

namespace Bobesponja.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IBobService _bobService;

    public HomeController(ILogger<HomeController> logger , IBobService bobService)
    {
        _logger = logger;
        _bobService = bobService;
    }

    public IActionResult Index(string especie)
    {
        var bob = _bobService.GetBobEsponja();
        ViewData["filter"] = string.IsNullOrEmpty(especie) ? "all" : especie;
        return View(bob);
    }
    public IActionResult Details(string Nome)
    {
    var personagem = _bobService.GetDetailedPersonagem(Nome);
    return View(personagem);
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
