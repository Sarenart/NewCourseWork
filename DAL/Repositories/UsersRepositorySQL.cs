using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Models;
using DAL.Interfaces;

namespace DAL.Repositories
{
    public class UsersRepositorySQL:IRepository<Users>
    {
        private CourseWorkContext db;
        public UsersRepositorySQL(CourseWorkContext db)
        {
            this.db = db;
        }
        public List<Users> GetList()
        {
            return db.Users.ToList();
        }
        public Users GetItem(int id)
        {
            return db.Users.Find(id);
        }
        public void Create(Users item)
        {
            db.Users.Add(item);
        }
        public void Update(Users item)
        {
            db.Entry(item).State = System.Data.Entity.EntityState.Modified;
        }
        public void Delete(int id)
        {
            Users item = db.Users.Find(id);
            if (item != null)
                db.Users.Remove(item);
        }
    }
}
