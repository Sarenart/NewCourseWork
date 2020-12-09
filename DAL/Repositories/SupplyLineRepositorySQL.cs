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
    public class SupplyLineRepositorySQL:IRepository<SupplyLine>
    {
        private CourseWorkContext db;
        public SupplyLineRepositorySQL(CourseWorkContext db)
        {
            this.db = db;
        }
        public List<SupplyLine> GetList()
        {
            return db.SupplyLine.ToList();
        }
        public SupplyLine GetItem(int id)
        {
            return db.SupplyLine.Find(id);
        }
        public void Create(SupplyLine item)
        {
            db.SupplyLine.Add(item);
        }
        public void Update(SupplyLine item)
        {
            db.Entry(item).State = System.Data.Entity.EntityState.Modified;
        }
        public void Delete(int id)
        {
            SupplyLine item = db.SupplyLine.Find(id);
            if (item != null)
                db.SupplyLine.Remove(item);
        }
    }
}
