using System.ComponentModel.DataAnnotations;

namespace mycinema.Models
{
    public class Actor
    {
        [Key]
        public int id { get; set; }
        public string Name { get; set; }
        public string profilepicurl { get; set; }
        public string bio { get; set; }

        //Relationships
        public List<Actor_Movie> Actors_Movies { get; set; }

    }
}
