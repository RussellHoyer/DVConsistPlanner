using DVConsistPlanner.Models;
using Newtonsoft.Json;

namespace DVConsistPlanner.CmdTool
{
    static class Scraps
    {
        internal static void ScrapPile()
        {
            Station station = new()
            {
                Name = "Military Base",
                Abbreviation = "MB",
                Services = new List<string>
                {
                    "None"
                },
                Tracks = new List<string>
                {
                    "A1L",
                    "A2S",
                    "B2O",
                    "B3O",
                    "B4I",
                    "B5O",
                    "B6S"
                },
                YardLegend = new List<string>
                {
                    "A-Overview/Parking",
                    "B-Transfer Yard"
                }
            };


            //var jsonData = JsonConvert.SerializeObject(station, Formatting.Indented);

            //string fileName = Path.Combine(Environment.CurrentDirectory, "object.json");
            //File.WriteAllText(fileName, jsonData);

            //Console.WriteLine($"Wrote STATION {station.Name} to: {fileName}");
            //=====================================================================================

            List<Locomotive> locos = new();

            Locomotive de2 = new()
            {
                Classification = "DE2",
                Type = "Diesel-Electric",
                LicenseCost = 0,
                Mass = 38,
                LoadRating = 260,
                Length = 7.49M
            };
            Locomotive de6 = new()
            {
                Classification = "DE6",
                Type = "Diesel-Electric",
                LicenseCost = 200000,
                Mass = 125,
                LoadRating = 1340,
                Length = 18.78M
            };
            Locomotive dm3 = new()
            {
                Classification = "DM3",
                Type = "Diesel-Mechanical",
                LicenseCost = 30000,
                Mass = 52,
                LoadRating = 960,
                Length = 8.5M
            };
            Locomotive dh4 = new()
            {
                Classification = "DH4",
                Type = "Diesel-Hydraulic",
                LicenseCost = 50000,
                Mass = 80,
                LoadRating = 730,
                Length = 13.0M
            };
            Locomotive s060 = new()
            {
                Classification = "S060",
                Type = "Steam",
                LicenseCost = 20000,
                Mass = 45,
                LoadRating = 500,
                Length = 9.1M
            };
            Locomotive s282 = new()
            {
                Classification = "S282",
                Type = "Steam",
                LicenseCost = 50000,
                Mass = 150,
                LoadRating = 1100,
                Length = 21.15M
            };
            locos.Add(de2);
            locos.Add(de6);
            locos.Add(dm3);
            locos.Add(dh4);
            locos.Add(s060);
            locos.Add(s282);


            //var jsonData = JsonConvert.SerializeObject(locos, Formatting.Indented);

            //string fileName = Path.Combine(Environment.CurrentDirectory, "object.json");
            //File.WriteAllText(fileName, jsonData);

            //Console.WriteLine($"Wrote LOCOS to: {fileName}");
        }
    }
}
