using IngelecDroguerries.Models;
using IngelecDroguerries.Models.Reposotories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IngelecDroguerries.Controllers
{
    [Authorize]
    public class DestributeurController : Controller
    {
        private readonly IDroguerrieDestributeur<Destributeur> destributeurRepository;

        public DestributeurController(IDroguerrieDestributeur<Destributeur> destributeurRepository)
        {
            this.destributeurRepository = destributeurRepository;
        }
        // GET: DestributeurController
        [AllowAnonymous]
        public ActionResult Index()

        {
            var destributeurs = destributeurRepository.List();
            return View(destributeurs);
        }
        [AllowAnonymous]
        // GET: DestributeurController/Details/5
        public ActionResult Details(int id)
        {
            var destributeurs = destributeurRepository.Find(id);
            return View(destributeurs);
        }

        // GET: DestributeurController/Create
        [Authorize(Policy = "readpolicy")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: DestributeurController/Create
       
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Policy = "readpolicy")]
        public ActionResult Create(Destributeur destributeur)
        {
            try
            {
                destributeurRepository.Add(destributeur);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: DestributeurController/Edit/5
        [Authorize(Policy = "readpolicy")]
        public ActionResult Edit(int id)
        {
            var destributeur = destributeurRepository.Find(id);
            return View(destributeur);
        }

        // POST: DestributeurController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Policy = "readpolicy")]
        public ActionResult Edit(int id, Destributeur destributeur)
        {
            try
            {
                destributeurRepository.Update(id, destributeur);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: DestributeurController/Delete/5
        [Authorize(Policy = "readpolicy")]
        public ActionResult Delete(int id)
        {
            var destributeur = destributeurRepository.Find(id);
            return View(destributeur);
        }

        // POST: DestributeurController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Policy = "readpolicy")]
        public ActionResult Delete(int id, Destributeur destributeur)
        {
            try
            {
                destributeurRepository.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        public ActionResult Search(String term)
        {
            var result = destributeurRepository.Search(term);
            return View("Index", result);
        }
    }
}
