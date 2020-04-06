using System;
using System.Collections.Generic;
using System.Text;
using AnimalCrossingTeam.Core.Models;
using AnimalCrossingTeam.Core.Services.Interfaces;
using Moq;

namespace AnimalCrossingTeam.Tests.Mocks.Services
{
    public class MockBeteService : Mock<IBeteService>
    {
        public MockBeteService MockGetInsecte(Insecte result)
        {
            Setup(x => x.GetInsecte(It.IsAny<int>()))
                .Returns(result);

            return this;
        }

        public MockBeteService MockGetPoisson(Poisson result)
        {
            Setup(x => x.GetPoisson(It.IsAny<int>()))
                .Returns(result);

            return this;
        }
    }
}
