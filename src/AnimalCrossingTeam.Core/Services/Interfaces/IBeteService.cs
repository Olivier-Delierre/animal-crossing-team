using System;
using System.Collections.Generic;
using System.Text;
using AnimalCrossingTeam.Core.Models;

namespace AnimalCrossingTeam.Core.Services.Interfaces
{
    public interface IBeteService
    {
        IEnumerable<Insecte> GetInsectes();
        IEnumerable<Poisson> GetPoissons();

        Insecte GetInsecte(int numero);
        Poisson GetPoisson(int numero);

        void UpdateInsecte(Insecte insecte);
        void UpdatePoisson(Poisson poisson);

        void AddInsecte(Insecte insecte);
        void AddPoisson(Poisson poisson);

        void RemoveInsecte(int numero);
        void RemovePoisson(int numero);

        List<Bete> SearchBetes(string term);
        List<Bete> GetLastBetes();
    }
}
