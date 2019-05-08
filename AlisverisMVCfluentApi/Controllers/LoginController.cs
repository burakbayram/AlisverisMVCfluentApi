using BLL;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AlisverisMVCfluentApi.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        UnitofWork work = new UnitofWork();
        public ActionResult Login()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Login(Musteri m)
        {
          
          var musteri=  work.musteriManager.GirisYap(m.Email, m.Sifre);
            if (musteri != null) { 
            Session["id"] =musteri.MusteriId;
            }
            else
            {

                return View(m);
            }
            return RedirectToAction("Index","Home");
        }
        public ActionResult Kayit()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Kayit(Musteri m,string sifretekrar)
        {
            if (m.Sifre != sifretekrar)
            {
                ViewBag.Error = "Sifre eslesmiyor";
                return View();
            }
            try
            {
                work.musteriManager.Kayit(m);
               
            }
            catch (Exception ex)
            {

                ViewBag.Error = ex.Message;
                return View();
            }
           
           
       
            return RedirectToAction("Login", "Login");
        }
        
    }
}