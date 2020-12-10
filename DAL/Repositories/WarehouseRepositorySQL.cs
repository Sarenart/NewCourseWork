using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces;

namespace DAL.Repositories
{
    public class WarehouseRepositorySQL:IRepository<Warehouse>
    {
        private SupplyDb db;
        public WarehouseRepositorySQL(SupplyDb db)
        {
            this.db = db;
        }
        public List<Warehouse> GetList()
        {
            return db.Warehouse.ToList();
        }
        public Warehouse GetItem(int id)
        {
            return db.Warehouse.Find(id);
        }
        public void Create(Warehouse item)
        {
            db.Warehouse.Add(item);
        }
        public void Update(Warehouse item)
        {
            db.Entry(item).State = System.Data.Entity.EntityState.Modified;
        }
        public void Delete(int id)
        {
            Warehouse item = db.Warehouse.Find(id);
            if (item != null)
                db.Warehouse.Remove(item);
        }
    }
}
