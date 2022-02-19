using System.ComponentModel.DataAnnotations;

namespace mycinema.Models
{
    public class ShopingCartItem
    {
        [Key]
        public int Id { get; set; }
        public Movie Movie { get; set; }
        public int Amount { get; set; }
        public string ShopingCartId { get; set; }
    }
}
