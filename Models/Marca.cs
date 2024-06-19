namespace WebApplication10.Models
{
    public class Marca
    {
        public int codigo { get; set; }
        public string nome { get; set; }

        internal List<Marca> toList()
        {
            throw new NotImplementedException();
        }
    }

    public class MarcaViewModel
    {
        public List<Marca> Marcas { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public string SearchTerm { get; set; }
    }
}
