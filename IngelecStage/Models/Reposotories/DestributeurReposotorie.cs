using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IngelecDroguerries.Models.Reposotories
{
    public class DestributeurReposotorie : IDroguerrieDestributeur<Destributeur>
    {
        IList<Destributeur> destributeurs;

        public DestributeurReposotorie()
        {
            destributeurs = new List<Destributeur>()
            {
                new Destributeur {Id=1,NomDestributeur="TELECO MAROC",Adresse="Casablanca",Email="telecom@telecomaroc.com",Tel="0522233172"},
               

            };
        }
        public void Add(Destributeur entity)
        {
            entity.Id = destributeurs.Max(a => a.Id) + 1;
            destributeurs.Add(entity);
        }

       

        public void Delete(int id)
        {
            var destributeur = Find(id);

            destributeurs.Remove(destributeur);
        }

        public Destributeur Find(int id)
        {
            var destributeur = destributeurs.SingleOrDefault(a => a.Id == id);

            return destributeur;
        }

        public IList<Destributeur> List()
        {
            return destributeurs;
        }

        public List<Destributeur> Search(string term)
        {
            return destributeurs.Where(a => a.NomDestributeur.Contains(term)).ToList();
        }

        public void Update(int id, Destributeur newDestributeur)
        {
            var destributeur = Find(id);

            destributeur.NomDestributeur = newDestributeur.NomDestributeur;
            destributeur.Adresse = newDestributeur.Adresse;
            destributeur.Email = newDestributeur.Email;
            destributeur.Tel = newDestributeur.Tel;
        }

     

        
    }
}

