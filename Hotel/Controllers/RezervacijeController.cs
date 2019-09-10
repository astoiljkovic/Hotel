using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Hotel.Models;
using System.Data.Entity;
using Hotel.ViewModels;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Hotel.Controllers
{
    [Authorize]
    public class RezervacijeController : Controller
    {
        // GET: Rezervacije
        private ApplicationDbContext _context;
        public RezervacijeController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult New()
        {
            var nacinPlacanja = _context.NacinPlacanja.ToList();
            var viewModel = new RezervacijaFormViewModel()
            {
                Rezervacija = new Rezervacija(),
                Gosti = _context.Gosti.ToList(),
                Sobe = _context.Sobe.ToList(),
                NacinPlacanja = _context.NacinPlacanja.ToList()
            };
            return View("RezervacijaForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Rezervacija rezervacija)
        {
            if(!ModelState.IsValid)
            {
                var viewModel = new RezervacijaFormViewModel
                {
                    Rezervacija = rezervacija,
                    Gosti = _context.Gosti.ToList(),
                    Sobe = _context.Sobe.ToList(),
                    NacinPlacanja = _context.NacinPlacanja.ToList()
                };
                return View("RezervacijaForm", viewModel);
            }

            if(rezervacija.Id == 0)
                _context.Rezervacije.Add(rezervacija);
            else
            {
                var rezervacijaInDb = _context.Rezervacije.Single(r => r.Id == rezervacija.Id);


                rezervacijaInDb.Gost = rezervacija.Gost;
                rezervacijaInDb.Soba = rezervacija.Soba;
                rezervacijaInDb.DatumDolaska = rezervacija.DatumDolaska;
                rezervacijaInDb.BrojNocenja = rezervacija.BrojNocenja;
                rezervacijaInDb.NacinPlacanja = rezervacija.NacinPlacanja;

            }
            _context.SaveChanges();

            return RedirectToAction("Index", "Rezervacije");
        }

        public ActionResult Edit(int id)
        {
            var rezervacije = _context.Rezervacije.SingleOrDefault(r => r.Id == id);

            if (rezervacije == null)
                return HttpNotFound();

            var viewModel = new RezervacijaFormViewModel
            {
                Rezervacija = rezervacije,
                Gosti = _context.Gosti.ToList(),
                Sobe = _context.Sobe.ToList(),
                NacinPlacanja = _context.NacinPlacanja.ToList()
            };

            return View("RezervacijaForm", rezervacije);
        }

        public ActionResult Delete(int id)
        {
            var rezervacija = _context.Rezervacije.Find(id);

            if (rezervacija == null)
            {
                return HttpNotFound();
            }

            _context.Rezervacije.Remove(rezervacija);
            _context.SaveChanges();
            return RedirectToAction("Index", "Rezervacije");
        }

        public ActionResult Index()
        {
            var rezervacija = _context.Rezervacije.Include(r => r.Gost).Include(r => r.Soba).Include(r => r.NacinPlacanja).ToList();
            return View(rezervacija);
        }

        
    }
}