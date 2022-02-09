using mycinema.Data.Base;
using System.ComponentModel.DataAnnotations;

namespace mycinema.Models
{
    public class Cinema : IEntityBase
    {
        [Key]
        public int id { get; set; }

        [Display(Name ="Cinema Name")]
        public string Name { get; set; }
        [Display(Name = "LOGO")]
        public string logo { get; set; }
        [Display(Name = "Discription")]
        public string desc { get; set; }

        public List<Movie> Movies { get; set; }
    }
}
