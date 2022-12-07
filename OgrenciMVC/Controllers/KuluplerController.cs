using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OgrenciMVC.Models.EntityFramework;

namespace OgrenciMVC.Controllers
{
    public class KuluplerController : Controller
    {
        // GET: Kulupler
        DbMvcOkulEntities db = new DbMvcOkulEntities();
        public ActionResult Index()
        {
            var kulupler = db.TBLKULUPLER.ToList();
            return View(kulupler);
        }
        [HttpGet]
        public ActionResult YeniKulup()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniKulup(TBLKULUPLER p2) //parametre.2
        {
            db.TBLKULUPLER.Add(p2);
            db.SaveChanges();
            return View();
        }
        //Kulüp Silme İşlemi
        public ActionResult Sil(int id)
        {
            var kulup=db.TBLKULUPLER.Find(id);
            db.TBLKULUPLER.Remove(kulup);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //Kulüp Taşıma İşlemi
        public ActionResult KulupGetir(int id)
        {
            var kulup = db.TBLKULUPLER.Find(id);
            return View("KulupGetir",kulup);
        }
        //Kulüp Güncelleme
        public ActionResult Guncelle(TBLKULUPLER p)
        {
            var klp = db.TBLKULUPLER.Find(p.KULUPID);
            klp.KULUPAD = p.KULUPAD;
            db.SaveChanges();
            return RedirectToAction("Index", "Kulupler");
        }
    }
}