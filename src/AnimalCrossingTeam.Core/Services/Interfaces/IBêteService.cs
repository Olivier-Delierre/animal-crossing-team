using System;
using System.Collections.Generic;
using System.Text;
using AnimalCrossingTeam.Core.Models;

namespace AnimalCrossingTeam.Core.Services.Interfaces
{
    public interface IBêteService
    {
        IEnumerable<Insecte> GetInsectes();
        IEnumerable<Poisson> GetPoissons();

        Insecte GetInsecte(int numéro);
        Poisson GetPoisson(int numéro);

        void UpdateInsecte(Insecte insecte);
        void UpdatePoisson(Poisson poisson);

        void AddInsecte(Insecte insecte);
        void AddPoisson(Poisson poisson);

        void RemoveInsecte(int numéro);
        void RemovePoisson(int numéro);

        List<Bête> SearchBêtes(string term);
        List<Bête> GetLastBêtes();
    }
}
