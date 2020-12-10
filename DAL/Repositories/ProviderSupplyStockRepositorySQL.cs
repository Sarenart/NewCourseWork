using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces;

namespace DAL.Repositories
{
    public class ProviderSupplyStockRepositorySQL:IRepository<ProviderSupplyStock>
    {
        private SupplyDb db;
        public ProviderSupplyStockRepositorySQL(SupplyDb db)
        {
            this.db = db;
        }
        public List<ProviderSupplyStock> GetList()
        {
            return db.ProviderSupplyStock.ToList();
        }
        public ProviderSupplyStock GetItem(int id)
        {
            return db.ProviderSupplyStock.Find(id);
        }
        public void Create(ProviderSupplyStock item)
        {
            db.ProviderSupplyStock.Add(item);
        }
        public void Update(ProviderSupplyStock item)
        {
            db.Entry(item).State = System.Data.Entity.EntityState.Modified;
        }
        public void Delete(int id)
        {
            ProviderSupplyStock item = db.ProviderSupplyStock.Find(id);
            if (item != null)
                db.ProviderSupplyStock.Remove(item);
        }
    }
}
