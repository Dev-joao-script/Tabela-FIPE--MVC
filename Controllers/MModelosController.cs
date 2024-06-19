using Microsoft.AspNetCore.Mvc;
using WebApplication10.Models;
using WebApplication10.Services;
using WebApplication10.Singletons;

namespace WebApplication10.Controllers
{
    public class MModelosController : Controller
    {
        private readonly ConsumoApi _client;
        private readonly MarcaGlobalValue _marca;
        private readonly MarcaGlobalNome nomeMarcapro;
        public MModelosController(MarcaGlobalValue marca, MarcaGlobalNome nomeMarcapro)
        {
            _client = new ConsumoApi();
            _marca = marca;
            this.nomeMarcapro = nomeMarcapro;

        }

        public async Task<IActionResult> Search(string id,string nomeMarca, string searchTerm, int page = 1)
        {
            if (!string.IsNullOrEmpty(id))
            {
                if (_marca.GetValue() != id)
                {
                    _marca.SetValue(id);
                }
            }

            if(!string.IsNullOrEmpty(nomeMarca)) {
                if (nomeMarcapro.GetValue() != nomeMarca)
                {
                    nomeMarcapro.SetValue(nomeMarca);
                }
            }

            int pageSize = 12;
            var marca = await _client.GetModelosAsync(_marca.GetValue().ToString());
            var modelos = new List<Modelo>();
            modelos = marca.modelos;

            if (!string.IsNullOrEmpty(searchTerm))
            {
                modelos = modelos.Where(m => m.nome.Contains(searchTerm, StringComparison.OrdinalIgnoreCase)).ToList();
            }

            if (modelos == null)
            {
                return NotFound();
            }

            int totalModelos = modelos.Count();

            var detalhesViewModel = new ModelosModel
            {
                marcaCodigo = _marca.GetValue(),
                Modelos = modelos,
                nomeMarca = nomeMarcapro.GetValue(),
                CurrentPage = page,
                TotalPages = (int)Math.Ceiling(totalModelos / (double)pageSize),
                SearchTerm = searchTerm
            };

            return PartialView("_Modelo", detalhesViewModel);
        }
    }
}
