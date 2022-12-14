using OOPShop.Models;

namespace OOPShop.Services.Interfaces
{
    public interface IUserService
    {
        User SignUp(User user);
        bool LogIn(string name, string password);
        public void Add(User user);
        public bool Delete(int id);
        public List<User> GetAll();
        public User? GetById(int id);
    }
}
