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
        private readonly IBêteService _bêteService;

        public PoissonsController(IBêteService bêteService)
        {
            _bêteService = bêteService;
        }

        public IActionResult Index() => View();

        [HttpPost]
        public IActionResult Ajouter(Poisson poisson)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (!(_bêteService.GetPoisson(poisson.Numéro.Value) is null))
            {
                ModelState.AddModelError(nameof(poisson.Numéro), "L'identifiant est déjà utilisé.");
                return BadRequest(ModelState);
            }

            _bêteService.AddPoisson(poisson);
            return Json("ok");
        }

        [HttpPost]
        public IActionResult Modifier(Poisson poisson)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (_bêteService.GetPoisson(poisson.Numéro.Value) is null)
            {
                ModelState.AddModelError(nameof(poisson.Numéro), "Ce poisson n'existe pas.");
                return BadRequest(ModelState);
            }

            _bêteService.UpdatePoisson(poisson);
            return Json("ok");
        }

        [Route("/Poisson/{numéro}")]
        public IActionResult Poisson(int numéro)
            => View(_bêteService.GetPoisson(numéro));

        public IEnumerable<Poisson> GetPoissons()
            => _bêteService.GetPoissons();

        public Poisson GetPoisson(int numéro)
            => _bêteService.GetPoisson(numéro);

        public void RemovePoisson(int numéro)
            => _bêteService.RemovePoisson(numéro);

        public PartialViewResult PartialPoissonModal(int? numéro)
        {
            if (numéro is null)
            {
                return PartialView();
            }

            return PartialView(_bêteService.GetPoisson(numéro.Value));
        }
    }
}