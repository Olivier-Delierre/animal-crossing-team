using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalCrossingTeam.Core.Exceptions
{
    public class PoissonExisteDéjà : Exception
    {
        public PoissonExisteDéjà() :
            base("Le poisson existe déjà.")
        {
        }
    }

    public class PoissonExistePas : Exception
    {
        public PoissonExistePas() :
            base("Le poisson n'existe pas.")
        {
        }
    }
}
