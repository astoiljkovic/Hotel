using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace Hotel.Models
{
    public class Rezervacija
    {
        public int Id { get; set; }

        [Required]
        public Soba Soba { get; set; }
        public byte SobaId { get; set; }

        [Required]
        public Gost Gost { get; set; }
        public byte GostId { get; set; }

        [Required]
        public DateTime DatumDolaska { get; set; }

        [Required]
        public int BrojNocenja { get; set; }

        [Required]
        public NacinPlacanja NacinPlacanja { get; set; }
        [Display(Name = "Nacin placanja")]
        public byte NacinPlacanjaId { get; set; }

    }
}