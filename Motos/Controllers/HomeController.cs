using System.Diagnostics;
using System.Text.json;
using Microsoft.AspNetCore.Mvc;
using Motos.Models;

namespace Motos.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {   
        List<Pokemon> pokemons = [];
        using (StreamReader leitor = new("Data\\Motos.json"))
        {
            string dados = leitor.ReadToEnd();
            Motos = jsonSerealizer.Deserealize<List<Motos>>(dados);
        }
        return View();

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
