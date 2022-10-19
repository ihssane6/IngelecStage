using IngelecDroguerries.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IngelecDroguerries.ViewModel
{
    public class DroguerrieDestributeurViewModel
    {
        public int DroguerrieId { get; set; }
        [Required]
        [MaxLength(20)]
        [MinLength(5)]
        public String NomDroguerrie { get; set; }

        [Required]
        [MaxLength(10)]
        [MinLength(10)]
        public String TelDroguerrie { get; set; }

        [Required]
        [MaxLength(30)]
        [MinLength(10)]
        public String EmailDroguerrie { get; set; }

        [Required]
        [MaxLength(70)]
        [MinLength(10)]
        public String AdressDroguerrie { get; set; }
        public int DestributeurId { get; set; }
        public List<Destributeur> Destributeurs { get; set; }
    }
}

