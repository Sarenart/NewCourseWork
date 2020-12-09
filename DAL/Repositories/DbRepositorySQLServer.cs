using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using DAL.Context;
using DAL.Interfaces;
using DAL.Models;

namespace DAL.Repositories
{
    public class DbRepositorySQLServer:IDbRepository
    {
        private CourseWorkContext db;
        private CommodityRepositorySQL commodityRepos;
        private CommodityTypeRefRepositorySQL commodityTypeRefRepos;
        private ProviderRepositorySQL providerRepos;
        private ProviderSupplyStockRepositorySQL providerStockRepos;
        private SupplyRepositorySQL supplyRepos;
        private SupplyLineRepositorySQL supplyLineRepos;
        private SupplyStatusRefRepositorySQL supplyStatusRefRepos;
        private UsersRepositorySQL userRepos;
        private WarehouseLinesRepositorySQL warehouseLineRepos;
        private WarehouseRepositorySQL warehouseRepos;
        //Добавить репозиторий отчётов
        public DbRepositorySQLServer()
        {
            this.db = new CourseWorkContext();
        }
        public IRepository<Commodity> Commodities {
            get {
                if (commodityRepos == null)
                    commodityRepos = new CommodityRepositorySQL(this.db);
                return commodityRepos;
            }
        
        }

        public IRepository<CommodityTypeRef> CommodityRefs
        {
            get
            {
                if (commodityTypeRefRepos == null)
                    commodityTypeRefRepos = new CommodityTypeRefRepositorySQL(this.db);
                return commodityTypeRefRepos;
            }

        }
        public IRepository<Provider> Providers
        {
            get
            {
                if (providerRepos == null)
                    providerRepos = new ProviderRepositorySQL(this.db);
                return providerRepos;
            }

        }
        public IRepository<ProviderSupplyStock> ProviderStocks
        {
            get
            {
                if (providerStockRepos == null)
                    providerStockRepos = new ProviderSupplyStockRepositorySQL(this.db);
                return providerStockRepos;
            }

        }
        public IRepository<Supply> Supplies
        {
            get
            {
                if (supplyRepos == null)
                    supplyRepos = new SupplyRepositorySQL(this.db);
                return supplyRepos;
            }

        }
        public IRepository<SupplyLine> SupplyLines
        {
            get
            {
                if (supplyLineRepos == null)
                    supplyLineRepos = new SupplyLineRepositorySQL(this.db);
                return supplyLineRepos;
            }

        }

        public IRepository<SupplyStatusRef> SupplyStatusRefs
        {
            get
            {
                if (supplyStatusRefRepos == null)
                    supplyStatusRefRepos = new SupplyStatusRefRepositorySQL(this.db);
                return supplyStatusRefRepos;
            }

        }

        public IRepository<Users> Users
        {
            get
            {
                if (userRepos == null)
                    userRepos = new UsersRepositorySQL(this.db);
                return userRepos;
            }

        }

        public IRepository<Warehouse> Warehouses
        {
            get
            {
                if (warehouseRepos == null)
                    warehouseRepos = new WarehouseRepositorySQL(this.db);
                return warehouseRepos;
            }

        }

        public IRepository<WarehouseLine> WarehouseLines
        {
            get
            {
                if (warehouseLineRepos == null)
                    warehouseLineRepos = new WarehouseLinesRepositorySQL(this.db);
                return warehouseLineRepos;
            }

        }

        public int Save() {
            return this.db.SaveChanges();
        }
    }
}
