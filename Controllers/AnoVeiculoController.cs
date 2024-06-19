using Microsoft.AspNetCore.Mvc;
using WebApplication10.Models;
using WebApplication10.Services;
using WebApplication10.Singletons;

namespace WebApplication10.Controllers
{
    public class AnoVeiculoController : Controller
    {
        private readonly ConsumoApi _client;
        private readonly ModeloGlobalNome _modeloNome;
        private readonly ModeloGlobalValue _modeloCodigo;

        public AnoVeiculoController(ModeloGlobalNome modeloNome, ModeloGlobalValue modeloCodigo)
        {
            _modeloNome = modeloNome;
            _modeloCodigo = modeloCodigo;
            _client = new ConsumoApi();
        }

        public async Task<IActionResult> AnoVeiculoSearch(string id, string nomeModelo,string marca, string searchTerm, int page = 1)
        {
            if (!string.IsNullOrEmpty(id))
            {
                if (_modeloCodigo.GetValue() != id)
                {
                    _modeloCodigo.SetValue(id);
                }
            }

            if (!string.IsNullOrEmpty(nomeModelo))
            {
                if (_modeloNome.GetValue() != nomeModelo)
                {
                    _modeloNome.SetValue(nomeModelo);
                }
            }

            int pageSize = 12;

            var Versao = await _client.GetVersoesAsync(marca, _modeloCodigo.GetValue());

            if (!string.IsNullOrEmpty(searchTerm))
            {
                Versao = Versao.Where(m => m.nome.Contains(searchTerm, StringComparison.OrdinalIgnoreCase)).ToList();
            }

            if (Versao == null)
            {
                return NotFound();
            }

            int totalModelos = Versao.Count();

            var detalhesViewModel = new VersoesModel
            {
                marcaId = marca,
                modeloId = _modeloCodigo.GetValue(),
                Versoes = Versao,
                NomeModelo = _modeloNome.GetValue(),
                CurrentPage = page,
                TotalPages = (int)Math.Ceiling(totalModelos / (double)pageSize),
                SearchTerm = searchTerm
            };

            return PartialView("_Versoes", detalhesViewModel);
        }
    }
}
