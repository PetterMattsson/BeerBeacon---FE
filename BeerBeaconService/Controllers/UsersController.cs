using BeerBeaconFacade;
using BeerBeaconLibrary.Models;
using Microsoft.AspNetCore.Mvc;

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

        [HttpGet("{id}/{mode}")]
        public User GetUser(int id, int mode = 1)
        {
            switch (mode)
            {
                case 1:
                    return DataController.GetUser(id);
                case 2:
                    return DataController.GetUserByBeacon(id);
                default:
                    return DataController.GetUser(id);
            }
        }

        [HttpPost]
        public bool PostUser([FromBody]User user)
        {
            return DataController.SaveUser(user);
        }
    }
}
