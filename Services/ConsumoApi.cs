using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebApplication10.Models;

namespace WebApplication10.Services
{


    public class ConsumoApi
    {
        private readonly HttpClient _Client;

        public ConsumoApi()
        {
            _Client = new HttpClient();
        }

        #region marcas all
        public async Task<List<Marca>> GetMarcasAsync()
        {
            try
            {
                var url = "https://parallelum.com.br/fipe/api/v1/carros/marcas";
                var response = await _Client.GetAsync(url);
                if (response != null)
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var responseData = await response.Content.ReadAsStringAsync();
                        var marcas = JsonConvert.DeserializeObject<List<Marca>>(responseData);
                        return marcas;
                    }
                    else
                    {
                        return default;
                    }
                }
                else
                {
                    return default;
                }

            }
            catch (Exception)
            {

                throw new Exception("erro ao consumir FIPE");
            }
        }
        #endregion

        #region modelos por codigo de marcas
        public async Task<Modelos> GetModelosAsync(string codigo)
        {
            try
            {
                var Url = $"https://parallelum.com.br/fipe/api/v1/carros/marcas/{codigo}/modelos";
                var response = await _Client.GetAsync(Url);
                if (response != null)
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var stringData = await response.Content.ReadAsStringAsync();
                        var data = JsonConvert.DeserializeObject<Modelos>(stringData);
                        return data;
                    }
                    else
                    {
                        return default;
                    }

                }
                else
                {
                    throw new Exception("Resposta vazia");
                }

            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion

        #region modelos por ano

        [HttpGet]
        [Route("V1/modelsByYears/all")]
        public async Task<List<Versoes>> GetVersoesAsync(string marca, string modelo)
        {
            try
            {
                var url = $"https://parallelum.com.br/fipe/api/v1/carros/marcas/{marca}/modelos/{modelo}/anos";
                var response = await _Client.GetAsync(url);
                if (response != null)
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var strigfyData = await response.Content.ReadAsStringAsync();
                        var data = JsonConvert.DeserializeObject<List<Versoes>>(strigfyData);
                        return data;
                    }
                    else
                    {
                        throw new Exception("Lista Vazia");
                    }
                }
                else
                {
                    throw default;
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        #endregion

        #region Precos por veiculo

        [HttpGet]
        [Route("v1/fipe")]
        public async Task<Veiculo> GetVeiculoAsync(string marca, string modelo, string codigo)
        {
            var url = $"https://parallelum.com.br/fipe/api/v1/carros/marcas/{marca}/modelos/{modelo}/anos/{codigo}";
            var response = await _Client.GetAsync(url);
            if (response != null)
            {
                var stringfyData = await response.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<Veiculo>(stringfyData);
                return data;
            }
            else
            {
                return default;
            }

        }

        #endregion 
    }
}
