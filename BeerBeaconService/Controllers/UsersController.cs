using BeerBeaconFacade;
using BeerBeaconLibrary.Helpers;
using BeerBeaconLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using System;

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
        public User GetUser(int id, int mode)
        {
            var user = new User();
            try
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
            catch (Exception e)
            {
                var entry = new LogEntry(e);
                DataController.SaveLogEntry(entry);
                return user;
            }
        }

        [HttpPost]
        public bool PostUser([FromBody]User user)
        {
            var success = false;

            if (!Validator.Validate(user))
            {
                return success;
            }
            try
            {
                success = DataController.SaveUser(user);
            }
            catch (Exception e)
            {
                var entry = new LogEntry(e);
                DataController.SaveLogEntry(entry);
            }
            return success;
        }
    }
}
