using System;
using System.Collections.Generic;
using System.Text;
using AnimalCrossingTeam.Core.Contexts;
using AnimalCrossingTeam.Core.Contexts.Interfaces;
using AnimalCrossingTeam.Core.Models;

namespace AnimalCrossingTeam.Core.Services
{
    public class NavetService
    {
        private readonly INavetContext _navetContext;

        public NavetService(INavetContext navetContext)
        {
            _navetContext = navetContext;
        }

        public IEnumerable<Navet> GetNavets() => _navetContext.GetNavets();
        public IEnumerable<Navet> GetNavetsForRange(DateTime début, DateTime fin) 
            => _navetContext.GetNavetsForRange(début, fin);

        public IEnumerable<string> GetPersonnesForRange(DateTime début, DateTime fin) 
            => _navetContext.GetPersonnesForRange(début, fin);

        public Navet GetNavet(Navet navet) => _navetContext.GetNavet(navet);
        public void AddNavet(Navet navet) => _navetContext.AddNavet(navet);
    }
}
