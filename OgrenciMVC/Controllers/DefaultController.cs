using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OgrenciMVC.Models.EntityFramework;

namespace OgrenciMVC.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        DbMvcOkulEntities db = new DbMvcOkulEntities();
        public ActionResult Index()
        {
            var dersler = db.TBLDERSLER.ToList(); //index metodu bu işlemi yapması gerekir.
            return View(dersler);
        }

        [HttpGet]
        public ActionResult YeniDers()
        {
            return View();
        }

        [HttpPost] //Değer gönderme işlemi yaptığım zaman çalışacak.
        public ActionResult YeniDers(TBLDERSLER p) //sonradan içine parametre yazdık
        {
            db.TBLDERSLER.Add(p); //ders ekleme alanı, sonradan eklenmiştir.
            db.SaveChanges(); //veritabanında değişikleri kaydetme işlemi. Sonradan eklenen alan.

            return View();
        }
        //sonradan eklenen alan-Ders Silme işlemi
        public ActionResult Sil(int id)
        {
            var ders = db.TBLDERSLER.Find(id);
            db.TBLDERSLER.Remove(ders);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        //Ders Taşıma
        public ActionResult DersGetir(int id)
        {
            var ders = db.TBLDERSLER.Find(id);
            return View("DersGetir", ders);
        }
        //Ders Güncelleme
        public ActionResult Guncelle(TBLDERSLER p)
        {
            var drs = db.TBLDERSLER.Find(p.DERSID);
            drs.DERSAD = p.DERSAD;
            db.SaveChanges();
            return RedirectToAction("Index", "Default");
        }
    }
}