using Microsoft.AspNetCore.Mvc;
using mycinema.Data.Cart;

namespace mycinema.Data.ViewComponents
{
    public class ShoppingCartSummary: ViewComponent
    {
        private readonly ShopingCart _shopingCart;
        public ShoppingCartSummary(ShopingCart shopingCart)
        {
            _shopingCart= shopingCart;
        }
        public IViewComponentResult Invoke()
        {
            var item= _shopingCart.GetShopingCartItem();
            return View(item.Count);
        }
    }
}
