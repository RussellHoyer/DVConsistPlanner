using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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

        public ICollection<Job> Jobs { get; set; }
        public ICollection<Locomotive> Locomotives { get; set; }

        [Precision(18,2)]
        public decimal TotalTonnage
        {
            get { return Jobs.Select(x => x.TrainMass).Sum(); }
        }
        [Precision(18, 2)]
        public decimal TotalLength
        {
            get { return Jobs.Select(x => x.TrainLength).Sum(); }
        }
        public int TotalPayout
        {
            get { return Jobs.Select(x => x.Payout).Sum(); }
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
