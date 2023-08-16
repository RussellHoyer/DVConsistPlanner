using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;

namespace DVConsistPlanner.Models
{
    public class Station
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Abbreviation { get; set; }
        public List<string> Services { get; set; }
        public List<string> Tracks { get; set; }
        public List<string> YardLegend { get; set; }
    }
}
