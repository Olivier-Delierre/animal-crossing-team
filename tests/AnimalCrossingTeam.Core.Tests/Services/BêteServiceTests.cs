using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AnimalCrossingTeam.Core.Contexts;
using AnimalCrossingTeam.Core.Contexts.Interfaces;
using AnimalCrossingTeam.Core.Exceptions;
using AnimalCrossingTeam.Core.Models;
using AnimalCrossingTeam.Core.Services;
using AnimalCrossingTeam.Core.Tests.Mocks.Contexts;
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
                bêteService.AddInsecte(new Insecte()));
            mockBêteContext.VerifyGetInsecte(Times.Once());
            mockBêteContext.VerifyAddInsecte(Times.Never());
        }
        [Fact]
        public void AddInsecte_Valide()
        {
            var mockBêteContext = new MockBêteContext()
                .MockGetInsecte(null);
            var bêteService = new BêteService(mockBêteContext.Object);

            bêteService.AddInsecte(new Insecte());

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
                bêteService.AddPoisson(new Poisson()));
            mockBêteContext.VerifyGetPoisson(Times.Once());
            mockBêteContext.VerifyAddInsecte(Times.Never());
        }
        [Fact]
        public void AddPoisson_Valide()
        {
            var mockBêteContext = new MockBêteContext()
                .MockGetPoisson(null);
            var bêteService = new BêteService(mockBêteContext.Object);

            bêteService.AddPoisson(new Poisson());

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
                bêteService.UpdateInsecte(new Insecte()));
            mockBêteContext.VerifyGetInsecte(Times.Once());
            mockBêteContext.VerifyUpdateInsecte(Times.Never());
        }
        [Fact]
        public void UpdateInsecte_Valide()
        {
            var mockBêteContext = new MockBêteContext()
                .MockGetInsecte(new Insecte());
            var bêteService = new BêteService(mockBêteContext.Object);

            bêteService.UpdateInsecte(new Insecte());

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
                bêteService.UpdatePoisson(new Poisson()));
            mockBêteContext.VerifyGetPoisson(Times.Once());
            mockBêteContext.VerifyUpdatePoisson(Times.Never());
        }
        [Fact]
        public void UpdatePoisson_Valide()
        {
            var mockBêteContext = new MockBêteContext()
                .MockGetPoisson(new Poisson());
            var bêteService = new BêteService(mockBêteContext.Object);

            bêteService.UpdatePoisson(new Poisson());

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
    }
}
