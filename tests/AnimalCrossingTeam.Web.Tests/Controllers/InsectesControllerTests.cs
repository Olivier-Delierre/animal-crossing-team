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
    public class InsectesControllerTests
    {
        [Fact]
        public void Ajouter_Valide()
        {
            var mockBeteService = new MockBeteService()
                .MockGetInsecte(null);
            var insectesController = new InsectesController(mockBeteService.Object);

            var result = insectesController.Ajouter(new Insecte {  Numero = 1 });

            Assert.IsType<JsonResult>(result);
        }
        [Fact]
        public void Ajouter_Invalide()
        {
            var mockBeteService = new MockBeteService()
                .MockGetInsecte(new Insecte());
            var insectesController = new InsectesController(mockBeteService.Object);

            var result = insectesController.Ajouter(new Insecte { Numero = 1});

            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public void Modifier_Valide()
        {
            var mockBeteService = new MockBeteService()
                .MockGetInsecte(new Insecte());
            var insectesController = new InsectesController(mockBeteService.Object);

            var result = insectesController.Modifier(new Insecte { Numero = 1 });

            Assert.IsType<JsonResult>(result);
        }
        [Fact]
        public void Modifier_Invalide()
        {
            var mockBeteService = new MockBeteService()
                .MockGetInsecte(null);
            var insectesController = new InsectesController(mockBeteService.Object);

            var result = insectesController.Modifier(new Insecte { Numero = 1 });

            Assert.IsType<BadRequestObjectResult>(result);
        }
    }
}
