using BeerBeaconLibrary.Models;
using GeoCoordinatePortable;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace BeerBeaconBackend.Repositories
{
    public class BeaconRepository
    {
        public BeaconRepository() { }

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
            var success = false;
            using (var context = new BeaconContext())
            {
                try
                {
                    context.Beacons.Add(beacon);
                    context.Entry(beacon).State = EntityState.Added;
                    context.SaveChanges();
                    success = GetBeacon(beacon.BeaconId) != null;
                }
                catch
                {
                    throw;
                }
            }
            return success;
        }

        public bool DeleteBeacon(int id)
        {
            var success = false;
            using (var context = new BeaconContext())
            {
                try
                {
                    var beacon = context.Beacons.Find(id);
                    context.Beacons.Remove(beacon);
                    context.Entry(beacon).State = EntityState.Deleted;
                    context.SaveChanges();
                    success = GetBeacon(beacon.BeaconId) == null;
                }
                catch
                {
                    throw;
                }
            }
            return success;
        }

        public bool PutBeacon(int id, int drinks)
        {
            var success = false;
            using (var context = new BeaconContext())
            {
                try
                {
                    var beacon = context.Beacons.Find(id);
                    context.Beacons.Attach(beacon);
                    beacon.DrinkCounter = drinks;
                    context.Entry(beacon).State = EntityState.Modified;
                    context.SaveChanges();
                    success = context.Beacons.Find(id).DrinkCounter == drinks;
                }
                catch
                {
                    throw;
                }
            }
            return success;
        }
    }
}
