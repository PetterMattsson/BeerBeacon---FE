using System.Collections.Generic;

namespace BeerBeaconLibrary.Models
{
    public class User
    {
        public int UserId { get; set; }
        public int FaceBookId { get; set; }
        public string InstagramId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }

        public virtual IEnumerable<Beacon> Beacons { get; set; }
        public virtual IEnumerable<User> Friends { get; set; }
    }
}
