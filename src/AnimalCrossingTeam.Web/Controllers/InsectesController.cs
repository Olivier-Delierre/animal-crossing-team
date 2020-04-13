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
        private readonly IBeteService _beteService;

        public InsectesController(IBeteService beteService)
        {
            _beteService = beteService;
        }

        public IActionResult Index() => View();

        [HttpPost]
        public IActionResult Ajouter(Insecte insecte)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (!(_beteService.GetInsecte(insecte.Numero.Value) is null))
            {
                ModelState.AddModelError(nameof(insecte.Numero), "L'identifiant est déjà utilisé.");
                return BadRequest(ModelState);
            }

            _beteService.AddInsecte(insecte);
            return Json("ok");
        }

        [HttpPost]
        public IActionResult Modifier(Insecte insecte)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (_beteService.GetInsecte(insecte.Numero.Value) is null)
            {
                ModelState.AddModelError(nameof(insecte.Numero), "Cet insecte n'existe pas.");
                return BadRequest(ModelState);
            }

            _beteService.UpdateInsecte(insecte);
            return Json("ok");
        }

        [Route("/Insecte/{numero}")]
        public IActionResult Insecte(int numero)
            => View(_beteService.GetInsecte(numero));

        public IEnumerable<Insecte> GetInsectes()
            => _beteService.GetInsectes();

        public Insecte GetInsecte(int numero)
            => _beteService.GetInsecte(numero);

        [HttpPost]
        public void RemoveInsecte(int numero)
            => _beteService.RemoveInsecte(numero);

        public PartialViewResult PartialInsecteModal(int? numero)
        {
            if (numero is null)
            {
                return PartialView();
            }

            return PartialView(_beteService.GetInsecte(numero.Value));
        }
    }
}