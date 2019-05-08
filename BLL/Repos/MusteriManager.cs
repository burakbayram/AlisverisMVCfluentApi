using BLL.Services;
using DAL;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Repos
{
    public class MusteriManager<TEntity> where TEntity : Musteri
    {
        AlisverisContext _db;
        IEmailService _emailService;
        public MusteriManager(AlisverisContext db,IEmailService emailService)
        {
            _emailService = emailService;
            _db = db;
        }
        public bool Kayit(Musteri yeni)
        {
         
            _db.Musteriler.Add(yeni);
            int row = _db.SaveChanges();
           
            return row> 0;

        }
        public Musteri GirisYap(string email, string sifre)
        {

            Musteri m = _db.Musteriler.Where(x => x.Email == email && x.Sifre == sifre).FirstOrDefault();
            return m;
        }


        public bool SifreDegistir(int id,string eskiSifre, string yeniSifre)
        {
            Musteri m = _db.Musteriler.Find(id);
            if (m.Sifre == eskiSifre)
            {
                m.Sifre = yeniSifre;
                //linq update
                _db.Entry(m).State = System.Data.Entity.EntityState.Modified;
                return _db.SaveChanges()>0;
            }
            
            
            return false;

        }
        /// <summary>
        /// nırmalde boyle olmaz sifreleme algortna kullanırız burda kullanmmaık.w
        /// </summary>
        /// <param name="email"></param>
        public void SifreHatirlat(string email)
        {
            var kisi = _db.Musteriler.FirstOrDefault(x => x.Email == email);
            if (kisi != null)
            {
                ViewModel.EmailViewModel mail = new ViewModel.EmailViewModel();
                mail.To = email;
                mail.Subject = "Sifre hatırlatma";
                mail.ISHtml = true;
                mail.Message = @"
<h1>Sifrehatırlatma</h1>
<p>Sifreniz:<b>" + kisi.Sifre + "</b></p>";
                _emailService.SendMail(mail);
            }


        }
    }
}
