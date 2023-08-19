using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DVConsistPlanner.Models
{
    public class Station
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Abbreviation { get; set; }
        [NotMapped]
        public List<string> Services { get; set; }
        [NotMapped]
        public List<string> Tracks { get; set; }
        [NotMapped]
        public List<string> YardLegend { get; set; }
    }
}
