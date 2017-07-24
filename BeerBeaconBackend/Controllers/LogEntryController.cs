using BeerBeaconBackend.Repositories;
using BeerBeaconLibrary.Models;

namespace BeerBeaconBackend.Controllers
{
    public class LogEntryController
    {
        public void SaveLogEntry(LogEntry entry)
        {
            var logRepository = new LogEntryRepository();
            logRepository.PostLogEntry(entry);
        }
    }
}

