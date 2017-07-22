using BeerBeaconBackend.Repositories;
using BeerBeaconLibrary.Enums;
using BeerBeaconLibrary.Models;
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
                    Status = buddy.BuddyStatus,
                    ETA = buddy.ETA
                };
                users.Add(dto);
            }
            return users;
        }

        public void DeleteBuddiesByBeacon(int id)
        {
            var buddyRepository = new BuddyRepository();
            buddyRepository.DeleteByBeaconId(id);
        }

        public bool PostBuddy(Buddy buddy)
        {
            var buddyRepository = new BuddyRepository();
            return buddyRepository.PostBuddy(buddy);
        }

        public bool PutBuddy(int id, int? status, int? drinks)
        {
            var buddyRepository = new BuddyRepository();
            var buddy = buddyRepository.GetBuddy(id);
            var newStatus = TurnToInt(status);
            var newDrinks = TurnToInt(drinks);
            if(newStatus > 0)
            {
                buddy.BuddyStatus = (BuddyStatus)newStatus;
            }
            if(newDrinks > 0)
            {
                buddy.ETAdrinks = newDrinks;
            }
            return buddyRepository.PutBuddy(buddy);
        }

        private int TurnToInt(int? value)
        {
            return value ?? -1;
        }
    }
}
