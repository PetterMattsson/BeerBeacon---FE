using BeerBeaconFacade;
using BeerBeaconLibrary.Helpers;
using BeerBeaconLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace BeerBeaconService.Controllers
{
    [Produces("application/json")]
    [Route("api/Beacons")]
    public class BeaconsController : Controller
    {
        private DataController DataController { get; set; }

        public BeaconsController()
        {
            DataController = new DataController();
        }

        [HttpGet]
        public IEnumerable<Beacon> Get()
        {
            var beacons = new List<Beacon>();
            beacons = DataController.GetBeacons().ToList();

            return beacons;
        }

        [HttpGet("{latitude}/{longitude}")]
        public IEnumerable<Beacon> GetByCoords(double latitude, double longitude)
        {
            if (!Validator.ValidateLatitude(latitude))
            {
                return null;
            }
            if (!Validator.ValidateLongitude(longitude))
            {
                return null;
            }
            var beacons = new List<Beacon>();
            beacons = DataController.GetBeaconsByCoords(latitude, longitude).ToList();

            return beacons;
        }

        [HttpGet("{id}")]
        public Beacon Get(int id)
        {
            if (!Validator.Validate(id))
            {
                return null;
            }
            var beacon = DataController.GetBeacon(id);

            return beacon;
        }

        public bool Post([FromBody]Beacon beacon)
        {
            if (!Validator.Validate(beacon))
            {
                return false;
            }

            return DataController.PlaceBeacon(beacon);
        }

        [HttpPut("{id}/{drinks}")]
        public bool Put(int id, int drinks)
        {
            if (!Validator.Validate(id))
            {
                return false;
            }
            if (!Validator.Validate(drinks))
            {
                return false;
            }
            var success = DataController.ChangeNumberOfDrinks(id, drinks);

            return success;
        }

        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            if (!Validator.Validate(id))
            {
                return false;
            }
            return DataController.DeleteBeacon(id);
        }
    }
}