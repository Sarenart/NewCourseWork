using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace BLL.BusinessModels
{
    public class SupplyReportByPeriodModel 
    {
        /*private string provider;

        private decimal cost;

        private string warehouse;

        private DateTime date;*/

        public string Provider { get; set; }

        public decimal Cost { get; set; }

        public DateTime Date { get; set; }

        public string Warehouse { get; set; }
        public int StatusId { get; set; }

        public string Status { get; set; }
    }


    public class SupplyReportByWarehouseModel
    {
        //private string provider;

        //private decimal cost;

        //private DateTime date;

        public string Provider { get; set; }

        public decimal Cost { get; set; }

        public DateTime Date { get; set; }
        public int StatusId { get; set; }
        public string Status { get; set; }


    }
}
