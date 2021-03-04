using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using crudApp.Models;
using Microsoft.AspNetCore.Authorization;

namespace crudApp.Controllers
{

    [Authorize]

    public class etudiant : Controller
    {

      

        EtudiantDal etudiantDal = new EtudiantDal();

        public IActionResult Index()
        {
            List<EtudiantInfo> etdList = new List<EtudiantInfo>();
            etdList = etudiantDal.GetAllEtudiant().ToList();
            return View(etdList);

        }

        [HttpGet]

        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Create([Bind] EtudiantInfo objEtd)
        {
            if (ModelState.IsValid)
            {
                etudiantDal.AddEtudiant(objEtd);
                return RedirectToAction("Index");
            }

            return View(objEtd);
        }




        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            EtudiantInfo etd = etudiantDal.GetEtudiantById(id);

            if (etd == null)
            {
                return NotFound();
            }

            return View(etd);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Edit(int? id , [Bind] EtudiantInfo objEtd)
        {
            if (id == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                etudiantDal.UpdateEtudiant(objEtd);
                return RedirectToAction("Index");
            }
            return View(etudiantDal);
        }


        [HttpGet]

        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            EtudiantInfo etd = etudiantDal.GetEtudiantById(id);
            if (etd == null)
            {
                return NotFound();
            }
            return View(etd);
        }


        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            EtudiantInfo etd = etudiantDal.GetEtudiantById(id);
            if (etd == null)
            {
                return NotFound();
            }
            return View(etd);
        }

        [HttpPost,ActionName("Delete")]
        [ValidateAntiForgeryToken]

        public IActionResult DeleteEtd(int? id)
        {
            etudiantDal.deleteEtudiant(id);
            return RedirectToAction("Index");
        }
    } 
}
