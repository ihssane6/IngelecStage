using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Threading.Tasks;

namespace IngelecDroguerries.Models.Reposotories
{
    public class DroguerrieDbRepository:IDroguerrieDestributeur<Drouguerrie>
    {
        DroguerieDbContext db;
        public DroguerrieDbRepository(DroguerieDbContext _db)
        {
            db = _db; 
        }

        public void Add(Drouguerrie entity)
        {
            db.Droguerries.Add(entity);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var drouguerrie = Find(id);

            db.Droguerries.Remove(drouguerrie);
            db.SaveChanges();
        }

        public Drouguerrie Find(int id)
        {

            var droguerrie = db.Droguerries.Include(a => a.Destributeur).SingleOrDefault(b => b.Id == id);

            return droguerrie;
        }

        public IList<Drouguerrie> List()
        {
            return db.Droguerries.Include(a => a.Destributeur).ToList();
        }

        public List<Drouguerrie> Search(string term)
        {
            var result = db.Droguerries.Include(a => a.Destributeur)
                .Where(b => b.Nom.Contains(term)
                        || b.Email.Contains(term)
                        || b.Adresse.Contains(term)
                        || b.Tel.Contains(term)
                        || b.Destributeur.NomDestributeur.Contains(term)).ToList();

            return result;
        }

        public void Update(int id, Drouguerrie newDroguerrrie)
        {
            db.Update(newDroguerrrie);
            db.SaveChanges();
        }
    }
}
