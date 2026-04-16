using Company.Data.Data.Shop;

namespace Company.PortalWWW.ViewModels
{
    public class CartViewModel
    {
        public List<CartItem> CartItems { get; set; } = [];
        public decimal Total { get; set; }
    }
}