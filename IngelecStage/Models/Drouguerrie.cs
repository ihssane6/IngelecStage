using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IngelecDroguerries.Models
{
    public class Drouguerrie
    {
        public int Id { get; set; }
        public String Nom { get; set; }

        public String Adresse { get; set; }
        public String Tel { get; set; }
        public String Email { get; set; }
        public Destributeur Destributeur { get; set; }
    }
}
