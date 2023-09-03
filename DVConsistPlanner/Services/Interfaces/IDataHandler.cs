using DVConsistPlanner.Models;
using System.Collections.Generic;

namespace DVConsistPlanner.Services
{
    public interface IDataHandler
    {
        public IEnumerable<Consist> LoadConsists();
        public void SaveConsists(IEnumerable<Consist> consists);
        public IEnumerable<Job> LoadJobs();
        public void SaveJobs(IEnumerable<Job> jobs);
        public IEnumerable<Station> LoadStations();
        public void SaveStations(IEnumerable<Station> stations);
        public IEnumerable<Locomotive> LoadLocomotives();
        public void SaveLocomotives(IEnumerable<Locomotive> locomotives);
        public IEnumerable<License> LoadLicenses();
        public void SaveLicenses(IEnumerable<License> licenses);
    }
}
