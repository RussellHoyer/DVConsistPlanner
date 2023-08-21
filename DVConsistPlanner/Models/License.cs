using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DVConsistPlanner.Models
{
    public class License
    {
        [Key]
        public int ID { get; set; }
        [ForeignKey(nameof(Job.ID))]
        public int? JobID { get; set; }

        public string LicenseName { get; set; }
        public int Cost { get; set; }
        public int? InsuranceCopay { get; set; }
        [Precision(18, 2)]
        public decimal? TimeBonusDeadline { get; set; }
        public bool? RemovesDerailDiscount { get; set; }
        public string Unlocks { get; set; }
        public License? Prerequisites { get; set; }
    }
}
