using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using AnimalCrossingTeam.Core.Contexts.Interfaces;
using AnimalCrossingTeam.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace AnimalCrossingTeam.Core.Contexts
{
    public class NavetContext : DbContext, INavetContext
    {
        public DbSet<Navet> Navets { get; set; }

        public NavetContext(DbContextOptions<NavetContext> options)
            : base(options)
        {
        }

        public IEnumerable<Navet> GetNavets()
            => Navets;

        public IEnumerable<Navet> GetNavetsForRange(DateTime début, DateTime fin)
            => Navets.Where(x => x.Date >= début && x.Date <= fin);

        public IEnumerable<string> GetPersonnesForRange(DateTime début, DateTime fin)
            => Navets.Where(x => x.Date >= début && x.Date <= fin)
                .Select(x => x.Personne)
                .Distinct();

        public Navet GetNavet(Navet navet)
            => Navets.SingleOrDefault(x => x.Personne == navet.Personne &&
                                           x.Date == navet.Date &&
                                           x.Matin == navet.Matin);

        public void AddNavet(Navet navet)
        {
            var navetDansContext = GetNavet(navet);
            if (!(navetDansContext is null))
            {
                Navets.Remove(navetDansContext);
            }

            Navets.Add(navet);
            SaveChanges();
        }
    }
}
