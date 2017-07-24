using BeerBeaconFacade;
using BeerBeaconLibrary.Helpers;
using BeerBeaconLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using System;

namespace BeerBeaconService.Controllers
{
    [Produces("application/json")]
    [Route("api/Buddies")]
    public class BuddiesController : Controller
    {
        private DataController DataController { get; set; }

        public BuddiesController()
        {
            DataController = new DataController();
        }

        [HttpPost]
        public bool PostBuddy([FromBody]Buddy buddy)
        {
            if (!Validator.Validate(buddy))
            {
                return false;
            }
            try
            {
                return DataController.SaveBuddy(buddy);
            }
            catch (Exception e)
            {
                var entry = new LogEntry(e);
                DataController.SaveLogEntry(entry);
                return false;
            }
        }

        [HttpPut("{id}/{status}/{drinks}")]
        public bool PutBuddy(int id, int? status, int? drinks)
        {
            if (!Validator.Validate(id) && !Validator.Validate(status) && !Validator.Validate(drinks))
            {
                return false;
            }
            try
            {
                return DataController.EditBuddy(id, status, drinks);
            }
            catch (Exception e)
            {
                var entry = new LogEntry(e);
                DataController.SaveLogEntry(entry);
                return false;
            }
        }
    }
}