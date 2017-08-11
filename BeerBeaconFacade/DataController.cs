using BeerBeaconBackend.Controllers;
using BeerBeaconLibrary.Models;
using BeerBeaconLibrary.Models.DTOs;
using System.Collections.Generic;

namespace BeerBeaconFacade
{
    public class DataController
    {
        public DataController()
        {

        }

        public IEnumerable<Beacon> GetBeacons()
        {
            var controller = new BeaconController();
            return controller.GetBeacons();
        }

        public IEnumerable<Beacon> GetBeaconsByCoords(double latitude, double longitude, int distance)
        {
            var controller = new BeaconController();
            return controller.GetBeaconsByCoordinate(latitude, longitude, distance);
        }

        public Beacon GetBeacon(int id)
        {
            var controller = new BeaconController();
            return controller.GetBeaconById(id);
        }

        public bool PlaceBeacon(Beacon beacon)
        {
            var controller = new BeaconController();
            return controller.PostBeacon(beacon);
        }

        public bool DeleteBeacon(int id)
        {
            var controller = new BeaconController();
            var buddyController = new BuddyController();
            buddyController.DeleteBuddiesByBeacon(id);
            return controller.DeleteBeacon(id);
        }

        public bool ChangeNumberOfDrinks(int id, int drinks)
        {
            var controller = new BeaconController();
            return controller.PutBeacon(id, drinks);
        }

        public User GetUser(int id)
        {
            var controller = new UserController();
            return controller.GetUserById(id);
        }

        public User GetUserByBeacon(int id)
        {
            var controller = new UserController();
            return controller.GetUserByBeacon(id);
        }

        public IEnumerable<BuddyDTO> GetBuddiesByBeacon(int id)
        {
            var controller = new BuddyController();
            return controller.GetBuddiesByBeacon(id);
        }

        public bool SaveUser(User user)
        {
            var controller = new UserController();
            return controller.PostUser(user);
        }

        public bool SaveBuddy(Buddy buddy)
        {
            var controller = new BuddyController();
            return controller.PostBuddy(buddy);
        }

        public bool EditBuddy(int id, int? status, int? drinks)
        {
            var controller = new BuddyController();
            return controller.PutBuddy(id, status, drinks);
        }

        public void SaveLogEntry(LogEntry entry)
        {
            var controller = new LogEntryController();
            controller.SaveLogEntry(entry);
        }
    }
}
