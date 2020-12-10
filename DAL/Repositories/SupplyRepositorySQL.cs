using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces;

namespace DAL.Repositories
{
    public class SupplyRepositorySQL:IRepository<Supply>
    {
        private SupplyDb db;
        public SupplyRepositorySQL(SupplyDb db)
        {
            this.db = db;
        }
        public List<Supply> GetList()
        {
            return db.Supply.ToList();
        }
        public Supply GetItem(int id)
        {
            return db.Supply.Find(id);
        }
        public void Create(Supply item)
        {
            db.Supply.Add(item);
        }
        public void Update(Supply item)
        {
            db.Entry(item).State = System.Data.Entity.EntityState.Modified;
        }
        public void Delete(int id)
        {
            Supply item = db.Supply.Find(id);
            if (item != null)
                db.Supply.Remove(item);
        }
    }
}
