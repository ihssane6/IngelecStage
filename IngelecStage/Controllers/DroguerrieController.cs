using IngelecDroguerries.Models;
using IngelecDroguerries.Models.Reposotories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using IngelecDroguerries.ViewModel;
using Microsoft.AspNetCore.Authorization;

namespace IngelecDroguerries.Controllers
{
    [Authorize]
    public class DroguerrieController : Controller
    {
        private readonly IDroguerrieDestributeur<Drouguerrie> droguerrieRepository;
        private readonly IDroguerrieDestributeur<Destributeur> destributeurRepository;
        private readonly IHostingEnvironment hosting;

        public DroguerrieController(IDroguerrieDestributeur<Drouguerrie> droguerrieRepository,
            IDroguerrieDestributeur<Destributeur> destributeurRepository,
            IHostingEnvironment hosting)
        {
            this.droguerrieRepository = droguerrieRepository;
            this.destributeurRepository = destributeurRepository;
            this.hosting = hosting;
        }
        // GET: DroguerrieController
        public ActionResult Index()
        {
            var droguerries = droguerrieRepository.List();
            return View(droguerries);
        }

        // GET: DroguerrieController/Details/5
        public ActionResult Details(int id)
        {
            var droguerrie = droguerrieRepository.Find(id);
            return View(droguerrie);
        }

        // GET: DroguerrieController/Create
        [Authorize(Policy = "policy")]
        public ActionResult Create()
        {
            var model = new DroguerrieDestributeurViewModel
            {
                Destributeurs = FillSelectList()
            };
            return View(model);
        }

        List<Destributeur> FillSelectList()
        {
            var destributeurs = destributeurRepository.List().ToList();
            destributeurs.Insert(0, new Destributeur { Id = -1, NomDestributeur = "--- Please select distrubuteurs ---" });

            return destributeurs;
        }

        // POST: DroguerrieController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Policy = "policy")]
        public ActionResult Create(DroguerrieDestributeurViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {


                    if (model.DestributeurId == -1)
                    {
                        ViewBag.Message = "Please select distrubuteurs from the list!";

                        return View(GetAllDestributeur());
                    }

                    var destributeur = destributeurRepository.Find(model.DestributeurId);
                    Drouguerrie droguerrie = new Drouguerrie
                    {
                        Id = model.DroguerrieId,
                        Nom = model.NomDroguerrie,
                        Adresse = model.AdressDroguerrie,
                        Destributeur = destributeur,
                        Email = model.EmailDroguerrie,
                        Tel = model.TelDroguerrie
                    };

                    droguerrieRepository.Add(droguerrie);

                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    return View();
                }
            }


            ModelState.AddModelError("", "You have to fill all the required fields!");
            return View(GetAllDestributeur());
        }

        DroguerrieDestributeurViewModel GetAllDestributeur()
        {
            var vmodel = new DroguerrieDestributeurViewModel
            {
                Destributeurs = FillSelectList()
            };

            return vmodel;
        }


        // GET: DroguerrieController/Edit/5
        [Authorize(Policy = "policy")]
        public ActionResult Edit(int id)
        {
            var droguerrie = droguerrieRepository.Find(id);
            var destributeurId = droguerrie.Destributeur == null ? droguerrie.Destributeur.Id = 0 : droguerrie.Destributeur.Id;

            var viewModel = new DroguerrieDestributeurViewModel
            {
                DroguerrieId = droguerrie.Id,
                NomDroguerrie = droguerrie.Nom,
                EmailDroguerrie = droguerrie.Email,
                TelDroguerrie=droguerrie.Tel,
                AdressDroguerrie=droguerrie.Adresse,
                DestributeurId = destributeurId,
                Destributeurs = destributeurRepository.List().ToList()
                
            };

            return View(viewModel);
        }

        // POST: DroguerrieController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Policy = "policy")]
        public ActionResult Edit(DroguerrieDestributeurViewModel viewModel)
        {
            try
            {
                // TODO: Add update logic here


                var destributeur = destributeurRepository.Find(viewModel.DestributeurId);
                Drouguerrie drouguerrie = new Drouguerrie
                {
                    Id = viewModel.DroguerrieId,
                    Nom = viewModel.NomDroguerrie,
                    Email = viewModel.EmailDroguerrie,
                    Tel = viewModel.TelDroguerrie,
                    Adresse = viewModel.AdressDroguerrie,
                    Destributeur = destributeur

                };

                droguerrieRepository.Update(viewModel.DroguerrieId, drouguerrie);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                return View();
            }
        }

        // GET: DroguerrieController/Delete/5
        [Authorize(Policy = "policy")]
        public ActionResult Delete(int id)
          
        {
            var droguerrie = droguerrieRepository.Find(id);
            return View(droguerrie);
        }

        // POST: DroguerrieController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Policy = "policy")]
        public ActionResult ConfirmDelete(int id)
        {
            try
            {
                droguerrieRepository.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }



        }
        public ActionResult Search(String term)
        {
            var result = droguerrieRepository.Search(term);
            return View("Index",result);
        }

    }
}
