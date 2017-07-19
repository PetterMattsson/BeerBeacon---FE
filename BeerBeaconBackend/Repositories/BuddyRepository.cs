using BeerBeaconLibrary.Models;
using System.Collections.Generic;
using System.Linq;

namespace BeerBeaconBackend.Repositories
{
    public class BuddyRepository
    {
        //private string ConnectionString;

        public BuddyRepository() { }
        //public BuddyRepository(string connectionString)
        //{
        //    ConnectionString = connectionString;
        //}

        public IEnumerable<Buddy> GetBuddiesByBeacon(int id)
        {
            var result = new List<Buddy>();
            using (var context = new BeaconContext())
            {
                try
                {
                    result = context.Buddies.Where(x => x.BeaconId == id).ToList();
                }
                catch
                {
                    throw;
                }
            }
            return result;
        }
    }
}
