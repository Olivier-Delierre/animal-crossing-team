using System;
using System.Collections.Generic;
using System.Text;
using AnimalCrossingTeam.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace AnimalCrossingTeam.Core.Contexts.Interfaces
{
    public interface IBeteContext
    {
        IEnumerable<Insecte> GetInsectes();
        IEnumerable<Poisson> GetPoissons();

        Insecte GetInsecte(int numero);
        Poisson GetPoisson(int numero);

        void AddInsecte(Insecte insecte);
        void AddPoisson(Poisson poisson);

        void UpdateInsecte(Insecte insecte);
        void UpdatePoisson(Poisson poisson);

        void RemoveInsecte(int numero);
        void RemovePoisson(int numero);
    }
}
