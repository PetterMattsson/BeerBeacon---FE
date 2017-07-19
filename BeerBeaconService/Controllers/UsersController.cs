using BeerBeaconFacade;
using BeerBeaconLibrary.Helpers;
using BeerBeaconLibrary.Models;
using BeerBeaconLibrary.Models.DTOs;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace BeerBeaconService.Controllers
{
    [Produces("application/json")]
    [Route("api/Users")]
    public class UsersController : Controller
    {
        private DataController DataController { get; set; }

        public UsersController()
        {
            DataController = new DataController();
        }

        [HttpGet("{id}")]
        public User GetUser(int id)
        {
            return DataController.GetUser(id);
        }

        [HttpGet("{id}")]
        public User GetUserByBeacon(int beaconId)
        {
            return DataController.GetUserByBeacon(beaconId);
        }

        [HttpGet("{id}")]
        public IEnumerable<BuddyDTO> GetVisitorsByBeacon(int beaconId)
        {
            var buddies = DataController.GetBuddiesByBeacon(beaconId);
            return buddies;
        }

        [HttpPost]
        public bool PostUser([FromBody]User user)
        {
            if (!Validator.Validate(user))
            {
                return false;
            }
            return DataController.SaveUser(user);
        }
    }
}
