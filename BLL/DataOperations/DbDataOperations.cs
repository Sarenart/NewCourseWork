using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DAL.Interfaces;
using DAL.Repositories;
using BLL.BusinessModels;

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
            return repos.Commodities.GetList().Join(repos.CommodityRefs.GetList(), i => i.CommodityType, j => j.Id, (i, j) => new { Name = i.Name, CommodityType = j.Id, CommodityTypeName = j.Type, Cost = i.Price }).Select(i => new BLL.BusinessModels.Commodity
            {
                Name = i.Name,
                Cost = i.Cost,
                Type = i.CommodityType,
                TypeName = i.CommodityTypeName,
            }).ToList();
        }
        public List<BLL.BusinessModels.Commodity> GetScarceCommodities()
        {
            return repos.Commodities.GetList().Join(repos.WarehouseLines.GetList(),i => i.Id, j => j.CommodityId, (i, j)=> new { Cost = i.Price, Name = i.Name, Quantity = j.Quantity, Type = i.CommodityType }).Where(i => i.Quantity < 4).Select(i => new BLL.BusinessModels.Commodity
            {
                Name = i.Name,
                Cost = i.Cost,
                Type = i.Type
            }).ToList();
        }
    }
}
