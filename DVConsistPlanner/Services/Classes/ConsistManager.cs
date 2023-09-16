using DVConsistPlanner.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DVConsistPlanner.Services
{
    public class ConsistManager : IConsistManager
    {
        List<Consist> _activeConsists;
        Consist _activeConsist;
        readonly ILogger<ConsistManager> _logger;
        IDataHandler _dataLoader;

        public ConsistManager(ILogger<ConsistManager> logger, IDataHandler dataHandler)
        {
            _logger = logger;
            _activeConsists = new List<Consist>();
            _activeConsist = new Consist();
            _dataLoader = dataHandler;

            Initialize();
        }

        public void Initialize()
        {
            _logger.LogDebug("ConsistManager-Loading data...");
            _activeConsists = _dataLoader.LoadConsists().ToList();
            if (_activeConsists.Count == 0 )
            {
                _activeConsists.Add(new Consist());
            }
            SelectActiveConsist(_activeConsists[0].ID);

            _logger.LogDebug("ConsistManager-Initialized");
        }
        private void SaveData()
        {
            try
            {
                _dataLoader.SaveConsists(_activeConsists);
            }
            catch (Exception ex)
            {
                _logger.LogError(string.Format("There was an error saving!{0}{1}{2}", Environment.NewLine,
                    ex.Message, ex.StackTrace));
            }
        }

        #region Consists
        public Consist ActiveConsist { get { return _activeConsist; } }
        public void SelectActiveConsist(int id)
        {
            _activeConsist = _activeConsists.GetConsistById(id);
        }

        public void AddConsist(Consist consist)
        {
            if (_activeConsists.Contains(consist) || consist == null) 
                return;

            _activeConsists.Add(consist);
            SaveData();
        }
        public Consist GetNewConsist()
        {
            return new Consist() { ID = _activeConsists.Count + 1 };
        }
        public void ResetConsist()
        {
            _activeConsist.Jobs = new List<Job>() { GetNewJob() };
            _activeConsist.Locomotives = new List<Locomotive>() { GetNewLocomotive() };
        }
        public void RemoveConsist(int id)
        {
            Consist removingConsist = _activeConsists.GetConsistById(id);
            if (removingConsist != null)
            {
                _activeConsists.Remove(removingConsist);
            }
            SaveData();
        }
        public void UpdateConsist(Consist editedConsist)
        {
            if (editedConsist == null) return;

            Consist updatingConsist = _activeConsists.GetConsistById(editedConsist.ID);
            if (updatingConsist != null)
            {
                _activeConsists[_activeConsists.IndexOf(updatingConsist)] = editedConsist;
            }
            else
            {
                _activeConsists.Add(editedConsist);
            }
            SaveData();
        }

        public Consist GetConsist(int id)
        {
            Consist foundConsist;
            foundConsist = _activeConsists.GetConsistById(id);
            if (foundConsist == null) return new();

            SelectActiveConsist(foundConsist.ID);
            return foundConsist;
        }
        public IEnumerable<Consist> GetConsists()
        {
            Initialize();
            return _activeConsists;
        }

        #endregion

        #region Jobs

        public void AddJob(Job job)
        {
            if (_activeConsist.Jobs.GetJob(job.ID) != null)
            {
                _logger.LogWarning("Job is already in the collection.");
                UpdateJob(job);
                return;
            }
            _activeConsist.Jobs.Add(job);
            SaveData();
        }
        public Job GetNewJob()
        {
            return new Job() { ID = _activeConsist.Jobs.Count + 1 };
        }
        public void RemoveJob(int id)
        {
            _activeConsist.Jobs.Remove(GetJob(id));
            SaveData();
        }
        public void UpdateJob(Job job)
        {
            if (job == null) return;

            Job updatingJob = _activeConsist.Jobs.GetJob(job.ID);
            if (updatingJob != null)
            {
                _activeConsist.Jobs[_activeConsist.Jobs.IndexOf(updatingJob)] = job;
            }
            SaveData();
        }
        public Job GetJob(int id)
        {
            return _activeConsist.Jobs.GetJob(id);
        }
        public IEnumerable<Job> GetJobs()
        {
            return _activeConsist.Jobs;
        }

        #endregion

        #region Locomotives

        public void AddLocomotive(Locomotive loco)
        {
            _activeConsist.Locomotives.Add(loco);
            SaveData();
        }
        public Locomotive GetNewLocomotive()
        {
            return new Locomotive() { ID = _activeConsist.Locomotives.Count + 1 };
        }
        public void RemoveLocomotive(int id)
        {
            _activeConsist.Locomotives.RemoveAll(l => l.ID == id);
            SaveData();
        }
        public void UpdateLocomotive(Locomotive locomotive)
        {
            Locomotive updatingLoco = _activeConsist.Locomotives.FirstOrDefault(l => l.ID == locomotive.ID);
            if (updatingLoco != null)
            {
                _activeConsist.Locomotives[_activeConsist.Locomotives.IndexOf(updatingLoco)] = locomotive;
            }
            SaveData();
        }
        public Locomotive GetLocomotive(int id)
        {
            return _activeConsist.Locomotives.FirstOrDefault(l => l.ID == id);
        }
        public IEnumerable<Locomotive> GetLocomotives()
        {
            return _activeConsist.Locomotives;
        }

        #endregion
    }
}
