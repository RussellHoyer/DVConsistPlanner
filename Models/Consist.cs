using System.Collections.Generic;
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

        public int ID { get; set; }
        public List<Job> Jobs { get; set; }
        public List<Locomotive> Locomotives { get; set; }

        public decimal TotalTonnage
        {
            get { return Jobs.Select(x => x.TrainMass).Sum(); }
        }
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
