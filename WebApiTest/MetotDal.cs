using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApiTest.Models.Entity;

namespace WebApiTest
{
    public class MetotDal
    {
        WebApiEntities db = new WebApiEntities();

        public IEnumerable<Tbl_Urunler> Get()
        {
            return db.Tbl_Urunler.ToList();
        }

        public Tbl_Urunler GetbyId(int id)
        {
            return db.Tbl_Urunler.Find(id);
        }

        public Tbl_Urunler Create(Tbl_Urunler p)
        {
            db.Tbl_Urunler.Add(p);
            db.SaveChanges();
            return p; 
        }

        public Tbl_Urunler Update(int id, Tbl_Urunler p)
        {
            db.Entry(p).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return p;
        }

        
        public bool KayitVarmi(int id)
        {

            //Update yapmadan kayıt varmı diye kontrol edelim.
            return db.Tbl_Urunler.Any(x => x.UrunID == id);
        }

        public void Delete(int id)
        {
            var yakala = db.Tbl_Urunler.Find(id);
            db.Tbl_Urunler.Remove(yakala);
            db.SaveChanges();
        }



    }
}