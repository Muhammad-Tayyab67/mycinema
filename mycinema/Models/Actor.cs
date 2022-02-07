using System.ComponentModel.DataAnnotations;

namespace mycinema.Models
{
    public class Actor
    {
        [Key]
        public int id { get; set; }


        [Display (Name="Full Name")]
        [Required(ErrorMessage ="Please Enter Full Name")]
        public string Name { get; set; }
        
        
        [Display(Name = "Profile Pic URL")]
        [Required(ErrorMessage ="Profile Must Provide")]
        public string profilepicurl { get; set; }
        
        [Required(ErrorMessage ="Give Some Bio's")]
        [Display(Name = "BIO")]
        public string bio { get; set; }

        //Relationships
        public List<Actor_Movie> Actors_Movies { get; set; }

    }
}
