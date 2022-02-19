using Microsoft.AspNetCore.Mvc;
using mycinema.Data.Cart;
using mycinema.Data.Services;
using mycinema.Data.ViewModel;

namespace mycinema.Controllers
{
    public class OrdersController : Controller
    {
        private readonly IMoviesServices _movieserviece;
        private readonly ShopingCart _shopingCart;

        public OrdersController(IMoviesServices moviesServices, ShopingCart shopingCart)
        {
            _movieserviece = moviesServices;
            _shopingCart=shopingCart;
        }

        public IActionResult Index()
        {
            var item=_shopingCart.GetShopingCartItem();
            _shopingCart.ShopingCartItem=item;

            var response = new ShoppingCartVM()
            {
                ShopingCart = _shopingCart,
                ShopingCartTotal = _shopingCart.GetShoppingCartTotal()
            };
            return View(response);
        
        }
    }
}
