using WebApplication10.Singletons;

namespace WebApplication10.Models
{
    public class Modelos
    {
        public List<Modelo> modelos { get; set; }
        public List<Ano> anos { get; set; }
    }

    public class Modelo
    {
        public int codigo { get; set; }
        public string nome { get; set; }
    }

    public class Ano
    {
        public string codigo { get; set; }
        public string nome { get; set; }
    }


    public class ModelosModel
    {
        public List<Modelo> Modelos { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public string SearchTerm { get; set; }
        public string nomeMarca { get; internal set; }
        public string marcaCodigo { get; internal set; }
    }
}