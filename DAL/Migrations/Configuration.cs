namespace DAL.Migrations
{
    using Entity;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DAL.AlisverisContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(DAL.AlisverisContext context)
        {
            if (context.Musteriler.Count() == 0)
            {
                Musteri m = new Musteri();
                m.Adres = "istanbul";
                m.AdSoyad = "Burak Bayram";
                m.Email = "bb@gmail.com";
                m.Telefon = "55555";
                m.Sifre = "123";
                context.Musteriler.Add(m);
                context.SaveChanges();

            }
            if (context.Urunler.Count() == 0)
            {

                Urun u = new Urun();
                u.Aciklama = "saat ";
                u.BirimFiyati = 200;
                u.UrunAdi = "diesel";
                Urun u1 = new Urun();
                u1.Aciklama = "saat ";
                u1.BirimFiyati = 400;
                u1.UrunAdi = "Fossil";

                context.Urunler.Add(u);
                context.Urunler.Add(u1);
                context.SaveChanges();

            }
        }
    }
}
