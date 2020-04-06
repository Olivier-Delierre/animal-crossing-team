using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AnimalCrossingTeam.Core.Contexts.Interfaces;
using AnimalCrossingTeam.Core.Exceptions;
using AnimalCrossingTeam.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace AnimalCrossingTeam.Core.Contexts
{
    public class BêteContext : DbContext, IBêteContext
    {
        public DbSet<Insecte> Insectes { get; set; }
        public DbSet<Poisson> Poissons { get; set; }

        public BêteContext(DbContextOptions<BêteContext> options)
            : base(options)
        {
        }

        public IEnumerable<Insecte> GetInsectes() => Insectes;
        public IEnumerable<Poisson> GetPoissons() => Poissons;

        public Insecte GetInsecte(int numéro)
            => Insectes.SingleOrDefault(x => x.Numéro == numéro);
        public Poisson GetPoisson(int numéro)
            => Poissons.SingleOrDefault(x => x.Numéro == numéro);

        public void AddInsecte(Insecte insecte)
        {
            Insectes.Add(insecte);
            SaveChanges();
        }

        public void AddPoisson(Poisson poisson)
        {
            Poissons.Add(poisson);
            SaveChanges();
        }

        public void UpdateInsecte(Insecte insecte)
        {
            RemoveInsecte(insecte.Numéro.Value);
            AddInsecte(insecte);
            SaveChanges();
        }

        public void UpdatePoisson(Poisson poisson)
        {
            RemovePoisson(poisson.Numéro.Value);
            AddPoisson(poisson);
            SaveChanges();
        }

        public void RemoveInsecte(int numéro)
        {
            Insecte insecte = GetInsecte(numéro);
            Insectes.Remove(insecte);
        }

        public void RemovePoisson(int numéro)
        {
            Poisson poisson = GetPoisson(numéro);
            Poissons.Remove(poisson);
        }
    }
}
