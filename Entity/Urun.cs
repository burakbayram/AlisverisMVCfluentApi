using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Urun
    {
        public int UrunId { get; set; }
        public string UrunAdi { get; set; }
        public string Aciklama { get; set; }
        public decimal BirimFiyati { get; set; }

        
        public virtual  List<SepetUrun> SepetUrun { get; set; }
     
    }
    //public enum UrunBirim
    //{
    //    Adet,
    //}
}
