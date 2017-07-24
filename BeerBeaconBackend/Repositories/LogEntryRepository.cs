using BeerBeaconLibrary.Models;
using Microsoft.EntityFrameworkCore;

namespace BeerBeaconBackend.Repositories
{
    public class LogEntryRepository
    {
        public LogEntryRepository() { }

        public void PostLogEntry(LogEntry entry)
        {
            using (var context = new BeaconContext())
            {
                context.LogEntries.Add(entry);
                context.Entry(entry).State = EntityState.Added;
                context.SaveChanges();
            }
        }
    }
}
