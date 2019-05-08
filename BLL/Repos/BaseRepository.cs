using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Repos
{
  public class BaseRepository<TEntity,TKey> where TEntity:class
    {
        AlisverisContext _db;
        public BaseRepository(AlisverisContext db)
        {
            _db = db;
        }
        public List<TEntity> Listele()
        {

          return  _db.Set<TEntity>().ToList();

        }
        public TEntity IdileGetir(TKey id)
        {
            return _db.Set<TEntity>().Find(id);
        }

        public void Delete(TKey id)
        {
            var silkayit = IdileGetir(id);
            _db.Set<TEntity>().Remove(silkayit);
        }

        public void Ekle(TEntity yeni)
        {
            _db.Set<TEntity>().Add(yeni);
        }

        public void Guncelle(TEntity guncel)
        {
            ///id alanınnı yakalama yı yap
            ///
            Type t = typeof(TEntity);
            var  p = t.GetProperty(t.Name + "Id");
            TKey id = (TKey)p.GetValue(guncel);


            var eski = IdileGetir(id);
            _db.Entry(eski).CurrentValues.SetValues(guncel);

        }

    }
}
