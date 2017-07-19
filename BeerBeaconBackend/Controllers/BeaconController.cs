﻿using BeerBeaconBackend.Repositories;
using BeerBeaconLibrary.Models;
using GeoCoordinatePortable;
using System.Collections.Generic;

namespace BeerBeaconBackend.Controllers
{
    public class BeaconController
    {
        public IEnumerable<Beacon> GetBeacons()
        {
            var repository = new BeaconRepository();
            return repository.GetBeacons();
        }

        public IEnumerable<Beacon> GetBeaconsByCoordinate(double latitude, double longitude)
        {
            var coordinate = new GeoCoordinate(latitude, longitude);
            var repository = new BeaconRepository();
            return repository.GetBeaconsByCoords(coordinate);
        }

        public Beacon GetBeaconById(int id)
        {
            var repository = new BeaconRepository();
            return repository.GetBeacon(id);
        }

        public bool PostBeacon(Beacon beacon)
        {
            var repository = new BeaconRepository();
            return repository.PlaceBeacon(beacon);
        }

        public bool DeleteBeacon(int id)
        {
            var repository = new BeaconRepository();
            return repository.DeleteBeacon(id);
        }

        public bool PutBeacon(int id, int drinks)
        {
            var repository = new BeaconRepository();
            return repository.PutBeacon(id, drinks);
        }
    }
}