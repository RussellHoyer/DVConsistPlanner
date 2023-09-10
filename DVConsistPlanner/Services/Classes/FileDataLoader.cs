using DVConsistPlanner.Models;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace DVConsistPlanner.Services.Classes
{
    public class FileDataLoader : IDataHandler
    {
        readonly ILogger<FileDataLoader> _logger;

        private readonly string _currentDir;
        private readonly string _dataFolder;
        private readonly string _filepath_Consists;
        private readonly string _filepath_Jobs;
        private readonly string _filepath_Locos;
        private readonly string _filepath_Stations;
        private readonly string _filepath_Licenses;

        public FileDataLoader(ILogger<FileDataLoader> logger)
        {
            _logger = logger;
            _currentDir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                "DVConsistPlanner");
            _dataFolder = Path.Combine(_currentDir, "data");
            Directory.CreateDirectory(_dataFolder);

            _filepath_Consists = Path.Combine(_dataFolder, "consists.json");
            _filepath_Jobs = Path.Combine(_dataFolder, "jobs.json");
            _filepath_Locos = Path.Combine(_dataFolder, "locos.json");
            _filepath_Stations = Path.Combine(_dataFolder, "stations.json");
            _filepath_Licenses = Path.Combine(_dataFolder, "licenses.json");
        }

        public IEnumerable<Consist> LoadConsists()
        {
            return JsonConvert.DeserializeObject<List<Consist>>(LoadJson(_filepath_Consists));
        }
        public void SaveConsists(IEnumerable<Consist> consists)
        {
            SaveFile(_filepath_Consists, JsonConvert.SerializeObject(consists));
        }

        public IEnumerable<Job> LoadJobs()
        {
            return JsonConvert.DeserializeObject<List<Job>>(LoadJson(_filepath_Jobs));
        }
        public void SaveJobs(IEnumerable<Job> jobs)
        {
            SaveFile(_filepath_Jobs, JsonConvert.SerializeObject(jobs));
        }

        public IEnumerable<License> LoadLicenses()
        {
            return JsonConvert.DeserializeObject<List<License>>(LoadJson(_filepath_Licenses));
        }
        public void SaveLicenses(IEnumerable<License> licenses)
        {
            SaveFile(_filepath_Licenses, JsonConvert.SerializeObject(licenses));
        }

        public IEnumerable<Locomotive> LoadLocomotives()
        {
            return JsonConvert.DeserializeObject<List<Locomotive>>(LoadJson(_filepath_Locos));
        }
        public void SaveLocomotives(IEnumerable<Locomotive> locomotives)
        {
            SaveFile(_filepath_Locos, JsonConvert.SerializeObject(locomotives));
        }

        public IEnumerable<Station> LoadStations()
        {
            return JsonConvert.DeserializeObject<List<Station>>(LoadJson(_filepath_Stations));
        }
        public void SaveStations(IEnumerable<Station> stations)
        {
            SaveFile(_filepath_Stations, JsonConvert.SerializeObject(stations));
        }

        private string LoadJson(string filepath)
        {
            string output = string.Empty;
            try
            {
                output = File.ReadAllText(filepath);
                _logger.LogDebug("File was loaded.");
            }
            catch (Exception ex)
            {
                _logger.LogError(string.Format("An error happened while loading file '{3}'!{0}{1}{2}",
                    Environment.NewLine, ex.Message, ex.StackTrace, filepath));
            }
            return output;
        }
        private void SaveFile(string filePath, string jsonData)
        {
            try
            {
                File.WriteAllText(filePath, jsonData);
                _logger.LogDebug("File was saved.");
            }
            catch (Exception ex)
            {
                _logger.LogError(string.Format("An error happened while saving file '{3}'!{0}{1}{2}",
                    Environment.NewLine, ex.Message, ex.StackTrace, filePath));
            }
        }
    }
}
