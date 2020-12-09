using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DAL.Interfaces;
using DAL.Repositories;

namespace BLL.DataOperations
{
    public class DbDataOperations
    {
        private DbRepositorySQLServer repos;

        public DbDataOperations(/*DbRepository IDbRepos*/) {
            repos = new DbRepositorySQLServer();
        }

        public List<BLL.BusinessModels.Commodity> GetCommodities()
        {
            return repos.Commodities.GetList().Select(i => new BLL.BusinessModels.Commodity 
            { 
              Name = i.Name, 
              Cost = i.Price, 
              Type = i.CommodityType 
            }).ToList();
        }
    }
}
