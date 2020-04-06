using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AnimalCrossingTeam.Core.Models
{
    public abstract class Bête
    {
        public abstract int? Numéro { get; set; }
        public abstract string Nom { get; set; }
        public abstract int? Prix { get; set; }

        public abstract bool Janvier { get; set; }
        public abstract bool Février { get; set; }
        public abstract bool Mars { get; set; }
        public abstract bool Avril { get; set; }
        public abstract bool Mai { get; set; }
        public abstract bool Juin { get; set; }
        public abstract bool Juillet { get; set; }
        public abstract bool Août { get; set; }
        public abstract bool Septembre { get; set; }
        public abstract bool Octobre { get; set; }
        public abstract bool Novembre { get; set; }
        public abstract bool Décembre { get; set; }

        public string AffichageMois
        {
            get
            {
                var stringBuilder = new StringBuilder();
                if (Janvier) stringBuilder.Append("J - ");
                if (Février) stringBuilder.Append("F - ");
                if (Mars) stringBuilder.Append("Mar - ");
                if (Avril) stringBuilder.Append("Av - ");
                if (Mai) stringBuilder.Append("Mai - ");
                if (Juin) stringBuilder.Append("Juin - ");
                if (Juillet) stringBuilder.Append("Juil - ");
                if (Août) stringBuilder.Append("Ao - ");
                if (Septembre) stringBuilder.Append("S - ");
                if (Octobre) stringBuilder.Append("O - ");
                if (Novembre) stringBuilder.Append("N - ");
                if (Décembre) stringBuilder.Append("D - ");

                if (stringBuilder.Length > 0)
                {
                    stringBuilder.Remove(stringBuilder.Length - 3, 3);
                }

                if (stringBuilder.Equals("J - F - Mar - Av - Mai - Juin - Juil - Ao - S - O - N - D"))
                {
                    stringBuilder.Clear();
                    stringBuilder.Append("Tout les mois");
                }

                return stringBuilder.ToString();
            }
        }
                
        public abstract int? PremièreHeure { get; set; }
        public abstract int? DernièreHeure { get; set; }

        public string AffichageHeures
        {
            get
            {
                if (PremièreHeure == 0 && DernièreHeure == 23)
                {
                    return "Tout le temps";
                }

                return $"{PremièreHeure}h - {DernièreHeure}h";
            }
        }

        public abstract string Localisation { get; set; }
        public abstract string Météo { get; set; }

        public abstract DateTime DateAjout { get; set; }
    }
}
