using TangyWeb_Client.ViewModels;

namespace TangyWeb_Client.Service.IService
{
    public interface ICartService
    {
        Task DecrementCart(ShoppingCart shoppingCart);
        Task IncrementCart(ShoppingCart shoppingCart);
    }
}
