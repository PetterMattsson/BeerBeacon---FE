using BeerBeaconLibrary.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace BeerBeaconBackend.Repositories
{
    public class BuddyRepository
    {
        public BuddyRepository() { }

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

        public bool PostBuddy(Buddy buddy)
        {
            var result = false;
            using (var context = new BeaconContext())
            {
                try
                {
                    context.Buddies.Add(buddy);
                    context.Entry(buddy).State = EntityState.Added;
                    context.SaveChanges();
                    result = context.Buddies.Find(buddy.BuddyId) != null;
                }
                catch
                {
                    throw;
                }
                return result;
            }
        }

        public Buddy GetBuddy(int id)
        {
            var buddy = new Buddy();
            using (var context = new BeaconContext())
            {
                try
                {
                    buddy = context.Buddies.Find(id);
                }
                catch
                {
                    throw;
                }
                return buddy;
            }
        }

        public bool PutBuddy(Buddy buddy)
        {
            var result = false;
            using (var context = new BeaconContext())
            {
                try
                {
                    context.Buddies.Attach(buddy);
                    context.Entry(buddy).State = EntityState.Modified;
                    context.SaveChanges();
                    result = true;
                }
                catch
                {
                    throw;
                }
                return result;
            }
        }

        public void DeleteByBeaconId(int id)
        {
            using (var context = new BeaconContext())
            {
                try
                {
                    var buddies = context.Buddies.Where(x => x.BeaconId == id);
                    buddies.ToList().ForEach(x => context.Entry(x).State = EntityState.Deleted);
                    context.RemoveRange(buddies);
                    context.SaveChanges();
                }
                catch
                {
                    throw;
                }
            }
        }
    }
}
