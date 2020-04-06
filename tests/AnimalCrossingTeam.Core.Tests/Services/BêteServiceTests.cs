using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AnimalCrossingTeam.Core.Contexts;
using AnimalCrossingTeam.Core.Contexts.Interfaces;
using AnimalCrossingTeam.Core.Exceptions;
using AnimalCrossingTeam.Core.Models;
using AnimalCrossingTeam.Core.Services;
using AnimalCrossingTeam.Tests.Mocks.Contexts;
using Microsoft.EntityFrameworkCore;
using Moq;
using Xunit;

namespace AnimalCrossingTeam.Core.Tests.Services
{
    public class BêteServiceTests
    {
        // Tests de l'ajout
        [Fact]
        public void AddInsecte_Invalide()
        {
            var mockBêteContext = new MockBêteContext()
                .MockGetInsecte(new Insecte());
            var bêteService = new BêteService(mockBêteContext.Object);

            Assert.Throws<InsecteExisteDéjà>(() =>
                bêteService.AddInsecte(new Insecte { Numéro = 1 }));
            mockBêteContext.VerifyGetInsecte(Times.Once());
            mockBêteContext.VerifyAddInsecte(Times.Never());
        }
        [Fact]
        public void AddInsecte_Valide()
        {
            var mockBêteContext = new MockBêteContext()
                .MockGetInsecte(null);
            var bêteService = new BêteService(mockBêteContext.Object);

            bêteService.AddInsecte(new Insecte { Numéro = 1 });

            mockBêteContext.VerifyGetInsecte(Times.Once());
            mockBêteContext.VerifyAddInsecte(Times.Once());
        }

        [Fact]
        public void AddPoisson_Invalide()
        {
            var mockBêteContext = new MockBêteContext()
                .MockGetPoisson(new Poisson());
            var bêteService = new BêteService(mockBêteContext.Object);

            Assert.Throws<PoissonExisteDéjà>(() =>
                bêteService.AddPoisson(new Poisson { Numéro = 1 }));
            mockBêteContext.VerifyGetPoisson(Times.Once());
            mockBêteContext.VerifyAddInsecte(Times.Never());
        }
        [Fact]
        public void AddPoisson_Valide()
        {
            var mockBêteContext = new MockBêteContext()
                .MockGetPoisson(null);
            var bêteService = new BêteService(mockBêteContext.Object);

            bêteService.AddPoisson(new Poisson { Numéro = 1 });

            mockBêteContext.VerifyGetPoisson(Times.Once());
            mockBêteContext.VerifyAddPoisson(Times.Once());
        }

        // Tests de la mise à jour
        [Fact]
        public void UpdateInsecte_Invalide()
        {
            var mockBêteContext = new MockBêteContext()
                .MockGetInsecte(null);
            var bêteService = new BêteService(mockBêteContext.Object);

            Assert.Throws<InsecteExistePas>(() =>
                bêteService.UpdateInsecte(new Insecte { Numéro = 1 }));
            mockBêteContext.VerifyGetInsecte(Times.Once());
            mockBêteContext.VerifyUpdateInsecte(Times.Never());
        }
        [Fact]
        public void UpdateInsecte_Valide()
        {
            var mockBêteContext = new MockBêteContext()
                .MockGetInsecte(new Insecte());
            var bêteService = new BêteService(mockBêteContext.Object);

            bêteService.UpdateInsecte(new Insecte { Numéro = 1 });

            mockBêteContext.VerifyGetInsecte(Times.Once());
            mockBêteContext.VerifyUpdateInsecte(Times.Once());
        }

        [Fact]
        public void UpdatePoisson_Invalide()
        {
            var mockBêteContext = new MockBêteContext()
                .MockGetPoisson(null);
            var bêteService = new BêteService(mockBêteContext.Object);

            Assert.Throws<PoissonExistePas>(() =>
                bêteService.UpdatePoisson(new Poisson
                {
                    Numéro = 1
                }));
            mockBêteContext.VerifyGetPoisson(Times.Once());
            mockBêteContext.VerifyUpdatePoisson(Times.Never());
        }
        [Fact]
        public void UpdatePoisson_Valide()
        {
            var mockBêteContext = new MockBêteContext()
                .MockGetPoisson(new Poisson());
            var bêteService = new BêteService(mockBêteContext.Object);

            bêteService.UpdatePoisson(new Poisson { Numéro = 1 });

            mockBêteContext.VerifyGetPoisson(Times.Once());
            mockBêteContext.VerifyUpdatePoisson(Times.Once());
        }

        // Tests de la suppression
        [Fact]
        public void RemoveInsecte_Invalide()
        {
            var mockBêteContext = new MockBêteContext()
                .MockGetInsecte(null);
            var bêteService = new BêteService(mockBêteContext.Object);

            Assert.Throws<InsecteExistePas>(() =>
                bêteService.RemoveInsecte(0));
            mockBêteContext.VerifyGetInsecte(Times.Once());
            mockBêteContext.VerifyRemoveInsecte(Times.Never());
        }
        [Fact]
        public void RemoveInsecte_Valide()
        {
            var mockBêteContext = new MockBêteContext()
                .MockGetInsecte(new Insecte());
            var bêteService = new BêteService(mockBêteContext.Object);

            bêteService.RemoveInsecte(0);

            mockBêteContext.VerifyGetInsecte(Times.Once());
            mockBêteContext.VerifyRemoveInsecte(Times.Once());
        }

        [Fact]
        public void RemovePoisson_Invalide()
        {
            var mockBêteContext = new MockBêteContext()
                .MockGetPoisson(null);
            var bêteService = new BêteService(mockBêteContext.Object);

            Assert.Throws<PoissonExistePas>(() =>
                bêteService.RemovePoisson(0));
            mockBêteContext.VerifyGetPoisson(Times.Once());
            mockBêteContext.VerifyRemovePoisson(Times.Never());
        }
        [Fact]
        public void RemovePoisson_Valide()
        {
            var mockBêteContext = new MockBêteContext()
                .MockGetPoisson(new Poisson());
            var bêteService = new BêteService(mockBêteContext.Object);

            bêteService.RemovePoisson(0);

            mockBêteContext.VerifyGetPoisson(Times.Once());
            mockBêteContext.VerifyRemovePoisson(Times.Once());
        }

        // Test de la recherche
        [Theory]
        [InlineData("aba", "Aab", "aAc", "AAc", "aa")]
        public void SearchBêtes(string nomPremierInsecte,
            string nomDeuxièmeInsecte,
            string nomPremierPoisson,
            string nomDeuxièmePoisson,
            string terme)
        {
            // Arrange
            var premierInsecte = new Insecte { Numéro = 1, Nom = nomPremierInsecte };
            var deuxièmeInsecte = new Insecte { Numéro = 2, Nom = nomDeuxièmeInsecte };
            var premierPoisson = new Poisson { Numéro = 3, Nom = nomPremierPoisson };
            var deuxièmePoisson = new Poisson { Numéro = 4, Nom = nomDeuxièmePoisson };

            var listeInsectes = new List<Insecte>
            {
                premierInsecte,
                deuxièmeInsecte
            };
            var listePoissons = new List<Poisson>
            {
                premierPoisson,
                deuxièmePoisson
            };
            var mockBêteContext = new MockBêteContext()
                .MockGetInsectes(listeInsectes)
                .MockGetPoissons(listePoissons);
            var bêteService = new BêteService(mockBêteContext.Object);

            // Act
            List<Bête> résultatRecherche = bêteService.SearchBêtes(terme);

            // Assert
            Assert.Equal(3, résultatRecherche.Count);
            Assert.Equal(deuxièmeInsecte, résultatRecherche[0]);
            Assert.Equal(premierPoisson, résultatRecherche[1]);
            Assert.Equal(deuxièmePoisson, résultatRecherche[2]);
        }

        // Test des dernières bêtes
        [Fact]
        public void GetLastBêtes()
        {
            var listeInsectes = new List<Insecte>
            {
                new Insecte { Numéro = 1, DateAjout = DateTime.Now},
                new Insecte { Numéro = 2, DateAjout = DateTime.Now.AddDays(-2)},
                new Insecte { Numéro = 3, DateAjout = DateTime.Now.AddDays(-4)},
                new Insecte { Numéro = 4, DateAjout = DateTime.Now.AddDays(-6)},
                new Insecte { Numéro = 5, DateAjout = DateTime.Now.AddDays(-8)},
                new Insecte { Numéro = 6, DateAjout = DateTime.Now.AddDays(-10)}
            };
            var listePoissons = new List<Poisson>
            {
                new Poisson { Numéro = 7, DateAjout = DateTime.Now.AddDays(-1)},
                new Poisson { Numéro = 8, DateAjout = DateTime.Now.AddDays(-3)},
                new Poisson { Numéro = 9, DateAjout = DateTime.Now.AddDays(-5)},
                new Poisson { Numéro = 10, DateAjout = DateTime.Now.AddDays(-7)},
                new Poisson { Numéro = 11, DateAjout = DateTime.Now.AddDays(-9)},
                new Poisson { Numéro = 12, DateAjout = DateTime.Now.AddDays(-11)}
            };
            var mockBêteContext = new MockBêteContext()
                .MockGetInsectes(listeInsectes)
                .MockGetPoissons(listePoissons);
            var bêteService = new BêteService(mockBêteContext.Object);

            // Act
            List<Bête> dernièresBêtes = bêteService.GetLastBêtes();

            // Assert
            Assert.Equal(10, dernièresBêtes.Count);
            Assert.Equal(listeInsectes[0], dernièresBêtes[0]);
            Assert.Equal(listePoissons[0], dernièresBêtes[1]);
            Assert.Equal(listeInsectes[1], dernièresBêtes[2]);
            Assert.Equal(listePoissons[1], dernièresBêtes[3]);
            Assert.Equal(listeInsectes[2], dernièresBêtes[4]);
            Assert.Equal(listePoissons[2], dernièresBêtes[5]);
            Assert.Equal(listeInsectes[3], dernièresBêtes[6]);
            Assert.Equal(listePoissons[3], dernièresBêtes[7]);
            Assert.Equal(listeInsectes[4], dernièresBêtes[8]);
            Assert.Equal(listePoissons[4], dernièresBêtes[9]);
        }
    }
}
