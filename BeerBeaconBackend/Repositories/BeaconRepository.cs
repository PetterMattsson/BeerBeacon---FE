using BeerBeaconLibrary.Models;
using GeoCoordinatePortable;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace BeerBeaconBackend.Repositories
{
    public class BeaconRepository
    {
        //private string ConnectionString;

        public BeaconRepository() { }
        //public BeaconRepository(string connectionString)
        //{
        //    ConnectionString = connectionString;
        //}

        public IEnumerable<Beacon> GetBeacons()
        {
            var result = new List<Beacon>();
            using (var context = new BeaconContext())
            {
                try
                {
                    result = context.Beacons.ToList();
                }
                catch
                {
                    throw;
                }
            }
            return result;
        }

        public IEnumerable<Beacon> GetBeaconsByCoords(GeoCoordinate center)
        {
            var result = new List<Beacon>();
            using (var context = new BeaconContext())
            {
                try
                {
                    var beacons = context.Beacons.Where(x => x.GeoCoordinate.GetDistanceTo(center) < 500).ToList();
                    result = beacons.ToList();
                }
                catch
                {
                    throw;
                }
            }
            return result;
        }

        public Beacon GetBeacon(int id)
        {
            var beacon = new Beacon();
            using (var context = new BeaconContext())
            {
                try
                {
                    beacon = context.Beacons.Find(id);
                }
                catch
                {
                    throw;
                }
            }
            return beacon;
        }

        public bool PlaceBeacon(Beacon beacon)
        {
            var result = false;
            using (var context = new BeaconContext())
            {
                try
                {
                    context.Beacons.Add(beacon);
                    context.SaveChanges();
                    result = GetBeacon(beacon.BeaconId) != null;
                }
                catch
                {
                    throw;
                }
            }
            return result;
        }

        public bool DeleteBeacon(int id)
        {
            var result = false;
            using (var context = new BeaconContext())
            {
                try
                {
                    var beacon = context.Beacons.Find(id);
                    context.Beacons.Remove(beacon);
                    context.Entry(beacon).State = EntityState.Deleted;
                    context.SaveChanges();
                    result = GetBeacon(beacon.BeaconId) == null;
                }
                catch
                {
                    throw;
                }
            }
            return result;
        }

        public bool PutBeacon(int id, int drinks)
        {
            var result = false;
            using (var context = new BeaconContext())
            {
                try
                {
                    var beacon = context.Beacons.Find(id);
                    context.Beacons.Attach(beacon);
                    beacon.DrinkCounter = drinks;
                    context.Entry(beacon).State = EntityState.Modified;
                    context.SaveChanges();
                    result = context.Beacons.Find(id).DrinkCounter == drinks;
                }
                catch
                {
                    throw;
                }
            }
            return result;
        }
    }
}
