using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace BLL.BusinessModels
{
    public class SupplyReportModel 
    {
        private string provider;

        private decimal cost;

        private DateTime date;

        public string Provider { get; set; }

        public decimal Cost { get; set; }

        public DateTime Date { get; set; }
    }
}
