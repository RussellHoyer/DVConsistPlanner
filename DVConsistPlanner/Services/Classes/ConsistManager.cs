using DVConsistPlanner.Models;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;

namespace DVConsistPlanner.Services
{
    public class ConsistManager : IConsistManager
    {
        List<Consist> _activeConsists;
        readonly ILogger<ConsistManager> _logger;

        public ConsistManager(ILogger<ConsistManager> logger)
        {
            _logger = logger;
            _activeConsists = new List<Consist>();
        }

        #region Consists
        public Consist ActiveConsist { get; set; }
        public void SelectActiveConsist(int id)
        {
            ActiveConsist = _activeConsists.GetConsistById(id);
        }

        public void AddConsist(Consist consist)
        {
            if (_activeConsists.Contains(consist)) { return; }
            _activeConsists.Add(consist);
        }
        public void RemoveConsist(int id)
        {
            Consist removingConsist = _activeConsists.GetConsistById(id);
            if (removingConsist != null)
            {
                _activeConsists.Remove(removingConsist);
            }
        }
        public void UpdateConsist(int id, Consist consist)
        {
            Consist updatingConsist = _activeConsists.GetConsistById(id);
        }

        public Consist GetConsist(int id)
        {
            return _activeConsists.GetConsistById(id);
        }
        public IEnumerable<Consist> GetConsists()
        {
            _activeConsists.Add(DemoData.GetDemoConsist());
            SelectActiveConsist(_activeConsists[0].ID);
            return _activeConsists;
        }

        #endregion

        #region Jobs

        public void AddJob(Job job)
        {
            if (ActiveConsist.Jobs.GetJob(job.JobNumber) != null)
            {
                _logger.LogWarning("Job is already in the collection.");
            }
            ActiveConsist.Jobs.Add(job);
        }
        public void RemoveJob(int jobNumber)
        {
            throw new System.NotImplementedException();
        }
        public void UpdateJob(int jobNumber, Job job)
        {
            throw new System.NotImplementedException();
        }
        public Job GetJob(int jobNumber)
        {
            throw new System.NotImplementedException();
        }
        public IEnumerable<Job> GetJobs()
        {
            throw new System.NotImplementedException();
        }

        #endregion

        #region Locomotives

        public void AddLocomotive(Locomotive loco)
        {
            throw new System.NotImplementedException();
        }
        public void RemoveLocomotive(int locomotiveNumber)
        {
            throw new System.NotImplementedException();
        }
        public void UpdateLocomotive(int locoNumber, Locomotive locomotive)
        {
            throw new System.NotImplementedException();
        }
        public Locomotive GetLocomotive(int locoNumber)
        {
            throw new System.NotImplementedException();
        }
        public IEnumerable<Locomotive> GetLocomotives()
        {
            throw new System.NotImplementedException();
        }

        #endregion
    }
}
