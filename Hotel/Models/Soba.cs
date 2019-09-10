using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Hotel.Models
{
    public class Soba
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string TipSobe { get; set; }
        public string Kvadratura { get; set; }
        public string Lezaj { get; set; }
        public string Opis { get; set; }
    }
}