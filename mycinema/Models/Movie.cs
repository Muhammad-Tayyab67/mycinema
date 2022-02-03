using mycinema.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mycinema.Models
{
    public class Movie
    {
        [Key]
        public int id { get; set; }
        [Display(Name = "Full Name")]
        public string Name { get; set; }
        [Display(Name = "imgurl")]
        public string imgurl { get; set; }
        [Display(Name = "BIO")]
        public string descr { get; set; }
        
        [Display(Name = "Price")]
        public double price { get; set; }

        public DateTime starttime { get; set; }

        public DateTime endtime { get; set; }

        public MovieCategery MovieCategery { get; set; }

        public List<Actor_Movie> Actors_Movies { get; set; }

        public int cinemaId { get; set; }
        [ForeignKey("cinemaId")]
        public Cinema Cinema { get; set; }

        public int ProducerId { get; set; }
        [ForeignKey("ProducerId")]
        public Producer Producer { get; set; }
    }
}
