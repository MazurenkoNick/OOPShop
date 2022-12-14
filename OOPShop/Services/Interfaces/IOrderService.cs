using OOPShop.Models;

namespace OOPShop.Services.Interfaces
{
    public interface IOrderService
    {
        void Add(Order order);
        bool Delete(int id);
        List<Order> GetAll();
        List<OrderItem> GetAllItems(Order order);
        Order? GetById(int id);
        void Save();
        void Complete(Order order);
        void Cancel(Order order);
    }
}
