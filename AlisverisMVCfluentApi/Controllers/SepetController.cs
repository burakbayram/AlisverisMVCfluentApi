using BLL;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AlisverisMVCfluentApi.Controllers
{
    public class SepetController : Controller
    {
        // GET: Sepet
        UnitofWork work = new UnitofWork();
        public ActionResult Ekle( )
        {

            work.SepetManager.UrunEkle(1, 1, 1);
           
            return View(work.SepetManager.SepetGetir(1));
        }
    }
}