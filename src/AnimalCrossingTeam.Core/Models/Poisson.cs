using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace AnimalCrossingTeam.Core.Models
{
    public class Poisson : Bete
    {
        [Key]
        [Required(ErrorMessage = "Vous devez saisir un numero.")]
        public override int? Numero { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Vous devez saisir un nom.")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public override string Nom { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Le prix doit être supérieur à {2}")]
        public override int? Prix { get; set; }
        public override string Localisation { get; set; }
        public override string Meteo { get; set; }

        public override bool Janvier { get; set; }
        public override bool Fevrier { get; set; }
        public override bool Mars { get; set; }
        public override bool Avril { get; set; }
        public override bool Mai { get; set; }
        public override bool Juin { get; set; }
        public override bool Juillet { get; set; }
        public override bool Aout { get; set; }
        public override bool Septembre { get; set; }
        public override bool Octobre { get; set; }
        public override bool Novembre { get; set; }
        public override bool Decembre { get; set; }

        [Required(ErrorMessage = "Vous devez saisir une heure.")]
        [Range(0, 23, ErrorMessage = "L'heure doit être comprise entre {2} et {1}.")]
        public override int? PremiereHeure { get; set; }

        [Required(ErrorMessage = "Vous devez saisir une heure.")]
        [Range(0, 23, ErrorMessage = "L'heure doit être comprise entre {2} et {1}")]
        public override int? DerniereHeure { get; set; }

        public override DateTime DateAjout { get; set; }
    }
}
