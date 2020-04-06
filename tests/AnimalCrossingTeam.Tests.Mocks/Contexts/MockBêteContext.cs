using System;
using System.Collections.Generic;
using System.Text;
using AnimalCrossingTeam.Core.Contexts.Interfaces;
using AnimalCrossingTeam.Core.Models;
using Moq;

namespace AnimalCrossingTeam.Tests.Mocks.Contexts
{
    public class MockBeteContext : Mock<IBeteContext>
    {
        public MockBeteContext MockGetInsecte(Insecte result)
        {
            Setup(x => x.GetInsecte(It.IsAny<int>()))
                .Returns(result);

            return this;
        }
        public MockBeteContext MockGetPoisson(Poisson result)
        {
            Setup(x => x.GetPoisson(It.IsAny<int>()))
                .Returns(result);

            return this;
        }

        public MockBeteContext MockGetInsectes(IEnumerable<Insecte> result)
        {
            Setup(x => x.GetInsectes())
                .Returns(result);

            return this;
        }
        public MockBeteContext MockGetPoissons(IEnumerable<Poisson> result)
        {
            Setup(x => x.GetPoissons())
                .Returns(result);

            return this;
        }

        public MockBeteContext VerifyGetInsecte(Times times)
        {
            Verify(x => x.GetInsecte(It.IsAny<int>()), times);
            return this;
        }
        public MockBeteContext VerifyGetPoisson(Times times)
        {
            Verify(x => x.GetPoisson(It.IsAny<int>()), times);
            return this;
        }

        public MockBeteContext VerifyAddInsecte(Times times)
        {
            Verify(x => x.AddInsecte(It.IsAny<Insecte>()), times);
            return this;
        }
        public MockBeteContext VerifyAddPoisson(Times times)
        {
            Verify(x => x.AddPoisson(It.IsAny<Poisson>()), times);
            return this;
        }

        public MockBeteContext VerifyUpdateInsecte(Times times)
        {
            Verify(x => x.UpdateInsecte(It.IsAny<Insecte>()), times);
            return this;
        }
        public MockBeteContext VerifyUpdatePoisson(Times times)
        {
            Verify(x => x.UpdatePoisson(It.IsAny<Poisson>()), times);
            return this;
        }

        public MockBeteContext VerifyRemoveInsecte(Times times)
        {
            Verify(x => x.RemoveInsecte(It.IsAny<int>()), times);
            return this;
        }
        public MockBeteContext VerifyRemovePoisson(Times times)
        {
            Verify(x => x.RemovePoisson(It.IsAny<int>()), times);
            return this;
        }
    }
}
