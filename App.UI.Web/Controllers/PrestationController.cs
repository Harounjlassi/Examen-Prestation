using System.IO.Pipelines;
using App.ApplicationCore.Domain;
using App.ApplicationCore.Interfaces;
using App.ApplicationCore.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace App.UI.Web.Controllers
{
    public class PrestationController : Controller
    {
        IUnitOfWork unitOfWork;

        IService<Prestation> prestationService;
        IService<Prestataire> prestataireService;

        public PrestationController(IUnitOfWork unitOfWork, IService<Prestation> prestationService, IService<Prestataire> prestataireService)
        {
            this.unitOfWork = unitOfWork;
            this.prestationService = prestationService;
            this.prestataireService = prestataireService;
        }





        // GET: PrestationController
        public ActionResult Index()
        {
            return View(prestationService.GetAll());
        }

        // GET: PrestationController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PrestationController/Create
        public ActionResult Create()
        {
            ViewBag.PrestataireList = new SelectList(prestataireService.GetAll(), "PrestataireId", "PrestataireNom");

            return View();
        }

        // POST: PrestationController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Prestation pre)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View();
                }
                
               ViewBag.PrestataireList = new SelectList(prestataireService.GetAll(), "PrestataireId", "PrestataireNom");

                prestationService.Add(pre);
                unitOfWork.Commit();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PrestationController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PrestationController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PrestationController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PrestationController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
