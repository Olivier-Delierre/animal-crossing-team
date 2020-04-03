using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalCrossingTeam.Core.Exceptions
{
    public class InsecteExisteDéjà : Exception
    {
        public InsecteExisteDéjà() :
            base("L'insecte existe déjà.")
        {
        }
    }

    public class InsecteExistePas : Exception
    {
        public InsecteExistePas() :
            base("L'insecte n'existe pas.")
        {
        }
    }
}
