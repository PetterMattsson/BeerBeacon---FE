using BeerBeaconLibrary.Enums;
using BeerBeaconLibrary.Interfaces;
using GeoCoordinatePortable;
using System;

namespace BeerBeaconLibrary.Models
{
    public class Beacon : IBeacon
    {
        public int BeaconId { get; set; }
        public int UserId { get; set; }
        public BeaconType BeaconType { get; set; }
        public decimal Longitude { get; set; }
        public decimal Latitude { get; set; }
        public string LocationName { get; set; }
        public string LocationLink { get; set; }
        public bool Private { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime
        {
            get
            {
                return StartTime.AddMinutes(DrinkCounter * 30);
            }
        }
        public TimeSpan Duration
        {
            get
            {
                return EndTime - StartTime;
            }
        }
        public int DrinkCounter { get; set; }
        public bool Image { get; set; }
        public GeoCoordinate GeoCoordinate
        {
            get
            {
                return new GeoCoordinate((double)Latitude, (double)Longitude);
            }
        }

        public virtual User User { get; set; }
    }
}
