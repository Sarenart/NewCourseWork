using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Models;

namespace DAL.Interfaces
{
    public interface IDbRepository
    {
        IRepository<Commodity> Commodities {get;}
        IRepository<CommodityTypeRef> CommodityRefs {get;}
        IRepository<Provider> Providers {get;}
        IRepository<ProviderSupplyStock> ProviderStocks{get;}
        IRepository<Supply> Supplies {get;}
        IRepository<SupplyLine> SupplyLines {get;}
        IRepository<SupplyStatusRef> SupplyStatusRefs { get; }
        IRepository<Users> Users {get;}
        IRepository<Warehouse> Warehouses {get;}
        IRepository<WarehouseLine> WarehouseLines {get;}

        int Save();
    }
}
