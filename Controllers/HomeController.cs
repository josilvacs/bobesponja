using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using bobesponja.Models;
using bobesponja.Service;

namespace Bobesponja.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IBobService _BobService;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
        _bobService = bobService;
    }

    public IActionResult Index(string tipo)
    {
        var pokes = _pokeService.GetPokedexDto();
        ViewData["filter"] = string.IsNullOrEmpty(tipo) ? "all" : tipo;
        return View(pokes);
    }
    public IActionResult Details(int Numero)
    {
    var pokemon = _pokeService.GetDetailedPokemon(Numero);
    return View(pokemon);
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
