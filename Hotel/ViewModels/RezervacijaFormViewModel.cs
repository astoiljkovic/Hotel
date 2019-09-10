using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Hotel.Models;

namespace Hotel.ViewModels
{
    public class RezervacijaFormViewModel
    {
        public IEnumerable<Soba> Sobe { get; set; }
        public IEnumerable<Gost> Gosti { get; set; }
        public IEnumerable<NacinPlacanja> NacinPlacanja { get; set; }
        public Rezervacija Rezervacija { get; set; }
    }
}