using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AnimalCrossingTeam.Core.Models
{
    public abstract class Bête
    {
        public abstract int Numéro { get; set; }
        public abstract string Nom { get; set; }
        public abstract int Prix { get; set; }
        public abstract string Localisation { get; set; }
        public abstract string Météo { get; set; }
    }
}
