using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.BusinessModels
{
    public class WarehouseLine
    {
        private int id { get; set; }
        private int commodityid { get; set; }

        public int Id { 
            get 
            {
                return id;
            } set 
            {
                id = value;
            } 
        }

        public int CommodityId {
            get
            {
                return commodityid;
            }
            set
            {
                commodityid = value;
            }
        }


    }
}
