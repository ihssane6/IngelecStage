using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IngelecDroguerries.Models
{
    public class Destributeur
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(20)]
        [MinLength(5)]
        public String NomDestributeur { get; set; }
        [Required]
        [MaxLength(70)]
        [MinLength(10)]
        public String Adresse { get; set; }
        [Required]
        [MaxLength(10)]
        [MinLength(10)]
        public String Tel { get; set; }
        [Required]
        [MaxLength(30)]
        [MinLength(10)]
        public String Email { get; set; }

    }
}
