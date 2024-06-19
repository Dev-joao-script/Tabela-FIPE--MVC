namespace WebApplication10.Models
{
    public class Versoes
    {
        public string codigo { get; set; }
        public string nome { get; set; }
    }

    internal class VersoesModel
    {
        public List<Versoes> Versoes { get; set; }
        public string NomeModelo { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public string SearchTerm { get; set; }
        public string marcaId { get; internal set; }
        public string modeloId { get; internal set; }
    }
}
