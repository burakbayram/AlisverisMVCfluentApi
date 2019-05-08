using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Sepet
    {

        public int MusteriId { get; set; } //Hem pk hem foreighkey olmalı bir tablo gibi bire bir ilişki Müsteri tablosuyla
        public DateTime OlusturulmaTarihi { get; set; }

        public decimal AraToplam { get; set; }
        public virtual List<SepetUrun> Urunler { get; set; }
        public virtual  Musteri Musteri { get; set; }

        public Sepet()
        {
            OlusturulmaTarihi = DateTime.Now;
            Urunler = new List<SepetUrun>();
            // musteri=new Musteri();
        }
    }

    public class SepetUrun
    {
        public int SepetId { get; set; } //Foreighkey
        public int UrunId { get; set; }
        /// <summary>
        /// Composit key framework kenii olustuabliyor burakı ozellik ayrıyaten ozellik ekleme Adet Gib mesela
        /// </summary>
        public decimal BirimFiyat { get; set; }
        public int Adet { get; set; }
        public decimal Fiyat
        {
            get { return Adet * BirimFiyat; }
        }
        public virtual  Sepet UrunSepet { get; set; }
        public virtual Urun Urun { get; set; }
    }
}
