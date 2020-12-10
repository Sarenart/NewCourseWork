using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using DAL.Context;
using DAL.Interfaces;

namespace DAL.Repositories
{
    public class SupplyStatusRefRepositorySQL:IRepository<SupplyStatusRef>
    {
        private SupplyDb db;
        public SupplyStatusRefRepositorySQL(SupplyDb db)
        {
            this.db = db;
        }
        public List<SupplyStatusRef> GetList()
        {
            return db.SupplyStatusRef.ToList();
        }
        public SupplyStatusRef GetItem(int id)
        {
            return db.SupplyStatusRef.Find(id);
        }
        public void Create(SupplyStatusRef item)
        {
            db.SupplyStatusRef.Add(item);
        }
        public void Update(SupplyStatusRef item)
        {
            db.Entry(item).State = System.Data.Entity.EntityState.Modified;
        }
        public void Delete(int id)
        {
            SupplyStatusRef item = db.SupplyStatusRef.Find(id);
            if (item != null)
                db.SupplyStatusRef.Remove(item);
        }
    }
}
