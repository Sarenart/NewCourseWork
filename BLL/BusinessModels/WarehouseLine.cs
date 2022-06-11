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
       
        private int warehouseid { get; set; }

        private int quantity { get; set; }

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

        public int WarehouseId
        {
            get
            {
                return warehouseid;
            }
            set
            {
                warehouseid = value;
            }
        }

        public int Quantity
        {
            get
            {
                return quantity;
            }
            set
            {
                quantity = value;
            }
        }

    }
}
