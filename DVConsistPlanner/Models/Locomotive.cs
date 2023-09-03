using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace DVConsistPlanner.Models
{
    public class Locomotive
    {
        public Locomotive()
        {

        }
        public Locomotive(int id)
        {
            ID = id;
        }
        /// <summary>
        /// Index identification.
        /// </summary>
        [Key]
        public int ID { get; set; }
        /// <summary>
        /// The ID of the <see cref="Consist"/> that this <see cref="Locomotive"/> is part of.
        /// </summary>
        [ForeignKey(nameof(Consist.ID))]
        public int? ConsistID { get; set; }
        /// <summary>
        /// The ID number (specifically) for the loco.
        /// </summary>
        public int LocoNumber { get; set; }
        /// <summary>
        /// Classification of the locotmotive (i.e. DE2, DE6, etc).
        /// </summary>
        public string Classification { get; set; }
        /// <summary>
        /// Tractive effort type.
        /// </summary>
        public string Type { get; set; }
        /// <summary>
        /// Cost of the license for said locomotive.
        /// </summary>
        public int LicenseCost { get; set; }
        /// <summary>
        /// Mass in tonnes.
        /// </summary>
        public int Mass { get; set; }
        /// <summary>
        /// Length in meters.
        /// </summary>
        [Precision(18, 2)]
        public decimal Length { get; set; }
        /// <summary>
        /// How much pulling power the locomotive has, in tonnes.
        /// </summary>
        public int LoadRating { get; set; }

        /// <summary>
        /// The display name for the locomotive.
        /// </summary>
        [NotMapped]
        public string TrainID => $"L-{LocoNumber:D3}";

        /// <summary>
        /// Copy all non-field property values from the parameter object to this object (<see cref="ID"/>, <see cref="ConsistID"/>, and <see cref="LocoNumber"/> are not copied).
        /// </summary>
        /// <param name="fromLoco"></param>
        public void CopyFrom(Locomotive fromLoco)
        {
            if (fromLoco == null) return;

            Classification = fromLoco.Classification;
            Type = fromLoco.Type;
            LicenseCost = fromLoco.LicenseCost;
            Mass = fromLoco.Mass;
            Length = fromLoco.Length;
            LoadRating = fromLoco.LoadRating;
        }
    }
    // Locomotive specific extensions
    public static partial class Extensions
    {
        public static int GetTotalTonnage(this List<Locomotive> locomotives)
        {
            return locomotives.Select(l => l.Mass).Sum();
        }
        public static decimal GetTotalLength(this List<Locomotive> locomotives)
        {
            return locomotives.Select(l => l.Length).Sum();
        }
        public static int GetTotalLoadRating(this List<Locomotive> locomotives)
        {
            return locomotives.Select(l => l.LoadRating).Sum();
        }
    }
}
