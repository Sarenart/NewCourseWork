using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Models;
using DAL.Interfaces;

namespace DAL.Repositories
{
    public class WarehouseLinesRepositorySQL:IRepository<WarehouseLine>
    {
        private CourseWorkContext db;
        public WarehouseLinesRepositorySQL(CourseWorkContext db)
        {
            this.db = db;
        }
        public List<WarehouseLine> GetList()
        {
            return db.WarehouseLine.ToList();
        }
        public WarehouseLine GetItem(int id)
        {
            return db.WarehouseLine.Find(id);
        }
        public void Create(WarehouseLine item)
        {
            db.WarehouseLine.Add(item);
        }
        public void Update(WarehouseLine item)
        {
            db.Entry(item).State = System.Data.Entity.EntityState.Modified;
        }
        public void Delete(int id)
        {
            WarehouseLine item = db.WarehouseLine.Find(id);
            if (item != null)
                db.WarehouseLine.Remove(item);
        }
    }
}
