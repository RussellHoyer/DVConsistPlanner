using DVConsistPlanner.Models;
using System.Collections.Generic;

namespace DVConsistPlanner.Services
{
    public interface IConsistManager
    {
        // Consists
        void AddConsist(Consist consist);
        void RemoveConsist(int id);
        void UpdateConsist(int id, Consist consist);
        Consist GetConsist(int id);
        IEnumerable<Consist> GetConsists();

        // Jobs
        void AddJob(Job job);
        void RemoveJob(int jobNumber);
        void UpdateJob(int jobNumber, Job job);
        Job GetJob(int jobNumber);
        IEnumerable<Job> GetJobs();

        // Locos
        void AddLocomotive(Locomotive loco);
        void RemoveLocomotive(int locomotiveNumber);
        void UpdateLocomotive(int locoNumber,  Locomotive locomotive);
        Locomotive GetLocomotive(int locoNumber);
        IEnumerable<Locomotive> GetLocomotives();
    }
}
