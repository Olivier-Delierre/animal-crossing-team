using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using AnimalCrossingTeam.Core.Contexts;
using AnimalCrossingTeam.Core.Contexts.Interfaces;
using AnimalCrossingTeam.Core.Exceptions;
using AnimalCrossingTeam.Core.Models;
using AnimalCrossingTeam.Core.Services.Interfaces;

namespace AnimalCrossingTeam.Core.Services
{
    public class BeteService : IBeteService
    {
        private readonly IBeteContext _beteContext;
        public BeteService(IBeteContext beteContext)
        {
            _beteContext = beteContext;
        }

        public IEnumerable<Insecte> GetInsectes() => _beteContext.GetInsectes();
        public IEnumerable<Poisson> GetPoissons() => _beteContext.GetPoissons();

        public Insecte GetInsecte(int numéro)
            => _beteContext.GetInsecte(numéro);
        public Poisson GetPoisson(int numéro)
            => _beteContext.GetPoisson(numéro);

        public void UpdateInsecte(Insecte insecte)
        {
            var ancienInsecte = GetInsecte(insecte.Numero.Value);
            if (ancienInsecte is null)
            {
                throw new InsecteExistePas();
            }

            insecte.DateAjout = DateTime.Now;
            _beteContext.UpdateInsecte(insecte);
        }
        public void UpdatePoisson(Poisson poisson)
        {
            var ancienPoisson = GetPoisson(poisson.Numero.Value);
            if (ancienPoisson is null)
            {
                throw new PoissonExistePas();
            }

            poisson.DateAjout = DateTime.Now;
            _beteContext.UpdatePoisson(poisson);
        }

        public void AddInsecte(Insecte insecte)
        {
            var ancienInsecte = GetInsecte(insecte.Numero.Value);
            if (!(ancienInsecte is null))
            {
                throw new InsecteExisteDéjà();
            }

            insecte.DateAjout = DateTime.Now;
            _beteContext.AddInsecte(insecte);
        }
        public void AddPoisson(Poisson poisson)
        {
            var ancienPoisson = GetPoisson(poisson.Numero.Value);
            if (!(ancienPoisson is null))
            {
                throw new PoissonExisteDéjà();
            }

            poisson.DateAjout = DateTime.Now;
            _beteContext.AddPoisson(poisson);
        }

        public void RemoveInsecte(int numéro)
        {
            var ancienInsecte = GetInsecte(numéro);
            if (ancienInsecte is null)
            {
                throw new InsecteExistePas();
            }

            _beteContext.RemoveInsecte(numéro);
        }
        public void RemovePoisson(int numéro)
        {
            var ancienPoisson = GetPoisson(numéro);
            if (ancienPoisson is null)
            {
                throw new PoissonExistePas();
            }

            _beteContext.RemovePoisson(numéro);
        }

        public List<Bete> SearchBetes(string term)
        {
            var Betes = new List<Bete>();

            Betes.AddRange(_beteContext.GetInsectes()
                .Where(x => x.Nom.ToLower().StartsWith(term.ToLower()))
                .OrderBy(x => x.Nom));
            Betes.AddRange(_beteContext.GetPoissons()
                .Where(x => x.Nom.ToLower().StartsWith(term.ToLower()))
                .OrderBy(x => x.Nom));

            return Betes;
        }

        public List<Bete> GetLastBetes()
        {
            var Betes = new List<Bete>();

            Betes.AddRange(_beteContext.GetInsectes());
            Betes.AddRange(_beteContext.GetPoissons());
            Betes = Betes.OrderByDescending(x => x.DateAjout)
                .Take(10)
                .ToList();

            return Betes;
        }
    }
}
