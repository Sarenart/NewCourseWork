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

        public List<BLL.BusinessModels.Commodity> getWarehouseCommodities(int WHId) {
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

        public List<BLL.BusinessModels.Commodity> getScarceWarehouseCommodities(int WHId)
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

        public List<BLL.BusinessModels.Warehouse> getWarehouses() {
            return repos.Warehouses.GetList().Select(i=> new BusinessModels.Warehouse { Address = i.Address, Id = i.Id}).ToList();
        }

        public List<BLL.BusinessModels.Supply> getAllSupplies(int WHId)
        {
            return repos.Supplies.GetList().Join(repos.SupplyStatusRefs.GetList(), i=>i.Status, j=>j.Id, (i, j) => new { WarehouseId = i.WarehouseId, Cost = i.Cost, Date = i.Date, Id = i.Id, Status = i.Status, StatusString = j.Status})
            .Join(repos.Warehouses.GetList(), i=>i.WarehouseId, j=>j.Id, (i, j)=> new { WarehouseId = i.WarehouseId, Cost = i.Cost, Date = i.Date, Id = i.Id, Status = i.Status, StatusString = i.StatusString })
            .Where(i => i.WarehouseId == WHId)
            .Select(i=>new BLL.BusinessModels.Supply 
            { 
                Cost = i.Cost,
                Date = i.Date, Id = i.Id, 
                Status = i.Status, 
                StatusString = i.StatusString,
                WarehouseId = i.WarehouseId
            }).ToList();
        }

        public List<BLL.BusinessModels.Supply> getRecentSupplies(int WHId)
        {
            return repos.Supplies.GetList()
            .Join(repos.SupplyStatusRefs.GetList(), i => i.Status, j => j.Id, (i, j) => new { WarehouseId = i.WarehouseId, Cost = i.Cost, Date = i.Date, Id = i.Id, Status = i.Status, StatusString = j.Status })
            .Join(repos.Warehouses.GetList(), i => i.WarehouseId, j => j.Id, (i, j) => new { WarehouseId = i.WarehouseId, Cost = i.Cost, Date = i.Date, Id = i.Id, Status = i.Status, StatusString = i.StatusString })
            .Where(i=>i.Date > DateTime.Now.AddDays(-20))
            .Where(i=>i.WarehouseId == WHId)
            .Select(i => new BLL.BusinessModels.Supply 
            { 
                Cost = i.Cost, 
                Date = i.Date, 
                Id = i.Id, 
                Status = i.Status, 
                StatusString = i.StatusString 
            }).ToList();
        }

        public List<NotificationModel> getNotifications()
        {
            List<NotificationModel> Notes = repos.WarehouseLines.GetList()
                .Join(repos.Commodities.GetList(), i => i.CommodityId, j => j.Id, (i, j) => new { Quantity = i.Quantity, Name = j.Name })
                .Where(i => i.Quantity < 10).Select(i => new NotificationModel
                {
                    NotificationType = 1,
                    Message = "Товар " + i.Name + " заканчивается на складе: осталось "+ i.Quantity + " единиц продукции.",
                }).ToList();
            return Notes;
        }

        public List<BusinessModels.Provider> getProviders() {
            return repos.Providers.GetList().Select(i => new BusinessModels.Provider()
            {
                CompanyName = i.CompanyName,
                FamilyName = i.FamilyName,
                Id = i.Id,
                Initials = i.Initials,
                FullName = i.FamilyName + " " + i.Initials,
            }).ToList();
        }

        public List<BusinessModels.ProviderSupplyStock> getProviderSupplyStock(int Id)
        {
            return repos.ProviderStocks.GetList()
            .Where(i => i.ProviderId == Id)
            .Select(i => new BusinessModels.ProviderSupplyStock() 
            { 
                CommodityId = i.CommodityId, 
                CommodityName = i.Commodity.Name, 
                CommodityType = i.Commodity.CommodityTypeRef.Type, 
                ProviderId = i.ProviderId, 
                Cost = i.Cost,Id=i.Id 
            }).ToList();
        }

        /*public List<BusinessModels.SupplyLine> getSupplyLine() { 
            return repos.SupplyLines.GetList()
            .Where
        }*/

        public void CreateSupply(List<BusinessModels.SupplyLine> Lines) {
            decimal Cost = 0;
            List<DAL.SupplyLine> NewLines = new List<DAL.SupplyLine>();
            foreach (BusinessModels.SupplyLine i in Lines)
            {
                NewLines.Add(new DAL.SupplyLine() { CommodityId = i.CommodityId, Quantity = i.Quantity, Cost = i.Cost });
                Cost += i.Cost;
            }
            DAL.Supply sup = new DAL.Supply() { Cost = Cost, ApplicantId = 2, ArrangerId = 2, Date = DateTime.Now, SupplierId = 1, WarehouseId = 1, Status = 2, SupplyLine = NewLines };
            repos.Supplies.Create(sup);
            repos.Save();
        }

        public List<BusinessModels.SupplyLine> RecordSupplyLines(List<BusinessModels.SupplyLine> CurList, BusinessModels.SupplyLine line)
        {
            List<BusinessModels.SupplyLine> NewList = new List<BusinessModels.SupplyLine>();
            foreach(BusinessModels.SupplyLine i in CurList)
            {
                NewList.Add(i);
            }
            NewList.Add(line);
            return NewList;
           // return repos.SupplyLines.GetList().Select(i => new BusinessModels.SupplyLine {Cost = i.Cost, CommodityName = i.Commodity.Name, CommodityId = i.CommodityId, CommodityType = i.Commodity.CommodityTypeRef.Type, Quantity = i.Quantity }).ToList();
        }

        public List<BusinessModels.SupplyLine> RemoveSupplyLines(List<BusinessModels.SupplyLine> CurList, BusinessModels.SupplyLine line)
        {
            List<BusinessModels.SupplyLine> NewList = new List<BusinessModels.SupplyLine>();
            foreach (BusinessModels.SupplyLine i in CurList)
            {
                NewList.Add(i);
            }
            NewList.Remove(line);
            return NewList;
            // return repos.SupplyLines.GetList().Select(i => new BusinessModels.SupplyLine {Cost = i.Cost, CommodityName = i.Commodity.Name, CommodityId = i.CommodityId, CommodityType = i.Commodity.CommodityTypeRef.Type, Quantity = i.Quantity }).ToList();
        }
    }
}
