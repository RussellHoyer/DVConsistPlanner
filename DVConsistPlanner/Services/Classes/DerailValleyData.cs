using DVConsistPlanner.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace DVConsistPlanner.Services
{
    internal static class DerailValleyData
    {
        #region Stations

        public static class Stations
        {
            static readonly List<Station> _stations;

            static Stations()
            {
                Stream stationData = Assembly.GetExecutingAssembly().GetManifestResourceStream("DVConsistPlanner.Resources.stations.json");

                StreamReader reader = new StreamReader(stationData);
                List<Station> stationList = JsonConvert.DeserializeObject<List<Station>>(reader.ReadToEnd());

                _stations = stationList;
            }

            public static List<Station> GetStationList() { return _stations; }
            public static Station GetStationByName(string name)
            {
                return _stations.FirstOrDefault(s => s.Name == name);
            }
            public static Station GetStationByAbbrev(string abbrev)
            {
                return _stations.FirstOrDefault(s => s.Abbreviation == abbrev);
            }
            // future proofing
            // SearchStation(string criteria)
            // GetStationByServices(string csvServiceList)
        }

        #endregion

        #region Locomotives

        public static class Locomotives
        {
            static readonly List<Locomotive> _locomotives;

            static Locomotives()
            {
                Stream stationData = Assembly.GetExecutingAssembly().GetManifestResourceStream("DVConsistPlanner.Resources.locomotives.json");

                StreamReader reader = new StreamReader(stationData);
                List<Locomotive> locomotiveList = JsonConvert.DeserializeObject<List<Locomotive>>(reader.ReadToEnd());

                _locomotives = locomotiveList;
            }

            public static Locomotive CreateLocomotive(string locoClassName, int locoNumber)
            {
                Locomotive output = GetLocomotiveByClass(locoClassName);
                output.LocoNumber = locoNumber;
                return output;
            }
            public static List<Locomotive> GetLocomotivesList() { return _locomotives; }
            public static Locomotive GetLocomotiveByClass(string locoClassName)
            {
                return _locomotives.FirstOrDefault(l => l.Classification == locoClassName);
            }
        }

        #endregion
    }
}
