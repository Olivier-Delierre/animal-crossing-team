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
        private readonly IBeteService _BeteService;

        public InsectesController(IBeteService BeteService)
        {
            _BeteService = BeteService;
        }

        public IActionResult Index() => View();

        [HttpPost]
        public IActionResult Ajouter(Insecte insecte)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (!(_BeteService.GetInsecte(insecte.Numero.Value) is null))
            {
                ModelState.AddModelError(nameof(insecte.Numero), "L'identifiant est déjà utilisé.");
                return BadRequest(ModelState);
            }

            _BeteService.AddInsecte(insecte);
            return Json("ok");
        }

        [HttpPost]
        public IActionResult Modifier(Insecte insecte)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (_BeteService.GetInsecte(insecte.Numero.Value) is null)
            {
                ModelState.AddModelError(nameof(insecte.Numero), "Cet insecte n'existe pas.");
                return BadRequest(ModelState);
            }

            _BeteService.UpdateInsecte(insecte);
            return Json("ok");
        }

        [Route("/Insecte/{numéro}")]
        public IActionResult Insecte(int numéro)
            => View(_BeteService.GetInsecte(numéro));

        public IEnumerable<Insecte> GetInsectes()
            => _BeteService.GetInsectes();

        public Insecte GetInsecte(int numéro)
            => _BeteService.GetInsecte(numéro);

        public void RemoveInsecte(int numéro)
            => _BeteService.RemoveInsecte(numéro);

        public PartialViewResult PartialInsecteModal(int? numéro)
        {
            if (numéro is null)
            {
                return PartialView();
            }

            return PartialView(_BeteService.GetInsecte(numéro.Value));
        }
    }
}