using BeerBeaconLibrary.Models;
using System;

namespace BeerBeaconLibrary.Helpers
{
    public static class Validator
    {
        public static bool Validate(Beacon beacon)
        {
            return
                Validate(beacon.BeaconId) &&
                Validate(beacon.DrinkCounter) &&
                beacon.StartTime != DateTime.MinValue &&
                Validate(beacon.UserId) &&
                ValidateLatitude(beacon.Latitude) &&
                ValidateLongitude(beacon.Longitude);
        }

        public static bool Validate(User user)
        {
            return Validate(user.UserId);
        }

        public static bool Validate(int drinks)
        {
            return drinks > 0;
        }

        public static bool Validate(Guid id)
        {
            return id != null
                && Guid.TryParse(id.ToString(), out Guid guidOutput);
        }

        public static bool ValidateLatitude(double latitude)
        {
            return latitude <= 90
                && latitude >= -90;
        }

        public static bool ValidateLongitude(double longitude)
        {
            return longitude <= 180
                && longitude >= -180;
        }
    }
}
