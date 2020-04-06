using System;
using System.Collections.Generic;
using System.Text;
using AnimalCrossingTeam.Core.Models;
using AnimalCrossingTeam.Core.Services.Interfaces;
using Moq;

namespace AnimalCrossingTeam.Tests.Mocks.Services
{
    public class MockBêteService : Mock<IBêteService>
    {
        public MockBêteService MockGetInsecte(Insecte result)
        {
            Setup(x => x.GetInsecte(It.IsAny<int>()))
                .Returns(result);

            return this;
        }

        public MockBêteService MockGetPoisson(Poisson result)
        {
            Setup(x => x.GetPoisson(It.IsAny<int>()))
                .Returns(result);

            return this;
        }
    }
}
