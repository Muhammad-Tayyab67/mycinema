using System.ComponentModel.DataAnnotations;

namespace mycinema.Models
{
    public class Actor
    {
        [Key]
        public int id { get; set; }

        [Display (Name="Full Name")]
        public string Name { get; set; }
        [Display(Name = "Profile Pic URL")]
        public string profilepicurl { get; set; }

        [Display(Name = "BIO")]
        public string bio { get; set; }

        //Relationships
        public List<Actor_Movie> Actors_Movies { get; set; }

    }
}
