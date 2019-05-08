using BLL.Repos;
using BLL.Services;
using DAL;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    //Idisposable
    public class UnitofWork:IDisposable
    {
        AlisverisContext _db = new AlisverisContext();
     public   BaseRepository<Urun, int> UrunRep;
       public MusteriManager<Musteri> musteriManager;
        IEmailService _emailService = new GmailService();
        public SepetManager SepetManager;
        public UnitofWork()
        {
            UrunRep = new BaseRepository<Urun, int>(_db);
            musteriManager = new MusteriManager<Musteri>(_db, _emailService);
            SepetManager = new SepetManager(_db);
        }
        public void Complete()
        {
            _db.SaveChanges();
        }

        public void Dispose()
        {
            _db.Dispose();
            _emailService = null; //Bieseyi null edersek refrarnsı koparmıs oluruz cop kutusu gider temizler
            UrunRep = null;
            SepetManager = null;
            musteriManager = null;
        }
    }
}
