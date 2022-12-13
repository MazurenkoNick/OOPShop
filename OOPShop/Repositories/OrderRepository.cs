using OOPShop.Repositories.Interfaces;
using OOPShop.Models;
using Microsoft.EntityFrameworkCore;

namespace OOPShop.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        AbstractApplicationDbContext db;

        // DI
        public OrderRepository(AbstractApplicationDbContext db)
        {
            this.db = db;
        }

        public void Add(Order entity)
        {
            db.Orders.Add(entity);
            db.SaveChanges();
        }

        public bool Delete(int id)
        {
            bool deleted = false;
            var order = db.Orders.FirstOrDefault(o => o.Id == id);

            if (order != null)
            {
                db.Orders.Remove(order);
                db.SaveChanges();
                deleted = true;
            }
            return deleted;
        }

        public List<Order> GetAll()
        {
            return db.Orders.ToList();
        }

        public Order? GetById(int id)
        {
           Order? order = db.Orders.FirstOrDefault(o => o.Id == id);
            return order;
        }
    }
}
