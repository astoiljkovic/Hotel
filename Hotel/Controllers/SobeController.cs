using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Hotel.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Hotel.Controllers
{
    
    public class SobeController : Controller
    {
        private ApplicationDbContext _context;
        public SobeController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        
        [Authorize]
        public ActionResult New()
        {
            return View("SobaForm", new Soba());
        }

        public ActionResult Index()
        {
            var soba = _context.Sobe.ToList();
            return View(soba);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        
        [Authorize]
        public ActionResult Save(Soba soba)
        {
            if (!ModelState.IsValid)
            {
                return View("SobaForm", soba);
            }

            if (soba.Id == 0)
                _context.Sobe.Add(soba);
            else
            {
                var sobaInDb = _context.Sobe.Single(g => g.Id == soba.Id);

                sobaInDb.TipSobe = soba.TipSobe;
                sobaInDb.Kvadratura = soba.Kvadratura;
                sobaInDb.Lezaj = soba.Lezaj;
                sobaInDb.Opis = soba.Opis;

            }
            _context.SaveChanges();

            return RedirectToAction("Index", "Sobe");
        }

        [Authorize]
        public ActionResult Edit(int id)
        {
            var sobe = _context.Sobe.SingleOrDefault(s => s.Id == id);

            if (sobe == null)
                return HttpNotFound();

            return View("SobaForm", sobe);
        }

        [Authorize]
        public ActionResult Delete(int id)
        {
            var soba = _context.Sobe.Find(id);

            if (soba == null)
            {
                return HttpNotFound();
            }

            _context.Sobe.Remove(soba);

            _context.SaveChanges();

            return RedirectToAction("Index", "Sobe");
        }

       
    }
}