using BeerBeaconLibrary.Enums;
using BeerBeaconLibrary.Interfaces;
using BeerBeaconLibrary.Models;
using System.Collections.Generic;
using System.Linq;

namespace BeerBeaconLibrary.Helpers
{
    public static class BeaconSelector
    {
        public static IBeacon Select(BeaconType type)
        {
            switch(type)
            {
                case BeaconType.BeerBeacon:
                        return new Beacon();
                default:
                    return new Beacon();
            }
        }

        public static IEnumerable<Beacon> Select(List<Beacon> beacons, int mode)
        {
            
            switch(mode)
            {
                case (int)BeaconSelectionMode.ByCoordinate:
                    return beacons;
                case (int)BeaconSelectionMode.OnlyPrivate:
                    return beacons.Where(x => x.Private);
                case (int)BeaconSelectionMode.OnlyBuddies:
                    return beacons;
                default:
                    return beacons;
            }
        }
    }
}
