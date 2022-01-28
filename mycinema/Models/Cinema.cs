using System.ComponentModel.DataAnnotations;

namespace mycinema.Models
{
    public class Cinema
    {
        [Key]
        public int id { get; set; }
        public string Name { get; set; }
        public string logo { get; set; }
        public string desc { get; set; }

        public List<Movie> Movies { get; set; }
    }
}
