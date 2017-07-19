using BeerBeaconBackend.Repositories;
using BeerBeaconLibrary.Models;

namespace BeerBeaconBackend.Controllers
{
    public class UserController
    {
        public User GetUserById(int id)
        {
            var repository = new UserRepository();
            return repository.GetUser(id);
        }

        public User GetUserByBeacon(int id)
        {
            var beaconRepository = new BeaconRepository();
            var userRepository = new UserRepository();
            var beacon = beaconRepository.GetBeacon(id);
            if (beacon == null)
            {
                return null;
            }
            return userRepository.GetUser(beacon.UserId);
        }

        public bool PostUser(User user)
        {
            var userRepository = new UserRepository();
            return userRepository.SaveUser(user);
        }
    }
}
