using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IngelecDroguerries.Models.Reposotories
{
    public class DestributeurDbRepository : IDroguerrieDestributeur<Destributeur>
    {
        DroguerieDbContext db;
        public DestributeurDbRepository(DroguerieDbContext _db)
        {
            db = _db;
        }

        public void Add(Destributeur entity)
        {
            db.Destributeurs.Add(entity);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var destributeur = Find(id);

            db.Destributeurs.Remove(destributeur);
            db.SaveChanges();
        }

        public Destributeur Find(int id)
        {
            var destributeur = db.Destributeurs.SingleOrDefault(a => a.Id == id);

            return destributeur;
        }

        public IList<Destributeur> List()
        {
            return db.Destributeurs.ToList();
        }

        public List<Destributeur> Search(string term)
        {
            var result = db.Destributeurs
               .Where(b => b.NomDestributeur.Contains(term)
                       || b.Email.Contains(term)
                       || b.Adresse.Contains(term)
                       || b.Tel.Contains(term)).ToList();
            return result;
        }

        public void Update(int id, Destributeur newDestributeur)
        {
            db.Update(newDestributeur);
            db.SaveChanges();
        }
    }
}
