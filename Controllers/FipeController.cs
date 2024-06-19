using Microsoft.AspNetCore.Mvc;
using WebApplication10.Models;
using WebApplication10.Services;
using WebApplication10.Singletons;

namespace WebApplication10.Controllers
{
    public class FipeController : Controller
    {
        private readonly ConsumoApi _client;
        private readonly versaoGlobalNome _modeloNome;
        private readonly ModeloGlobalValue _modeloCodigo;

        public FipeController(versaoGlobalNome modeloNome, ModeloGlobalValue modeloCodigo)
        {
            _modeloNome = modeloNome;
            _modeloCodigo = modeloCodigo;
            _client = new ConsumoApi();
        }

        public async Task<IActionResult> SerachFipe(string id, string modelo, string marca)
        {

            var Versao = await _client.GetVeiculoAsync(marca, modelo, id);

            return PartialView("_Veiculo", Versao);
        }
    }
}
