using BeerBeaconLibrary.Models;
using Microsoft.EntityFrameworkCore;

namespace BeerBeaconBackend.Repositories
{
    public class UserRepository
    {
        public UserRepository() { }

        public User GetUser(int id)
        {
            var user = new User();
            using (var context = new BeaconContext())
            {
                try
                {
                    user = context.Users.Find(id);
                }
                catch
                {
                    throw;
                }
            }
            return user;
        }

        public bool SaveUser(User user)
        {
            var result = false;
            using (var context = new BeaconContext())
            {
                try
                {
                    context.Users.Add(user);
                    context.SaveChanges();
                    result = GetUser(user.UserId) != null;
                }
                catch
                {
                    throw;
                }
            }
            return result;
        }

        public bool DeleteUser(int id)
        {
            var result = false;
            using (var context = new BeaconContext())
            {
                try
                {
                    var user = context.Users.Find(id);
                    context.Users.Remove(user);
                    context.Entry(user).State = EntityState.Deleted;
                    context.SaveChanges();
                    result = GetUser(id) == null;
                }
                catch
                {
                    throw;
                }
            }
            return result;
        }
    }
}
