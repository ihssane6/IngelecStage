using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IngelecDroguerries.Models.Reposotories
{
    public class DroguerrieRepository : IDroguerrieDestributeur<Drouguerrie>
    {
        List<Drouguerrie> drouguerries;
        public DroguerrieRepository()
        {
            drouguerries = new List<Drouguerrie>()
            {
                new Drouguerrie { Id = 1, Nom = "Droguerie Electricité Soufiani", Adresse = "110, bd du Onze Janvier , Q. Benjdia, 20130 CASABLANCA", Tel = "0522446391", Email = "soufiani@gmail.com", Destributeur = new Destributeur()
                },
            };
        }
        public void Add(Drouguerrie entity)
        {
            entity.Id = drouguerries.Max(b => b.Id) + 1;
            drouguerries.Add(entity);
        }

        public void Delete(int id)
        {
            var drouguerrie = Find(id);

            drouguerries.Remove(drouguerrie);
        }

        public Drouguerrie Find(int id)
        {
            var droguerrie = drouguerries.SingleOrDefault(b => b.Id == id);

            return droguerrie;
        }

        public IList<Drouguerrie> List()
        {
            return drouguerries;
        }

        public List<Drouguerrie> Search(string term)
        {
            return drouguerries.Where(a => a.Nom.Contains(term)).ToList();
        }

        public void Update(int id, Drouguerrie newDroguerrie)
        {
            var droguerrie = Find(id);
            droguerrie.Nom = newDroguerrie.Nom;
            droguerrie.Tel = newDroguerrie.Tel;
            droguerrie.Email = newDroguerrie.Email;
            droguerrie.Adresse = newDroguerrie.Adresse;
            droguerrie.Destributeur = newDroguerrie.Destributeur;

        }
    }
}
