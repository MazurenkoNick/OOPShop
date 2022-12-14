using OOPShop.Models;
using OOPShop.Repositories.Interfaces;
using OOPShop.Services.Interfaces;

namespace OOPShop.Services
{
    public class OrderService : IOrderService
    {
        IOrderRepository orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            this.orderRepository = orderRepository;
        }

        public void Add(Order order)
        {
            orderRepository.Add(order);
        }

        public void Cancel(Order order)
        {
            order.Status = OrderStatus.Cancelled;
            orderRepository.Save();
        }

        public void Complete(Order order)
        {
            order.Status = OrderStatus.Completed;
            orderRepository.Save();
        }

        public bool Delete(int id)
        {
            return orderRepository.Delete(id);
        }

        public List<Order> GetAll()
        {
            return orderRepository.GetAll();
        }

        public List<OrderItem> GetAllItems(Order order)
        {
            return orderRepository.GetAllItems(order);
        }

        public Order? GetById(int id)
        {
            return orderRepository.GetById(id);
        }

        public void Save()
        {
            orderRepository.Save();
        }
    }
}
