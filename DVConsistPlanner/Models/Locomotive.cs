﻿using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DVConsistPlanner.Models
{
    public class Locomotive
    {
        public Locomotive()
        {
            
        }
        public Locomotive(int locoNumber)
        {
            LocoNumber = locoNumber;
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
        public string Name => $"L-{LocoNumber:D3}";
    }
}
