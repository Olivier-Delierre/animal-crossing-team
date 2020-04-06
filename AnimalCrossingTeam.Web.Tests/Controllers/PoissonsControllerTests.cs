using System;
using System.Collections.Generic;
using System.Text;
using AnimalCrossingTeam.Core.Models;
using AnimalCrossingTeam.Tests.Mocks.Services;
using AnimalCrossingTeam.Web.Controllers;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace AnimalCrossingTeam.Web.Tests.Controllers
{
    public class PoissonsControllerTests
    {
        [Fact]
        public void Ajouter_Valide()
        {
            var mockBêteService = new MockBêteService()
                .MockGetPoisson(null);
            var poissonController = new PoissonsController(mockBêteService.Object);

            var result = poissonController.Ajouter(new Poisson { Numéro = 1 });

            Assert.IsType<JsonResult>(result);
        }
        [Fact]
        public void Ajouter_Invalide()
        {
            var mockBêteService = new MockBêteService()
                .MockGetPoisson(new Poisson());
            var poissonController = new PoissonsController(mockBêteService.Object);

            var result = poissonController.Ajouter(new Poisson { Numéro = 1 });

            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public void Modifier_Valide()
        {
            var mockBêteService = new MockBêteService()
                .MockGetPoisson(new Poisson());
            var poissonController = new PoissonsController(mockBêteService.Object);

            var result = poissonController.Modifier(new Poisson { Numéro = 1 });

            Assert.IsType<JsonResult>(result);
        }
        [Fact]
        public void Modifier_Invalide()
        {
            var mockBêteService = new MockBêteService()
                .MockGetPoisson(null);
            var poissonController = new PoissonsController(mockBêteService.Object);

            var result = poissonController.Modifier(new Poisson { Numéro = 1 });

            Assert.IsType<BadRequestObjectResult>(result);
        }
    }
}
