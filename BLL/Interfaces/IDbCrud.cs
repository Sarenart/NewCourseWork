using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.BusinessModels;

namespace BLL.Interfaces
{
    public interface IDbCrud
    {
        List<Supply> GetSupplies();
        //List<OrderModel>
        void CreateSupply();
        void ArrangeSupply();
        List<Commodity> GetCommodities();

        Supply GetSupply();
        List<Provider> GetProviders();

        List<User> GetUsers();

        List<Warehouse> GetWarehouses();
    }
}
