using OOPShop.Models;

namespace OOPShop.Repositories.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        public User? GetByName(string name);
        List<Order> getAllOrders(User user);
        Order? getOpenOrder(User user);
    }
}
