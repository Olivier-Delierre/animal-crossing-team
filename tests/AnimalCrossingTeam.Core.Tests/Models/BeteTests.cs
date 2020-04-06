using System;
using System.Collections.Generic;
using System.Text;
using AnimalCrossingTeam.Core.Models;
using Xunit;

namespace AnimalCrossingTeam.Core.Tests.Models
{
    public class BeteTests
    {
        [Fact]
        public void AffichageHeures_ToutLeTemps()
        {
            var insecte = new Insecte
            {
                PremiereHeure = 0,
                DerniereHeure = 23
            };
            var poisson = new Poisson
            {
                PremiereHeure = 0,
                DerniereHeure = 23
            };

            var affichageHeureInsecte = insecte.AffichageHeures;
            var affichageHeurePoisson = poisson.AffichageHeures;

            Assert.Equal("Tout le temps", affichageHeureInsecte);
            Assert.Equal("Tout le temps", affichageHeurePoisson);
        }

        [Theory]
        [InlineData(1, 23)]
        [InlineData(22, 6)]
        [InlineData(5, 6)]
        public void AffichageHeures_PasToutLeTemps(int premièreHeure, int dernièreHeure)
        {
            var insecte = new Insecte
            {
                PremiereHeure = premièreHeure,
                DerniereHeure = dernièreHeure
            };
            var poisson = new Poisson
            {
                PremiereHeure = premièreHeure,
                DerniereHeure = dernièreHeure
            };

            var affichageHeureInsecte = insecte.AffichageHeures;
            var affichageHeurePoisson = poisson.AffichageHeures;

            Assert.Equal(premièreHeure + "h - " + dernièreHeure + "h", affichageHeureInsecte);
            Assert.Equal(premièreHeure + "h - " + dernièreHeure + "h", affichageHeurePoisson);
        }
    }
}
