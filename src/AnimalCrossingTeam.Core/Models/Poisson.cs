using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace AnimalCrossingTeam.Core.Models
{
    public class Poisson : Bête
    {
        [Key]
        public override int Numéro { get; set; }

        [NotNull]
        public override string Nom { get; set; }

        [Range(0, int.MaxValue)]
        public override int Prix { get; set; }
        public override string Localisation { get; set; }
        public override string Météo { get; set; }
    }
}
