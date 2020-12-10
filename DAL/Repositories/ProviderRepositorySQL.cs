using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using DAL.Context;
using DAL.Interfaces;

namespace DAL.Repositories
{
    public class ProviderRepositorySQL:IRepository<Provider>
    {
        private SupplyDb db;
        public ProviderRepositorySQL(SupplyDb db)
        {
            this.db = db;
        }
        public List<Provider> GetList()
        {
            return db.Provider.ToList();
        }
        public Provider GetItem(int id)
        {
            return db.Provider.Find(id);
        }
        public void Create(Provider item)
        {
            db.Provider.Add(item);
        }
        public void Update(Provider item)
        {
            db.Entry(item).State = System.Data.Entity.EntityState.Modified;
        }
        public void Delete(int id)
        {
            Provider item = db.Provider.Find(id);
            if (item != null)
                db.Provider.Remove(item);
        }
    }
}
