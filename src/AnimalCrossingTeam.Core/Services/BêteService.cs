using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using AnimalCrossingTeam.Core.Contexts;
using AnimalCrossingTeam.Core.Contexts.Interfaces;
using AnimalCrossingTeam.Core.Exceptions;
using AnimalCrossingTeam.Core.Models;

namespace AnimalCrossingTeam.Core.Services
{
    public class BêteService
    {
        private readonly IBêteContext _bêteContext;
        public BêteService(IBêteContext bêteContext)
        {
            _bêteContext = bêteContext;
        }

        public IEnumerable<Insecte> GetInsectes() => _bêteContext.GetInsectes();
        public IEnumerable<Poisson> GetPoissons() => _bêteContext.GetPoissons();

        public Insecte GetInsecte(int numéro)
            => _bêteContext.GetInsecte(numéro);
        public Poisson GetPoisson(int numéro)
            => _bêteContext.GetPoisson(numéro);

        public void UpdateInsecte(Insecte insecte)
        {
            var ancienInsecte = GetInsecte(insecte.Numéro);
            if (ancienInsecte is null)
            {
                throw new InsecteExistePas();
            }

            _bêteContext.UpdateInsecte(insecte);
        }
        public void UpdatePoisson(Poisson poisson)
        {
            var ancienPoisson = GetPoisson(poisson.Numéro);
            if (ancienPoisson is null)
            {
                throw new PoissonExistePas();
            }

            _bêteContext.UpdatePoisson(poisson);
        }

        public void AddInsecte(Insecte insecte)
        {
            var ancienInsecte = GetInsecte(insecte.Numéro);
            if (!(ancienInsecte is null))
            {
                throw new InsecteExisteDéjà();
            }

            _bêteContext.AddInsecte(insecte);
        }
        public void AddPoisson(Poisson poisson)
        {
            var ancienPoisson = GetPoisson(poisson.Numéro);
            if (!(ancienPoisson is null))
            {
                throw new PoissonExisteDéjà();
            }

            _bêteContext.AddPoisson(poisson);
        }

        public void RemoveInsecte(int numéro)
        {
            var ancienInsecte = GetInsecte(numéro);
            if (ancienInsecte is null)
            {
                throw new InsecteExistePas();
            }

            _bêteContext.RemoveInsecte(numéro);
        }
        public void RemovePoisson(int numéro)
        {
            var ancienPoisson = GetPoisson(numéro);
            if (ancienPoisson is null)
            {
                throw new PoissonExistePas();
            }

            _bêteContext.RemovePoisson(numéro);
        }
    }
}
