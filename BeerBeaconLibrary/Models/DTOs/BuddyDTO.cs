using BeerBeaconLibrary.Enums;
using System;

namespace BeerBeaconLibrary.Models.DTOs
{
    public class BuddyDTO
    {
        public BuddyStatus Status { get; set; }
        public DateTime ETA { get; set; }
        public User User { get; set; }
    }
}
