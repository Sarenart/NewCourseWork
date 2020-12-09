using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using DAL.Context;
using DAL.Models;
using DAL.Interfaces;

namespace DAL.Repositories
{
    public class CommodityRepositorySQL: IRepository<Commodity>
    {
        private CourseWorkContext db;
        public CommodityRepositorySQL(CourseWorkContext db)
        {
            this.db = db;
        }
        public List<Commodity> GetList()
        {
            return db.Commodity.ToList();
        }
        public Commodity GetItem(int id)
        {
            return db.Commodity.Find(id);
        }
        public void Create(Commodity item)
        {
            db.Commodity.Add(item);
        }
        public void Update(Commodity item) {
            db.Entry(item).State = System.Data.Entity.EntityState.Modified;
        }
        public void Delete(int id)
        {
            Commodity item = db.Commodity.Find(id);
            if (item != null)
                db.Commodity.Remove(item);
        }
    }
}
