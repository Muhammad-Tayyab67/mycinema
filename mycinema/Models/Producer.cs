using System.ComponentModel.DataAnnotations;

namespace mycinema.Models
{
    public class Producer
    {
        [Key]
        public int id { get; set; }
        public string Name { get; set; }
        public string profilepicurl { get; set; }
        public string bio { get; set; }

        public List<Movie> Movies { get; set; }
    }
}
