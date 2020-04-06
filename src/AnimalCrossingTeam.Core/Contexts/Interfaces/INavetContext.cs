using System;
using System.Collections.Generic;
using System.Text;
using AnimalCrossingTeam.Core.Models;

namespace AnimalCrossingTeam.Core.Contexts.Interfaces
{
    public interface INavetContext
    {
        IEnumerable<Navet> GetNavets();
        IEnumerable<Navet> GetNavetsForRange(DateTime début, DateTime fin);
        IEnumerable<string> GetPersonnesForRange(DateTime début, DateTime fin);
        Navet GetNavet(Navet navet);
        void AddNavet(Navet navet);
    }
}
