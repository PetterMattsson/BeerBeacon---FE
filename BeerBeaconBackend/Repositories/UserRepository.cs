using BeerBeaconLibrary.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

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
                    context.Entry(user).State = EntityState.Added;
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

        public void UpdateFriends(User user, List<int> friends)
        {
            using (var context = new BeaconContext())
            {
                try
                {
                    foreach (var friend in friends)
                    {
                        var userToAdd = context.Users.Where(u => u.FaceBookId == friend).FirstOrDefault();
                        if (userToAdd != null && !user.Friends.ToList().Contains(userToAdd))
                        {
                            user.Friends.ToList().Add(userToAdd);
                        }
                        else if (userToAdd == null && user.Friends.ToList().Contains(userToAdd))
                        {
                            user.Friends.ToList().Remove(userToAdd);
                        }
                    }
                    context.Entry(user).State = EntityState.Modified;
                    context.SaveChanges();
                }
                catch
                {
                    throw;
                }
            }
        }
    }
}

