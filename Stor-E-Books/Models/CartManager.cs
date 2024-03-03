namespace Stor_E_Books.Models
{
    public class CartManager
    {

        private readonly List<Cart> _carts = new List<Cart>();

        public static List<CART_ITEM> cat = new List<CART_ITEM>();

        public Cart CreateCart()
        {
            var cart = new Cart();
            _carts.Add(cart);
            return cart;
        }

      

    }
}
