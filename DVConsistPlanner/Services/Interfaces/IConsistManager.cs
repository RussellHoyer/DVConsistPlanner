using DVConsistPlanner.Models;
using System.Collections.Generic;

namespace DVConsistPlanner.Services
{
    public interface IConsistManager
    {
        // Consists
        Consist ActiveConsist { get; }
        void AddConsist(Consist consist);
        Consist GetNewConsist();
        void RemoveConsist(int id);
        void UpdateConsist(Consist consist);
        Consist GetConsist(int id);
        IEnumerable<Consist> GetConsists();

        // Jobs
        void AddJob(Job job);
        Job GetNewJob();
        void RemoveJob(int id);
        void UpdateJob(Job job);
        Job GetJob(int id);
        IEnumerable<Job> GetJobs();

        // Locos
        void AddLocomotive(Locomotive loco);
        Locomotive GetNewLocomotive();
        void RemoveLocomotive(int id);
        void UpdateLocomotive(Locomotive locomotive);
        Locomotive GetLocomotive(int id);
        IEnumerable<Locomotive> GetLocomotives();
    }
}
