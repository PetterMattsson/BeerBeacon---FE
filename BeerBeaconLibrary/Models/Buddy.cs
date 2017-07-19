using BeerBeaconLibrary.Enums;
using BeerBeaconLibrary.Interfaces;
using System;

namespace BeerBeaconLibrary.Models
{
    public class Buddy : IBuddy
    {
        public int BuddyId { get; set; }
        public int UserId { get; set; }
        public int BeaconId { get; set; }
        public BuddyStatus Status { get; set; }
        public int ETAdrinks { get; set; }
        public DateTime ETA
        {
            get
            {
                return DateTime.Now.ToUniversalTime().AddMinutes(30 * ETAdrinks);
            }
        }

        public virtual User User { get; set; }
        public virtual Beacon Beacon { get; set; }
    }
}
