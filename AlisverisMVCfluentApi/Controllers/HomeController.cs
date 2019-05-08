using BLL;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AlisverisMVCfluentApi.Controllers
{
    public class HomeController : Controller
    {

        UnitofWork work = new UnitofWork();
        public ActionResult Index()
        {


            List<Urun> liste;
            ///using kullanmak ıcn Idisposable misras almıs class icn yapabliriz
            using (UnitofWork uw = new UnitofWork())
            {

                liste = uw.UrunRep.Listele();
            }
         
            return View(liste);

        }
        [HttpPost]
        public ActionResult Index(string numeric)
        {


            Urun u = new Urun() {
                UrunAdi = "burak"

            };
            return RedirectToAction("Ekle","Home",u);
      
        }

        public ActionResult Ekle(Urun u)
        {
            int id = 1;
         //   work.SepetManager.UrunEkle(u.UrunId, id, Convert.ToInt32(numeric));
           
            return View();
        }

     
    }
}