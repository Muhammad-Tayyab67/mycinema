using Microsoft.EntityFrameworkCore;
using mycinema.Models;

namespace mycinema.Data.Cart
{
    public class ShopingCart
    {
        public AppDBContext _context { get; set; }

        public string ShoppingCartId { get; set; }
        public List<ShopingCartItem> ShopingCartItem { get; set; }

        public ShopingCart(AppDBContext context)
        {
            _context = context;
        }

        public static ShopingCart GetShoppingCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            var context = services.GetService<AppDBContext>();

            string cartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();
            session.SetString("CartId", cartId);

            return new ShopingCart(context) { ShoppingCartId = cartId };
        }

        public void AddItemToCart(Movie movie)
        {
            var shoppingCartItem = _context.ShopingCartItems.FirstOrDefault(n => n.Movie.id == movie.id && n.ShopingCartId == ShoppingCartId);

            if (shoppingCartItem == null)
            {
                shoppingCartItem = new ShopingCartItem()
                {
                    ShopingCartId = ShoppingCartId,
                    Movie = movie,
                    Amount = 1
                };

                _context.ShopingCartItems.Add(shoppingCartItem);
            }
            else
            {
                shoppingCartItem.Amount++;
            }
            _context.SaveChanges();
        }

        public void RemoveItemFromCart(Movie movie)
        {
            var shoppingCartItem = _context.ShopingCartItems.FirstOrDefault(n => n.Movie.id == movie.id && n.ShopingCartId == ShoppingCartId);

            if (shoppingCartItem != null)
            {
                if (shoppingCartItem.Amount > 1)
                {
                    shoppingCartItem.Amount--;
                }
                else
                {
                    _context.ShopingCartItems.Remove(shoppingCartItem);
                }
            }
            _context.SaveChanges();
        }

        public List<ShopingCartItem> GetShopingCartItem()
        {
            return ShopingCartItem ?? (ShopingCartItem = _context.ShopingCartItems.Where(n => n.ShopingCartId == ShoppingCartId).Include(n => n.Movie).ToList());
        }

        public double GetShoppingCartTotal() => _context.ShopingCartItems.Where(n => n.ShopingCartId == ShoppingCartId).Select(n => n.Movie.price * n.Amount).Sum();

        public async Task ClearShoppingCartAsync()
        {
            var items = await _context.ShopingCartItems.Where(n => n.ShopingCartId == ShoppingCartId).ToListAsync();
            _context.ShopingCartItems.RemoveRange(items);
            await _context.SaveChangesAsync();
        }
    }
}

