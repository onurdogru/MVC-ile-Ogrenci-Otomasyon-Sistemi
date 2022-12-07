using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OgrenciMVC.Controllers
{
    public class HesapTestController : Controller
    {
        // GET: HesapTest
        public ActionResult Index(int sayi1, int sayi2)
        {
            int sonuc = sayi1 + sayi2;
            ViewBag.snc= sonuc;
            return View();
        }
    }
}