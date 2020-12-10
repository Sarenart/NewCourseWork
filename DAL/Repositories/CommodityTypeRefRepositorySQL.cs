using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using DAL.Context;
using DAL.Interfaces;

namespace DAL.Repositories
{
    public class CommodityTypeRefRepositorySQL:IRepository<CommodityTypeRef>
    {
        private SupplyDb db;
        public CommodityTypeRefRepositorySQL(SupplyDb db)
        {
            this.db = db;
        }
        public List<CommodityTypeRef> GetList()
        {
            return db.CommodityTypeRef.ToList();
        }
        public CommodityTypeRef GetItem(int id)
        {
            return db.CommodityTypeRef.Find(id);
        }
        public void Create(CommodityTypeRef item)
        {
            db.CommodityTypeRef.Add(item);
        }
        public void Update(CommodityTypeRef item)
        {
            db.Entry(item).State = System.Data.Entity.EntityState.Modified;
        }
        public void Delete(int id)
        {
            CommodityTypeRef item = db.CommodityTypeRef.Find(id);
            if (item != null)
                db.CommodityTypeRef.Remove(item);
        }
    }
}
