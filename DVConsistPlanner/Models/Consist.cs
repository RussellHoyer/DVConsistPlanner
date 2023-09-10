using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace DVConsistPlanner.Models
{
    /// <summary>
    /// A collection of locomotives and/or [train] cars (jobs) that comprise an entire train.
    /// </summary>
    public class Consist
    {
        public Consist()
        {
            Jobs = new List<Job>();
            Locomotives = new List<Locomotive>();
        }
        [Key]
        public int ID { get; set; }
        public string DisplayName { get; set; }

        public List<Job> Jobs { get; set; }
        public List<Locomotive> Locomotives { get; set; }

        [Precision(18,2)]
        public decimal TotalTonnage
        {
            get { return Locomotives.GetTotalTonnage() + Jobs.GetTotalTonnage(); }
        }
        [Precision(18, 2)]
        public decimal TotalLength
        {
            get { return Locomotives.GetTotalLength() + Jobs.GetTotalLength(); }
        }
        public int TotalPayout
        {
            get { return Jobs.GetTotalPayout(); }
        }
        public int TotalBonusPayout
        {
            get { return (int)(TotalPayout * 1.5); }
        }
    }

    // Consist specific extensions
    public static partial class Extensions
    {
        public static Consist? GetConsistById(this List<Consist> consistList, int id)
        {
            return consistList.FirstOrDefault(c => c.ID == id);
        }
    }
}
