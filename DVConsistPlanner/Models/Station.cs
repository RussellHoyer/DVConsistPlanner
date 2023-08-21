using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DVConsistPlanner.Models
{
    public class Station
    {
        /// <summary>
        /// Index.
        /// </summary>
        [Key]
        public int ID { get; set; }
        /// <summary>
        /// The name of the station.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// A two to three letter shorthand used to identify the station.
        /// </summary>
        public string Abbreviation { get; set; }
        /// <summary>
        /// Services available at this station.
        /// </summary>
        public ICollection<string> Services { get; set; }
        /// <summary>
        /// Track names located at this station.
        /// </summary>
        public ICollection<string> Tracks { get; set; }
        /// <summary>
        /// Yard descriptions.
        /// </summary>
        public ICollection<string> YardLegend { get; set; }
    }
}
