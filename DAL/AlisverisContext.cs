using Entity;
using System.Data.Entity;

namespace DAL
{
    public class AlisverisContext:DbContext

    {
        public AlisverisContext():base("AlisverisCon")
        {
            //lazy lodadiing 
            //this.Configuration.LazyLoadingEnabled = false;
            ////forexhte olduki virtual kullandın unuttun permans dustu bunu yazarsan virtual ızın vermez,include ile getirmemiz gerekşir.
        }
        public virtual  DbSet<Urun> Urunler { get; set;}
        public virtual  DbSet<Musteri> Musteriler { get; set; }
        public virtual  DbSet<Sepet> Sepetler { get; set; }
        public virtual DbSet<SepetUrun> SepetUrunler { get; set; }


        /// <summary>
        /// Fluent Api 
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(DbModelBuilder mb)
        {
            #region tableSettings
            //primary key 
            mb.Entity<Urun>().ToTable("tblUrunler").HasKey(x => x.UrunId).HasIndex(x => x.BirimFiyati).HasName("IX_Fiyat");
            mb.Entity<Musteri>().HasKey(x => x.MusteriId);
            mb.Entity<Sepet>().HasKey(x => x.MusteriId);
            //Composit key coka cok ilişkilerde
            mb.Entity<SepetUrun>().HasKey(x => new { x.SepetId, x.UrunId });
            #endregion //# ile baslayabn seyler preporocoses
            #region PropAyarları

            mb.Entity<Urun>()
                .Property(x => x.UrunAdi).IsRequired().HasMaxLength(150)
                .IsUnicode().HasColumnType("nvarchar");
            mb.Entity<Musteri>().Property(x => x.AdSoyad).IsRequired().HasMaxLength(120);
            mb.Entity<Musteri>().Property(x => x.Email).HasMaxLength(300);
            mb.Entity<Musteri>().Property(x => x.Sifre).HasMaxLength(16);
            mb.Entity<Musteri>().Property(x => x.Telefon).HasMaxLength(25);


            #endregion
            #region relationShip
            //Bire bir ilişki 1-1
            mb.Entity<Musteri>().HasRequired(mus => mus.Sepet).WithRequiredPrincipal(sepet => sepet.Musteri);
            // ! 1-many 
            mb.Entity<Sepet>().HasMany(sepet => sepet.Urunler)
               .WithRequired(surun => surun.UrunSepet)
               .HasForeignKey(spux =>spux.SepetId);
            // 1-many
            mb.Entity<SepetUrun>().HasRequired(surun => surun.Urun)
                .WithMany(urun => urun.SepetUrun)
                .HasForeignKey(surun => surun.UrunId);

            #endregion
            base.OnModelCreating(mb);
        }
    }
}
