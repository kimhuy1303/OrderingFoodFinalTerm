using OrderingFoodFinalTerm;

namespace OrderingFoodFinalTerm.Interface
{
    public interface ICartRepository
    {
        
        void AddProduct(int idProduct, int userId, int quantity);
        ICollection<CartItem> GetCartItemById(int userId);

        Cart getCartByUserId(int userId);
        void removeCartItem(int idCartItem);
        void EditQuantityProduct(int cartProductId, int quantity);
        void SaveChange();

        

    }
}
