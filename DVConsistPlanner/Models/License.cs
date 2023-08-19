using System.ComponentModel.DataAnnotations;

namespace DVConsistPlanner.Models
{
    public class License
    {
        [Key]
        public int ID { get; set; }
        public string LicenseName { get; set; }
        public int Cost { get; set; }
        public int? InsuranceCopay { get; set; }
        public decimal? TimeBonusDeadline { get; set; }
        public bool? RemovesDerailDiscount { get; set; }
        public string Unlocks { get; set; }
        public License? Prerequisites { get; set; }
    }
}
