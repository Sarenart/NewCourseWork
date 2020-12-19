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
            return repos.Supplies.GetList().Join(repos.SupplyStatusRefs.GetList(), i=>i.StatusId, j=>j.Id, (i, j) => new { WarehouseId = i.WarehouseId, Cost = i.Cost, ApplicationDate = i.ApplicationDate, ArrangementDate = i.ArrangementDate, DeliveryDate = i.DeliveryDate, Id = i.Id, StatusId = i.StatusId, Status = j.Status})
            //.Join(repos.Warehouses.GetList(), i=>i.WarehouseId, j=>j.Id, (i, j)=> new { WarehouseId = i.WarehouseId, Cost = i.Cost, Date = i.Date, Id = i.Id, Status = i.Status, StatusString = i.StatusString })
            .Where(i => i.WarehouseId == WHId)
            .Select(i=>new BLL.BusinessModels.Supply 
            { 
                Cost = i.Cost,
                ArrangementDate = i.ArrangementDate, 
                DeliveryDate = i.DeliveryDate,
                ApplicationDate = i.ApplicationDate,
                Id = i.Id, 
                StatusId = i.StatusId, 
                Status = i.Status,
                WarehouseId = i.WarehouseId
            }).ToList();
        }

        public List<BLL.BusinessModels.User> getUsers()
        {
            return repos.Users.GetList().Select(i => new BusinessModels.User
            {
                Id = i.Id,
                FamName = i.FamName,
                FirName = i.FirName,
                Login = i.Login,
                Password = i.Password
            }).ToList();
        }
        public List<BLL.BusinessModels.Supply> getRecentSupplies(int WHId)
        {
            return repos.Supplies.GetList()
            .Join(repos.SupplyStatusRefs.GetList(), i => i.StatusId, j => j.Id, (i, j) => new { WarehouseId = i.WarehouseId, Cost = i.Cost, ApplicationDate = i.ApplicationDate, ArrangementDate = i.ArrangementDate, DeliveryDate = i.DeliveryDate, Id = i.Id, StatusId = i.StatusId, Status = j.Status })
            //.Join(repos.Warehouses.GetList(), i => i.WarehouseId, j => j.Id, (i, j) => new { WarehouseId = i.WarehouseId, Cost = i.Cost, Date = i.Date, Id = i.Id, Status = i.Status, StatusString = i.StatusString })
            .Where(i=>i.StatusId!=2 && i.StatusId !=4 && i.StatusId != 5)
            .Where(i=>i.WarehouseId == WHId)
            .Select(i => new BLL.BusinessModels.Supply 
            {
                Cost = i.Cost,
                ArrangementDate = i.ArrangementDate,
                DeliveryDate = i.DeliveryDate,
                ApplicationDate = i.ApplicationDate,
                Id = i.Id,
                StatusId = i.StatusId,
                Status = i.Status,
                WarehouseId = i.WarehouseId
            }).ToList();
        }

        public List<NotificationModel> getNotifications()
        {
            List<NotificationModel> Notes = repos.WarehouseLines.GetList()
                .Join(repos.Commodities.GetList(), i => i.CommodityId, j => j.Id, (i, j) => new {Type = j.CommodityTypeRef.Type, Quantity = i.Quantity, Name = j.Name, Warehouse = i.Warehouse.Address })
                .Where(i => i.Quantity < 10).Select(i => new NotificationModel
                {
                    NotificationType = 1,
                    Message = i.Type + " Бренда " + i.Name + " заканчивается на складе по адресу "+ i.Warehouse + ": осталось "+ i.Quantity + " единиц продукции.",
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
                PossibleDeliveryDate = i.PossibleDeliveryDate,
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

        public void CreateSupply(List<BusinessModels.SupplyLine> Lines, int WarehouseId, int ProviderId, int UserId, DateTime DeliveryDate) {
            decimal Cost = 0;
            List<DAL.SupplyLine> NewLines = new List<DAL.SupplyLine>();
            foreach (BusinessModels.SupplyLine i in Lines)
            {
                NewLines.Add(new DAL.SupplyLine() { CommodityId = i.CommodityId, Quantity = i.Quantity, Cost = i.Cost });
                Cost += i.Cost;
            }
            DAL.Supply sup = new DAL.Supply() { Cost = Cost, ApplicantId = UserId,  ApplicationDate = DateTime.Now, DeliveryDate = DeliveryDate, ProviderId = ProviderId, WarehouseId = WarehouseId, StatusId = 1, SupplyLine = NewLines };
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
        public List<BusinessModels.SupplyLine> ReturnSupplyLines(int Id)
        {
            return repos.SupplyLines.GetList().Where(i => i.SupplyId == Id).Select(i => new BusinessModels.SupplyLine
            {
                Id = i.Id,
                SupplyId = i.SupplyId,
                CommodityId = i.CommodityId,
                CommodityName = i.Commodity.Name,
                CommodityType = i.Commodity.CommodityTypeRef.Type,
                Quantity = i.Quantity,
                Cost = i.Cost,
            }).ToList();
        }

        public void ArrangeSupply(BusinessModels.Supply Sup, List<BusinessModels.SupplyLine> lines, BusinessModels.User CurUser) {
            List<BusinessModels.WarehouseLine> warehouselines = repos.WarehouseLines.GetList().Where(i=>i.WarehouseId == Sup.WarehouseId).Select(i=> new BusinessModels.WarehouseLine { Id = i.Id, CommodityId = i.CommodityId}).ToList();
            foreach (BusinessModels.SupplyLine item in lines) 
            {
                bool check = false;
                foreach (BusinessModels.WarehouseLine wareline in warehouselines)
                {
                    if (item.CommodityId == wareline.CommodityId)
                    {
                        DAL.WarehouseLine UpdatedLine = repos.WarehouseLines.GetItem(wareline.Id);
                        UpdatedLine.Quantity += item.Quantity;
                        repos.WarehouseLines.Update(UpdatedLine);
                        check = true;
                    }
                }
                if (!check)
                {
                    DAL.WarehouseLine NewLine = new DAL.WarehouseLine();
                    NewLine.Quantity = item.Quantity;
                    NewLine.WarehouseId = Sup.WarehouseId;
                    NewLine.CommodityId = item.CommodityId;
                    NewLine.PerUnitCost = 0;
                    repos.WarehouseLines.Create(NewLine);
                }
            }
            DAL.Supply UpdatedSupply = repos.Supplies.GetItem(Sup.Id);
            UpdatedSupply.ArrangerId = CurUser.Id;
            UpdatedSupply.ArrangementDate = DateTime.Now;
            UpdatedSupply.StatusId = 2;
            repos.Supplies.Update(UpdatedSupply);
            repos.Save();
        }

    }
}
