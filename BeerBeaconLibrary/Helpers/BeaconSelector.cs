using BeerBeaconLibrary.Enums;
using BeerBeaconLibrary.Interfaces;
using BeerBeaconLibrary.Models;

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
    }
}
