using DAL;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Repos
{
   public class SepetManager
    {
        AlisverisContext _db;
        public SepetManager(AlisverisContext db)
        {
            _db = db;
        }
        public void UrunEkle(int urunId,int musteriId,int Adet)
        {
            var bulunansepet=  _db.Sepetler.Find(musteriId);
            var sepeturun = bulunansepet.Urunler.FirstOrDefault(x => x.UrunId == urunId);
            if (sepeturun == null)
            {
                //bu ut-runu ılk defa aılmısız
                SepetUrun urun = new SepetUrun();
                urun.UrunId = urunId;
                urun.SepetId = bulunansepet.MusteriId;
                urun.BirimFiyat = _db.Urunler.Find(urunId).BirimFiyati;
                urun.Adet = Adet;
                bulunansepet.Urunler.Add(urun);
            
            }
            else
            {
                ///bu urunu daha once almısız adet artıralım
                ///
                sepeturun.Adet += Adet;
                _db.Entry(sepeturun).State = System.Data.Entity.EntityState.Modified;
            }

        }
        public void UrunSil(int urunId, int musteriId)
        {
            var sepet = _db.Sepetler.Find(musteriId);
            var sepeturun = sepet.Urunler.FirstOrDefault(x => x.UrunId == urunId);
            _db.SepetUrunler.Remove(sepeturun);
        }

        public Sepet SepetGetir(int musteriId)
        {

            return _db.Sepetler.Find(musteriId);
        }

    }
}
