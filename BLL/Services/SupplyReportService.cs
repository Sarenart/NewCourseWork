using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.BusinessModels;
using DAL.Repositories;

namespace BLL.Services
{
    public class SupplyReportService
    {
        DbRepositorySQLServer db;

        public SupplyReportService()
        {
            db = new DbRepositorySQLServer(); 
        }

        public List<SupplyReportByPeriodModel> getReportByPeriod(DateTime Start, DateTime Finish)
        {
            List<SupplyReportByPeriodModel> Report1 = db.Supplies.GetList().Where(i=>i.ApplicationDate >= Start && i.ApplicationDate <= Finish).Select(i => new SupplyReportByPeriodModel()
            {
                Provider = i.Provider.CompanyName,
                Date = i.ApplicationDate,
                Cost = i.Cost,
                Warehouse = i.Warehouse.Address,
                StatusId = i.StatusId
            }).ToList();
            foreach (BusinessModels.SupplyReportByPeriodModel item in Report1)
            {
                item.Status = db.SupplyStatusRefs.GetItem(item.StatusId).Status;
            }
            return Report1;
        }

        public List<SupplyReportByWarehouseModel> getReportByWarehouse(int warehouseid)
        {
            List<SupplyReportByWarehouseModel> Report1 = db.Supplies.GetList().Where(i => i.ApplicationDate.Month == DateTime.Now.Month && i.WarehouseId == warehouseid).Select(i => new SupplyReportByWarehouseModel()
            {
                Provider = i.Provider.CompanyName,
                Date = i.ApplicationDate,
                Cost = i.Cost,
                StatusId = i.StatusId
            }).ToList();
            foreach (BusinessModels.SupplyReportByWarehouseModel item in Report1)
            {
                item.Status = db.SupplyStatusRefs.GetItem(item.StatusId).Status;
            }
            return Report1;
        }
    }
}
