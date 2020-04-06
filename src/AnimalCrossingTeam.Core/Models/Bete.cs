using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AnimalCrossingTeam.Core.Models
{
    public abstract class Bete
    {
        public abstract int? Numero { get; set; }
        public abstract string Nom { get; set; }
        public abstract int? Prix { get; set; }

        public abstract bool Janvier { get; set; }
        public abstract bool Fevrier { get; set; }
        public abstract bool Mars { get; set; }
        public abstract bool Avril { get; set; }
        public abstract bool Mai { get; set; }
        public abstract bool Juin { get; set; }
        public abstract bool Juillet { get; set; }
        public abstract bool Aout { get; set; }
        public abstract bool Septembre { get; set; }
        public abstract bool Octobre { get; set; }
        public abstract bool Novembre { get; set; }
        public abstract bool Decembre { get; set; }

        public string AffichageMois
        {
            get
            {
                var stringBuilder = new StringBuilder();
                if (Janvier) stringBuilder.Append("J - ");
                if (Fevrier) stringBuilder.Append("F - ");
                if (Mars) stringBuilder.Append("Mar - ");
                if (Avril) stringBuilder.Append("Av - ");
                if (Mai) stringBuilder.Append("Mai - ");
                if (Juin) stringBuilder.Append("Juin - ");
                if (Juillet) stringBuilder.Append("Juil - ");
                if (Aout) stringBuilder.Append("Ao - ");
                if (Septembre) stringBuilder.Append("S - ");
                if (Octobre) stringBuilder.Append("O - ");
                if (Novembre) stringBuilder.Append("N - ");
                if (Decembre) stringBuilder.Append("D - ");

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
                
        public abstract int? PremiereHeure { get; set; }
        public abstract int? DerniereHeure { get; set; }

        public string AffichageHeures
        {
            get
            {
                if (PremiereHeure == 0 && DerniereHeure == 23)
                {
                    return "Tout le temps";
                }

                return $"{PremiereHeure}h - {DerniereHeure}h";
            }
        }

        public abstract string Localisation { get; set; }
        public abstract string Meteo { get; set; }

        public abstract DateTime DateAjout { get; set; }
    }
}
