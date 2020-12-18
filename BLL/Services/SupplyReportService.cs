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

        public List<SupplyReportModel> getReport1()
        {
            List<SupplyReportModel> Report1 = db.Supplies.GetList().Select(i => new SupplyReportModel()
            {
                Provider = i.Provider.FamilyName + " "+ i.Provider.Initials,
                Date = i.Date,
                Cost = i.Cost
            }).ToList();
            return Report1;
        }
    }
}
