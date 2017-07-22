using BeerBeaconFacade;
using BeerBeaconLibrary.Helpers;
using BeerBeaconLibrary.Models;
using Microsoft.AspNetCore.Mvc;

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
            if(!Validator.Validate(buddy))
            {
                return false;
            }
            return DataController.SaveBuddy(buddy); 
        }

        [HttpPut("{id}/{status}/{drinks}")]
        public bool PutBuddy(int id, int? status, int? drinks)
        {
            if(!Validator.Validate(id) && !Validator.Validate(status) && !Validator.Validate(drinks))
            {
                return false;
            }
            return DataController.EditBuddy(id, status, drinks);
        }
    }
}