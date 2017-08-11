using BeerBeaconFacade;
using BeerBeaconLibrary.Helpers;
using BeerBeaconLibrary.Models;
using BeerBeaconLibrary.Models.DTOs;
using Microsoft.AspNetCore.Mvc;
using System;
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
            try
            {
                beacons = DataController.GetBeacons().ToList();
            }
            catch (Exception e)
            {
                var entry = new LogEntry(e);
                DataController.SaveLogEntry(entry);
            }
            return beacons;
        }

        [HttpGet("{latitude}/{longitude}/{mode}/{distance}")]
        public IEnumerable<Beacon> GetByCoords(double latitude, double longitude, int mode, int distance)
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
            try
            {
                beacons = DataController.GetBeaconsByCoords(latitude, longitude, distance).ToList();
            }
            catch (Exception e)
            {
                var entry = new LogEntry(e);
                DataController.SaveLogEntry(entry);
            }
            return BeaconSelector.Select(beacons, mode);
        }

        [HttpGet("{id}")]
        public Beacon Get(int id)
        {
            if (!Validator.Validate(id))
            {
                return null;
            }
            var beacon = new Beacon();
            try
            {
                beacon = DataController.GetBeacon(id);
            }
            catch (Exception e)
            {
                var entry = new LogEntry(e);
                DataController.SaveLogEntry(entry);
            }
            return beacon;
        }

        [HttpPost]
        public bool Post([FromBody]Beacon beacon)
        {
            var success = false;
            if (!Validator.Validate(beacon))
            {
                return success;
            }
            try
            {
                success = DataController.PlaceBeacon(beacon);
            }
            catch (Exception e)
            {
                var entry = new LogEntry(e);
                DataController.SaveLogEntry(entry);
            }
            return success;
        }

        [HttpPut("{id}/{drinks}")]
        public bool Put(int id, int drinks)
        {
            var success = false;
            if (!Validator.Validate(id))
            {
                return success;
            }
            if (!Validator.Validate(drinks))
            {
                return success;
            }

            try
            {
                success = DataController.ChangeNumberOfDrinks(id, drinks);
            }
            catch (Exception e)
            {
                var entry = new LogEntry(e);
                DataController.SaveLogEntry(entry);
            }
            return success;
        }

        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            var success = false;

            if (!Validator.Validate(id))
            {
                return success;
            }
            try
            {
                success = DataController.DeleteBeacon(id);
            }
            catch (Exception e)
            {
                var entry = new LogEntry(e);
                DataController.SaveLogEntry(entry);
            }
            return success;
        }

        [HttpGet("{id}/buddies")]
        public IEnumerable<BuddyDTO> GetBuddiesByBeacon(int id)
        {
            if (!Validator.Validate(id))
            {
                return new List<BuddyDTO>();
            }
            var buddies = new List<BuddyDTO>();
            try
            {
                buddies = DataController.GetBuddiesByBeacon(id).ToList();
            }
            catch (Exception e)
            {
                var entry = new LogEntry(e);
                DataController.SaveLogEntry(entry);
            }
            return buddies;
        }
    }
}