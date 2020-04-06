using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AnimalCrossingTeam.Core.Models
{
    public class Navet
    {
        [Key] 
        public int Id { get; set; }

        [Required(ErrorMessage = "Vous devez saisir une date.")]
        public DateTime? Date { get; set; }
        public bool Matin { get; set; }

        [Required(ErrorMessage = "Vous devez un cours.")]
        [Range(0, 2000, ErrorMessage = "Le cours du navet doit être compris entre {1} et {2}")]
        public int Prix { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Vous devez choisir une personne.")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string Personne { get; set; }
    }
}
