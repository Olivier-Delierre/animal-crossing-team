using System;
using System.Collections.Generic;
using System.Text;
using AnimalCrossingTeam.Core.Contexts.Interfaces;
using AnimalCrossingTeam.Core.Models;
using Moq;

namespace AnimalCrossingTeam.Tests.Mocks.Contexts
{
    public class MockBêteContext : Mock<IBêteContext>
    {
        public MockBêteContext MockGetInsecte(Insecte result)
        {
            Setup(x => x.GetInsecte(It.IsAny<int>()))
                .Returns(result);

            return this;
        }
        public MockBêteContext MockGetPoisson(Poisson result)
        {
            Setup(x => x.GetPoisson(It.IsAny<int>()))
                .Returns(result);

            return this;
        }

        public MockBêteContext MockGetInsectes(IEnumerable<Insecte> result)
        {
            Setup(x => x.GetInsectes())
                .Returns(result);

            return this;
        }
        public MockBêteContext MockGetPoissons(IEnumerable<Poisson> result)
        {
            Setup(x => x.GetPoissons())
                .Returns(result);

            return this;
        }

        public MockBêteContext VerifyGetInsecte(Times times)
        {
            Verify(x => x.GetInsecte(It.IsAny<int>()), times);
            return this;
        }
        public MockBêteContext VerifyGetPoisson(Times times)
        {
            Verify(x => x.GetPoisson(It.IsAny<int>()), times);
            return this;
        }

        public MockBêteContext VerifyAddInsecte(Times times)
        {
            Verify(x => x.AddInsecte(It.IsAny<Insecte>()), times);
            return this;
        }
        public MockBêteContext VerifyAddPoisson(Times times)
        {
            Verify(x => x.AddPoisson(It.IsAny<Poisson>()), times);
            return this;
        }

        public MockBêteContext VerifyUpdateInsecte(Times times)
        {
            Verify(x => x.UpdateInsecte(It.IsAny<Insecte>()), times);
            return this;
        }
        public MockBêteContext VerifyUpdatePoisson(Times times)
        {
            Verify(x => x.UpdatePoisson(It.IsAny<Poisson>()), times);
            return this;
        }

        public MockBêteContext VerifyRemoveInsecte(Times times)
        {
            Verify(x => x.RemoveInsecte(It.IsAny<int>()), times);
            return this;
        }
        public MockBêteContext VerifyRemovePoisson(Times times)
        {
            Verify(x => x.RemovePoisson(It.IsAny<int>()), times);
            return this;
        }
    }
}
