using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AnimalCrossingTeam.Core.Models;
using AnimalCrossingTeam.Core.Services;
using AnimalCrossingTeam.Core.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AnimalCrossingTeam.Web.Controllers
{
    public class PoissonsController : Controller
    {
        private readonly IBeteService _BeteService;

        public PoissonsController(IBeteService BeteService)
        {
            _BeteService = BeteService;
        }

        public IActionResult Index() => View();

        [HttpPost]
        public IActionResult Ajouter(Poisson poisson)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (!(_BeteService.GetPoisson(poisson.Numero.Value) is null))
            {
                ModelState.AddModelError(nameof(poisson.Numero), "L'identifiant est déjà utilisé.");
                return BadRequest(ModelState);
            }

            _BeteService.AddPoisson(poisson);
            return Json("ok");
        }

        [HttpPost]
        public IActionResult Modifier(Poisson poisson)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (_BeteService.GetPoisson(poisson.Numero.Value) is null)
            {
                ModelState.AddModelError(nameof(poisson.Numero), "Ce poisson n'existe pas.");
                return BadRequest(ModelState);
            }

            _BeteService.UpdatePoisson(poisson);
            return Json("ok");
        }

        [Route("/Poisson/{numéro}")]
        public IActionResult Poisson(int numéro)
            => View(_BeteService.GetPoisson(numéro));

        public IEnumerable<Poisson> GetPoissons()
            => _BeteService.GetPoissons();

        public Poisson GetPoisson(int numéro)
            => _BeteService.GetPoisson(numéro);

        public void RemovePoisson(int numéro)
            => _BeteService.RemovePoisson(numéro);

        public PartialViewResult PartialPoissonModal(int? numéro)
        {
            if (numéro is null)
            {
                return PartialView();
            }

            return PartialView(_BeteService.GetPoisson(numéro.Value));
        }
    }
}