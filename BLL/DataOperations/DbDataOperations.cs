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

        public List<BLL.BusinessModels.Commodity> GetWarehouseCommodities(int WHId) {
            return repos.Commodities.GetList().
                Join(repos.CommodityRefs.GetList(), i => i.CommodityType, j => j.Id, (i, j) => new { Id = i.Id, Name = i.Name, TypeId = j.Id, TypeName = j.Type }).
                Join(repos.WarehouseLines.GetList(), i => i.Id, j => j.CommodityId, (i, j) => new { Id = i.Id, Name = i.Name, TypeName = i.TypeName, TypeId = i.TypeId, WarehouseId = j.WarehouseId, Cost = j.PerUnitCost, Quantity = j.Quantity }).
                //Join(repos.Warehouses.GetList(), i=>i.WarehouseId, j => j.Id, (i , j) => new { Id = i.Id, Name = i.Name, Type = i.Type, WarehouseId = i.WarehouseId }).
                Select(i => new
                {
                    Name = i.Name,
                    Cost = i.Cost,
                    Quantity = i.Quantity,
                    Type = i.TypeId,
                    TypeName = i.TypeName,
                    WarehouseId = i.WarehouseId
                }).
                Where(i => i.WarehouseId == WHId).
                Select(i => new BusinessModels.Commodity {
                    Name = i.Name,
                    Type =i.Type,
                    Cost = i.Cost,
                    TypeName = i.TypeName,
                    Quantity=i.Quantity
                }).
                ToList();
        }

        public List<BLL.BusinessModels.Commodity> GetScarceWarehouseCommodities(int WHId)
        {
            return repos.Commodities.GetList().
                Join(repos.CommodityRefs.GetList(), i => i.CommodityType, j => j.Id, (i, j) => new { Id = i.Id, Name = i.Name, TypeId = j.Id, TypeName = j.Type }).
                Join(repos.WarehouseLines.GetList(), i => i.Id, j => j.CommodityId, (i, j) => new { Id = i.Id, Name = i.Name, TypeName = i.TypeName, TypeId = i.TypeId, WarehouseId = j.WarehouseId, Cost = j.PerUnitCost, Quantity = j.Quantity }).
                //Join(repos.Warehouses.GetList(), i=>i.WarehouseId, j => j.Id, (i , j) => new { Id = i.Id, Name = i.Name, Type = i.Type, WarehouseId = i.WarehouseId }).
                Select(i => new
                {
                    Name = i.Name,
                    Cost = i.Cost,
                    Quantity = i.Quantity,
                    Type = i.TypeId,
                    TypeName = i.TypeName,
                    WarehouseId = i.WarehouseId
                }).
                Where(i => i.WarehouseId == WHId).
                Where(i =>i.Quantity < 10).
                Select(i => new BusinessModels.Commodity
                {
                    Name = i.Name,
                    Type = i.Type,
                    Cost = i.Cost,
                    TypeName = i.TypeName,
                    Quantity = i.Quantity
                }).
                ToList();
        }

        public List<BLL.BusinessModels.Warehouse> GetWarehouses() {
            return repos.Warehouses.GetList().Select(i=> new BusinessModels.Warehouse { Address = i.Address, Id = i.Id}).ToList();
        }
        /*public List<BLL.BusinessModels.Commodity> GetCommodities()
        {
            return repos.Commodities.GetList().Join(repos.CommodityRefs.GetList(), i => i.CommodityType, j => j.Id, (i, j) => new { Name = i.Name, CommodityType = j.Id, CommodityTypeName = j.Type, Cost = i.Price }).Join(repos.)       .Select(i => new BLL.BusinessModels.Commodity
            {
                Name = i.Name,
                Cost = i.Cost,
                Type = i.CommodityType,
                TypeName = i.CommodityTypeName,
            }).ToList();
        }*/
        /*public List<BLL.BusinessModels.Commodity> GetScarceCommodities()
        {
            return repos.Commodities.GetList().Join(repos.WarehouseLines.GetList(),i => i.Id, j => j.CommodityId, (i, j)=> new { Cost = i.Price, Name = i.Name, Quantity = j.Quantity, Type = i.CommodityType }).Where(i => i.Quantity < 4).Select(i => new BLL.BusinessModels.Commodity
            {
                Name = i.Name,
                Cost = i.Cost,
                Type = i.Type
            }).ToList();
        }*/
    }
}
