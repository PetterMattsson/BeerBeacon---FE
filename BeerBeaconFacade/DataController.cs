using BeerBeaconBackend.Controllers;
using BeerBeaconLibrary.Models;
using BeerBeaconLibrary.Models.DTOs;
using System.Collections.Generic;

namespace BeerBeaconFacade
{
    public class DataController
    {
        //private string _connectionString = "Data Source=beerbeacondbserver.database.windows.net;Initial Catalog=BeerBeaconDB;Integrated Security=False;User ID=dbserverlogin;Password=********;Connect Timeout=60;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public DataController()
        {

        }

        public IEnumerable<Beacon> GetBeacons()
        {
            var controller = new BeaconController();
            return controller.GetBeacons();
        }

        public IEnumerable<Beacon> GetBeaconsByCoords(double latitude, double longitude)
        {
            var controller = new BeaconController();
            return controller.GetBeaconsByCoordinate(latitude, longitude);
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
    }
}
