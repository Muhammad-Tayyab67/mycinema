using mycinema.Data;
using mycinema.Data.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mycinema.Models
{
    public class NewMovieVM
    {
        public int Id { get; set; }
        [Display(Name = "Full Name")]
        [Required(ErrorMessage ="Please Enter FullName")]
        public string Name { get; set; }
        [Display(Name = "imgurl")]
        [Required(ErrorMessage = "Please Enter PicUrl")]
        public string imgurl { get; set; }
        [Display(Name = "BIO")]
        [Required(ErrorMessage = "Please Enter Discription")]
        public string descr { get; set; }
        
        [Display(Name = "Price")]
        [Required(ErrorMessage = "Please Enter Price")]
        public double price { get; set; }

        [Display(Name = "Start Time")]
        [Required(ErrorMessage = "Please Enter StartTime")]
        public DateTime starttime { get; set; }

        [Display(Name = "End Time")]
        [Required(ErrorMessage = "Please Enter EndTime")]
        public DateTime endtime { get; set; }

        [Display(Name = "MovieCategery")]
        [Required(ErrorMessage = "Please Enter MovieCategery")]
        public MovieCategery MovieCategery { get; set; }

        [Display(Name = "Select Actors")]
        [Required(ErrorMessage = "Please Select Actors")]
        public List<int> ActorIds { get; set; }

        [Display(Name = "Select Cinema")]
        [Required(ErrorMessage = "Please Select Cinema")]
        public int cinemaId { get; set; }

        [Display(Name = "Select Producers")]
        [Required(ErrorMessage = "Please Select producers")]
        public int ProducerId { get; set; }
     
    }
}
