using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Hotel.Models;
using System.Data.Entity;
using Hotel.Migrations;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Hotel.Controllers
{
    [Authorize]
    public class GostiController : Controller
    {
        // GET: Gosti
        private ApplicationDbContext _context;
        public GostiController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult New()
        {
            return View("GostForm", new Gost());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Gost gost)
        {
            if (!ModelState.IsValid)
            {
                return View("GostForm", gost);
            }

            if (gost.Id == 0)
            _context.Gosti.Add(gost);
            else
            {
                var gostInDb = _context.Gosti.Single(g => g.Id == gost.Id);

                gostInDb.ImePrezime = gost.ImePrezime;
                gostInDb.Email = gost.Email;
                gostInDb.BrojTelefona = gost.BrojTelefona;

            }
            _context.SaveChanges();

            return RedirectToAction("Index", "Gosti");
        }

        public ActionResult Edit(int id)
        {
            var gost = _context.Gosti.SingleOrDefault(g => g.Id == id);

            if (gost == null)
                return HttpNotFound();

            return View("GostForm",gost);
        }

        public ActionResult Delete(int id)
        {
            var gost = _context.Gosti.Find(id);

            if (gost == null)
            {
                return HttpNotFound();
            }

            _context.Gosti.Remove(gost);

            _context.SaveChanges();

            return RedirectToAction("Index", "Gosti");
        }
        public ActionResult Index()
        {
            var gost = _context.Gosti.ToList();
            return View(gost);
        }
           
    }

    
}