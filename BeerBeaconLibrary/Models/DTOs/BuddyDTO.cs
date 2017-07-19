using BeerBeaconLibrary.Enums;

namespace BeerBeaconLibrary.Models.DTOs
{
    public class BuddyDTO
    {
        public BuddyStatus Status { get; set; }
        public User User { get; set; }
    }
}
