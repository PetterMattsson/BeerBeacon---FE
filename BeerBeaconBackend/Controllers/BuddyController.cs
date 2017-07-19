using BeerBeaconBackend.Repositories;
using BeerBeaconLibrary.Models.DTOs;
using System.Collections.Generic;

namespace BeerBeaconBackend.Controllers
{
    public class BuddyController
    {
        public IEnumerable<BuddyDTO> GetBuddiesByBeacon(int id)
        {
            var userRepository = new UserRepository();
            var buddyRepository = new BuddyRepository();
            var buddies = buddyRepository.GetBuddiesByBeacon(id);
            var users = new List<BuddyDTO>();
            foreach (var buddy in buddies)
            {
                var user = userRepository.GetUser(buddy.UserId);
                var dto = new BuddyDTO
                {
                    User = user,
                    Status = buddy.Status
                };
                users.Add(dto);
            }
            return users;
        }
    }
}
