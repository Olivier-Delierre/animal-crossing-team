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
    public class BeteServiceTests
    {
        // Tests de l'ajout
        [Fact]
        public void AddInsecte_Invalide()
        {
            var mockBeteContext = new MockBeteContext()
                .MockGetInsecte(new Insecte());
            var BeteService = new BeteService(mockBeteContext.Object);

            Assert.Throws<InsecteExisteDéjà>(() =>
                BeteService.AddInsecte(new Insecte { Numero = 1 }));
            mockBeteContext.VerifyGetInsecte(Times.Once());
            mockBeteContext.VerifyAddInsecte(Times.Never());
        }
        [Fact]
        public void AddInsecte_Valide()
        {
            var mockBeteContext = new MockBeteContext()
                .MockGetInsecte(null);
            var BeteService = new BeteService(mockBeteContext.Object);

            BeteService.AddInsecte(new Insecte { Numero = 1 });

            mockBeteContext.VerifyGetInsecte(Times.Once());
            mockBeteContext.VerifyAddInsecte(Times.Once());
        }

        [Fact]
        public void AddPoisson_Invalide()
        {
            var mockBeteContext = new MockBeteContext()
                .MockGetPoisson(new Poisson());
            var BeteService = new BeteService(mockBeteContext.Object);

            Assert.Throws<PoissonExisteDéjà>(() =>
                BeteService.AddPoisson(new Poisson { Numero = 1 }));
            mockBeteContext.VerifyGetPoisson(Times.Once());
            mockBeteContext.VerifyAddInsecte(Times.Never());
        }
        [Fact]
        public void AddPoisson_Valide()
        {
            var mockBeteContext = new MockBeteContext()
                .MockGetPoisson(null);
            var BeteService = new BeteService(mockBeteContext.Object);

            BeteService.AddPoisson(new Poisson { Numero = 1 });

            mockBeteContext.VerifyGetPoisson(Times.Once());
            mockBeteContext.VerifyAddPoisson(Times.Once());
        }

        // Tests de la mise à jour
        [Fact]
        public void UpdateInsecte_Invalide()
        {
            var mockBeteContext = new MockBeteContext()
                .MockGetInsecte(null);
            var BeteService = new BeteService(mockBeteContext.Object);

            Assert.Throws<InsecteExistePas>(() =>
                BeteService.UpdateInsecte(new Insecte { Numero = 1 }));
            mockBeteContext.VerifyGetInsecte(Times.Once());
            mockBeteContext.VerifyUpdateInsecte(Times.Never());
        }
        [Fact]
        public void UpdateInsecte_Valide()
        {
            var mockBeteContext = new MockBeteContext()
                .MockGetInsecte(new Insecte());
            var BeteService = new BeteService(mockBeteContext.Object);

            BeteService.UpdateInsecte(new Insecte { Numero = 1 });

            mockBeteContext.VerifyGetInsecte(Times.Once());
            mockBeteContext.VerifyUpdateInsecte(Times.Once());
        }

        [Fact]
        public void UpdatePoisson_Invalide()
        {
            var mockBeteContext = new MockBeteContext()
                .MockGetPoisson(null);
            var BeteService = new BeteService(mockBeteContext.Object);

            Assert.Throws<PoissonExistePas>(() =>
                BeteService.UpdatePoisson(new Poisson
                {
                    Numero = 1
                }));
            mockBeteContext.VerifyGetPoisson(Times.Once());
            mockBeteContext.VerifyUpdatePoisson(Times.Never());
        }
        [Fact]
        public void UpdatePoisson_Valide()
        {
            var mockBeteContext = new MockBeteContext()
                .MockGetPoisson(new Poisson());
            var BeteService = new BeteService(mockBeteContext.Object);

            BeteService.UpdatePoisson(new Poisson { Numero = 1 });

            mockBeteContext.VerifyGetPoisson(Times.Once());
            mockBeteContext.VerifyUpdatePoisson(Times.Once());
        }

        // Tests de la suppression
        [Fact]
        public void RemoveInsecte_Invalide()
        {
            var mockBeteContext = new MockBeteContext()
                .MockGetInsecte(null);
            var BeteService = new BeteService(mockBeteContext.Object);

            Assert.Throws<InsecteExistePas>(() =>
                BeteService.RemoveInsecte(0));
            mockBeteContext.VerifyGetInsecte(Times.Once());
            mockBeteContext.VerifyRemoveInsecte(Times.Never());
        }
        [Fact]
        public void RemoveInsecte_Valide()
        {
            var mockBeteContext = new MockBeteContext()
                .MockGetInsecte(new Insecte());
            var BeteService = new BeteService(mockBeteContext.Object);

            BeteService.RemoveInsecte(0);

            mockBeteContext.VerifyGetInsecte(Times.Once());
            mockBeteContext.VerifyRemoveInsecte(Times.Once());
        }

        [Fact]
        public void RemovePoisson_Invalide()
        {
            var mockBeteContext = new MockBeteContext()
                .MockGetPoisson(null);
            var BeteService = new BeteService(mockBeteContext.Object);

            Assert.Throws<PoissonExistePas>(() =>
                BeteService.RemovePoisson(0));
            mockBeteContext.VerifyGetPoisson(Times.Once());
            mockBeteContext.VerifyRemovePoisson(Times.Never());
        }
        [Fact]
        public void RemovePoisson_Valide()
        {
            var mockBeteContext = new MockBeteContext()
                .MockGetPoisson(new Poisson());
            var BeteService = new BeteService(mockBeteContext.Object);

            BeteService.RemovePoisson(0);

            mockBeteContext.VerifyGetPoisson(Times.Once());
            mockBeteContext.VerifyRemovePoisson(Times.Once());
        }

        // Test de la recherche
        [Theory]
        [InlineData("aba", "Aab", "aAc", "AAc", "aa")]
        public void SearchBetes(string nomPremierInsecte,
            string nomDeuxièmeInsecte,
            string nomPremierPoisson,
            string nomDeuxièmePoisson,
            string terme)
        {
            // Arrange
            var premierInsecte = new Insecte { Numero = 1, Nom = nomPremierInsecte };
            var deuxièmeInsecte = new Insecte { Numero = 2, Nom = nomDeuxièmeInsecte };
            var premierPoisson = new Poisson { Numero = 3, Nom = nomPremierPoisson };
            var deuxièmePoisson = new Poisson { Numero = 4, Nom = nomDeuxièmePoisson };

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
            var mockBeteContext = new MockBeteContext()
                .MockGetInsectes(listeInsectes)
                .MockGetPoissons(listePoissons);
            var BeteService = new BeteService(mockBeteContext.Object);

            // Act
            List<Bete> résultatRecherche = BeteService.SearchBetes(terme);

            // Assert
            Assert.Equal(3, résultatRecherche.Count);
            Assert.Equal(deuxièmeInsecte, résultatRecherche[0]);
            Assert.Equal(premierPoisson, résultatRecherche[1]);
            Assert.Equal(deuxièmePoisson, résultatRecherche[2]);
        }

        // Test des dernières Betes
        [Fact]
        public void GetLastBetes()
        {
            var listeInsectes = new List<Insecte>
            {
                new Insecte { Numero = 1, DateAjout = DateTime.Now},
                new Insecte { Numero = 2, DateAjout = DateTime.Now.AddDays(-2)},
                new Insecte { Numero = 3, DateAjout = DateTime.Now.AddDays(-4)},
                new Insecte { Numero = 4, DateAjout = DateTime.Now.AddDays(-6)},
                new Insecte { Numero = 5, DateAjout = DateTime.Now.AddDays(-8)},
                new Insecte { Numero = 6, DateAjout = DateTime.Now.AddDays(-10)}
            };
            var listePoissons = new List<Poisson>
            {
                new Poisson { Numero = 7, DateAjout = DateTime.Now.AddDays(-1)},
                new Poisson { Numero = 8, DateAjout = DateTime.Now.AddDays(-3)},
                new Poisson { Numero = 9, DateAjout = DateTime.Now.AddDays(-5)},
                new Poisson { Numero = 10, DateAjout = DateTime.Now.AddDays(-7)},
                new Poisson { Numero = 11, DateAjout = DateTime.Now.AddDays(-9)},
                new Poisson { Numero = 12, DateAjout = DateTime.Now.AddDays(-11)}
            };
            var mockBeteContext = new MockBeteContext()
                .MockGetInsectes(listeInsectes)
                .MockGetPoissons(listePoissons);
            var BeteService = new BeteService(mockBeteContext.Object);

            // Act
            List<Bete> dernièresBetes = BeteService.GetLastBetes();

            // Assert
            Assert.Equal(10, dernièresBetes.Count);
            Assert.Equal(listeInsectes[0], dernièresBetes[0]);
            Assert.Equal(listePoissons[0], dernièresBetes[1]);
            Assert.Equal(listeInsectes[1], dernièresBetes[2]);
            Assert.Equal(listePoissons[1], dernièresBetes[3]);
            Assert.Equal(listeInsectes[2], dernièresBetes[4]);
            Assert.Equal(listePoissons[2], dernièresBetes[5]);
            Assert.Equal(listeInsectes[3], dernièresBetes[6]);
            Assert.Equal(listePoissons[3], dernièresBetes[7]);
            Assert.Equal(listeInsectes[4], dernièresBetes[8]);
            Assert.Equal(listePoissons[4], dernièresBetes[9]);
        }
    }
}
