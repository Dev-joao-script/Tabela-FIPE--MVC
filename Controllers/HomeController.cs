using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApplication10.Models;
using WebApplication10.Services;

namespace WebApplication10.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ConsumoApi _clientApi;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            _clientApi = new ConsumoApi();
        }

        public async Task<IActionResult> Index(string searchTerm, int page = 1)
        {
            int pageSize = 12; // Número de itens por página (4 colunas x 3 linhas)
            var allMarcas = await _clientApi.GetMarcasAsync();

            if (!string.IsNullOrEmpty(searchTerm))
            {
                allMarcas = allMarcas.Where(m => m.nome.Contains(searchTerm, StringComparison.OrdinalIgnoreCase)).ToList();
            }

            int totalMarcas = allMarcas.Count();
            var marcas = allMarcas.Skip((page - 1) * pageSize).Take(pageSize).ToList();

            var model = new MarcaViewModel
            {
                Marcas = marcas,
                CurrentPage = page,
                TotalPages = (int)Math.Ceiling(totalMarcas / (double)pageSize),
                SearchTerm = searchTerm
            };

            return View(model);
        }


        public async Task<IActionResult> Search(string searchTerm, int page = 1)
        {
            int pageSize = 12; // Número de itens por página (4 colunas x 3 linhas)
            var allMarcas = await _clientApi.GetMarcasAsync();

            if (!string.IsNullOrEmpty(searchTerm))
            {
                allMarcas = allMarcas.Where(m => m.nome.Contains(searchTerm, StringComparison.OrdinalIgnoreCase)).ToList();
            }

            int totalMarcas = allMarcas.Count();
            var marcas = allMarcas.Skip((page - 1) * pageSize).Take(pageSize).ToList();

            var model = new MarcaViewModel
            {
                Marcas = marcas,
                CurrentPage = page,
                TotalPages = (int)Math.Ceiling(totalMarcas / (double)pageSize),
                SearchTerm = searchTerm
            };

            return PartialView("_MarcaList", model);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
