using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AnimalCrossingTeam.Core.Contexts;
using AnimalCrossingTeam.Core.Contexts.Interfaces;
using AnimalCrossingTeam.Core.Models;
using AnimalCrossingTeam.Core.Services;
using AnimalCrossingTeam.Core.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AnimalCrossingTeam.Web.Controllers
{
    public class InsectesController : Controller
    {
        private readonly IBêteService _bêteService;

        public InsectesController(IBêteService bêteService)
        {
            _bêteService = bêteService;
        }

        public IActionResult Index() => View();

        [HttpPost]
        public IActionResult Ajouter(Insecte insecte)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (!(_bêteService.GetInsecte(insecte.Numéro.Value) is null))
            {
                ModelState.AddModelError(nameof(insecte.Numéro), "L'identifiant est déjà utilisé.");
                return BadRequest(ModelState);
            }

            _bêteService.AddInsecte(insecte);
            return Json("ok");
        }

        [HttpPost]
        public IActionResult Modifier(Insecte insecte)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (_bêteService.GetInsecte(insecte.Numéro.Value) is null)
            {
                ModelState.AddModelError(nameof(insecte.Numéro), "Cet insecte n'existe pas.");
                return BadRequest(ModelState);
            }

            _bêteService.UpdateInsecte(insecte);
            return Json("ok");
        }

        [Route("/Insecte/{numéro}")]
        public IActionResult Insecte(int numéro)
            => View(_bêteService.GetInsecte(numéro));

        public IEnumerable<Insecte> GetInsectes()
            => _bêteService.GetInsectes();

        public Insecte GetInsecte(int numéro)
            => _bêteService.GetInsecte(numéro);

        public void RemoveInsecte(int numéro)
            => _bêteService.RemoveInsecte(numéro);

        public PartialViewResult PartialInsecteModal(int? numéro)
        {
            if (numéro is null)
            {
                return PartialView();
            }

            return PartialView(_bêteService.GetInsecte(numéro.Value));
        }
    }
}