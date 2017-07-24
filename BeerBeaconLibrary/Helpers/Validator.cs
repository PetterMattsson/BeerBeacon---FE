using BeerBeaconLibrary.Enums;
using BeerBeaconLibrary.Models;
using System;

namespace BeerBeaconLibrary.Helpers
{
    public static class Validator
    {
        public static bool Validate(Beacon beacon)
        {
            if(beacon == null)
            {
                return false;
            }
            return
                Validate(beacon.DrinkCounter) &&
                Validate(beacon.UserId) &&
                ValidateLatitude((double)beacon.Latitude) &&
                ValidateLongitude((double)beacon.Longitude);
        }

        public static bool Validate(User user)
        {
            if(user == null)
            {
                return false;
            }
            //return Validate(user.UserId);
            return true;
        }

        public static bool Validate(Buddy buddy)
        {
            return
                ValidateBuddyStatus((int)buddy.BuddyStatus) &&
                Validate(buddy.UserId) &&
                Validate(buddy.BeaconId);
        }

        public static bool ValidateBuddyStatus(int status)
        {
            return status < 3 && status > 0;
        }

        public static bool Validate(int value)
        {
            return value > 0;
        }

        public static bool Validate(int? value)
        {
            return value == null || value > 0;
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
