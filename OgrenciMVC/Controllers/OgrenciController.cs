using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OgrenciMVC.Models.EntityFramework;

namespace OgrenciMVC.Controllers
{
    public class OgrenciController : Controller
    {
        // GET: Ogrenci
        DbMvcOkulEntities db = new DbMvcOkulEntities();
        public ActionResult Index()
        {
            var ogrenciler = db.TBLOGRENCILER.ToList();
            return View(ogrenciler);
        }
        [HttpGet]
        public ActionResult YeniOgrenci()
        {
            //Linkq Sorgusu? (Sonradan eklenen kısım)
            List<SelectListItem> degerler = (from i in db.TBLKULUPLER.ToList()
                                         select new SelectListItem
                                         {
                                             Text = i.KULUPAD,
                                             Value = i.KULUPID.ToString()
                                         }).ToList();
            ViewBag.dgr = degerler;
            return View();
        }
        [HttpPost]
        public ActionResult YeniOgrenci(TBLOGRENCILER p3) //parametre p3 anlamında kullanılır.
        {
            //sonradan eklenen alan
            var klp = db.TBLKULUPLER.Where(m=>m.KULUPID == p3.TBLKULUPLER.KULUPID).FirstOrDefault();
            p3.TBLKULUPLER = klp;



            db.TBLOGRENCILER.Add(p3);
            db.SaveChanges();
            //return View();
            return RedirectToAction("Index"); //işlem bittikten sonraki yönlendirme kısmı
        }

        //sonradan eklenen alan-öğrenci silme
        public ActionResult Sil(int id)
        {
            var ogrenci = db.TBLOGRENCILER.Find(id);
            db.TBLOGRENCILER.Remove(ogrenci);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        //Öğrenci Bilgilerini Getirme
        public ActionResult OgrenciGetir(int id)
        {
            var ogrenci = db.TBLOGRENCILER.Find(id);
            return View("OgrenciGetir", ogrenci);
        }

        //Bölüm (Öğrenci) Güncelleme
        public ActionResult Guncelle(TBLOGRENCILER p)
        {
            var ogr = db.TBLOGRENCILER.Find(p.OGRENCIID);
            {
                ogr.OGRAD = p.OGRAD;
                ogr.OGRSOYAD = p.OGRSOYAD;
                ogr.OGRFOTOGRAF = p.OGRFOTOGRAF;
                ogr.OGRCINSIYET = p.OGRCINSIYET;
                ogr.OGRKULUP = p.OGRKULUP;
                db.SaveChanges();
                return RedirectToAction("Index", "Ogrenci");

            }
        }
    }
}