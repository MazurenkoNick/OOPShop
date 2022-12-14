using OOPShop.Repositories.Interfaces;
using OOPShop.Models;
using Microsoft.EntityFrameworkCore;

namespace OOPShop.Repositories
{
    public class UserRepository : IUserRepository
    {
        AbstractApplicationDbContext db;

        // DI
        public UserRepository(AbstractApplicationDbContext db)
        {
            this.db = db;
        }

        public void Add(User entity)
        {
            db.Users.Add(entity);
            db.SaveChanges();
        }

        public bool Delete(int id)
        {
            bool deleted = false;
            var user = db.Users.FirstOrDefault(u => u.Id == id);

            if (user != null)
            {
                db.Users.Remove(user);
                db.SaveChanges();
                deleted = true;
            }
            return deleted;
        }

        public List<User> GetAll()
        {
            return db.Users.ToList();
        }

        public List<Order> getAllOrders(User user)
        {
            // get all orders of the user who is passed as an argument to the method
            return db.Orders.FromSqlRaw(String.Format("SELECT * FROM orders WHERE orders.UserId = {0}", user.Id))
                            .ToList();
        }

        public User? GetById(int id)
        {
            User? user = db.Users.FirstOrDefault(u => u.Id == id);
            return user;
        }

        public User? GetByName(string name)
        {
            User? user = db.Users.FirstOrDefault(u => u.Name == name);
            return user;
        }

        public void Save()
        {
            db.SaveChanges();
        }
    }
}
