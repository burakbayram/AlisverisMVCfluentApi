using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    /// <summary>
    /// Poco sınıfı Palin old Clr object duz sınıflara verien ad
    /// </summary>
    public class Musteri
    {
        public int MusteriId { get; set; }
        public string AdSoyad { get; set; }
        public string Adres { get; set; }
        public string Telefon { get; set; }
        public string Email { get; set; }

        public string Sifre { get; set; }
        public DateTime KayitTarihi { get; set; }
        public virtual Sepet Sepet { get; set; } = new Sepet();
        public Musteri()
        {
            KayitTarihi = DateTime.Now;
        }


    }
}
