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
    public class BeteContext : DbContext, IBeteContext
    {
        public DbSet<Insecte> Insectes { get; set; }
        public DbSet<Poisson> Poissons { get; set; }

        public BeteContext(DbContextOptions<BeteContext> options)
            : base(options)
        {
        }

        public IEnumerable<Insecte> GetInsectes() => Insectes;
        public IEnumerable<Poisson> GetPoissons() => Poissons;

        public Insecte GetInsecte(int numero)
            => Insectes.SingleOrDefault(x => x.Numero == numero);
        public Poisson GetPoisson(int numero)
            => Poissons.SingleOrDefault(x => x.Numero == numero);

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
            RemoveInsecte(insecte.Numero.Value);
            AddInsecte(insecte);
            SaveChanges();
        }

        public void UpdatePoisson(Poisson poisson)
        {
            RemovePoisson(poisson.Numero.Value);
            AddPoisson(poisson);
            SaveChanges();
        }

        public void RemoveInsecte(int numero)
        {
            Insecte insecte = GetInsecte(numero);
            Insectes.Remove(insecte);
            SaveChanges();
        }

        public void RemovePoisson(int numero)
        {
            Poisson poisson = GetPoisson(numero);
            Poissons.Remove(poisson);
            SaveChanges();
        }
    }
}
