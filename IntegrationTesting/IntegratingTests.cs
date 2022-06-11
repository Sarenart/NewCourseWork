using NUnit.Framework;
using System.Collections.Generic;
using Moq;
using System;
using System.IO;
using System.Configuration;
using System.Linq;

namespace IntegrationTesting
{
    public class Tests
    {
        BLL.DataOperations.DbDataOperations dataOperations;

        DAL.Provider oldDateProvider;

        BLL.BusinessModels.Provider newDateProvider;

        BLL.BusinessModels.Supply supply;

        string sss = "data source=.\\sqlexpress;initial catalog=SupplyDb;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework";

        public List<BLL.BusinessModels.SupplyLine> lines { get; set; }

        [SetUp]
        public void Setup()
        {
            supply = new BLL.BusinessModels.Supply();
            lines = new List<BLL.BusinessModels.SupplyLine>();
            oldDateProvider = new DAL.Provider();
            newDateProvider = new BLL.BusinessModels.Provider();
        }

        [Test]
        public void Test1()
        {
            setProvidersForTests();
            var mock = new Mock<DAL.Interfaces.IDbRepository>();
            mock.Setup(r=>r.Providers.GetItem(1)).Returns(oldDateProvider);

            mock.Setup(r => r.Save()).Returns(1);
            mock.Setup(r => r.Providers.Update(It.IsAny<DAL.Provider>()));


            dataOperations = new BLL.DataOperations.DbDataOperations(mock.Object);
            
            dataOperations.UpdateDeliveryDate(newDateProvider);
            mock.Verify(dbop => dbop.Providers.Update(It.IsAny<DAL.Provider>()));
            mock.Verify(dbop => dbop.Save());
            Assert.That(oldDateProvider.PossibleDeliveryDate == newDateProvider.PossibleDeliveryDate);
        }

        [Test]
        public void Test2()
        {
            dataOperations = new BLL.DataOperations.DbDataOperations(sss);
            createSupplyForTests23();
            dataOperations.CreateSupply(supply);
            supply.StatusId = 2;
            dataOperations.UpdateSupply(supply);
            //BLL.BusinessModels.Warehouse wh = dataOperations.getWarehouse(supply.WarehouseId);
            BLL.BusinessModels.WarehouseLine targetLine = dataOperations.getWarehouseLines(supply.WarehouseId)
                .Where(i => i.CommodityId == supply.Lines[0].CommodityId).FirstOrDefault();
            Assert.NotNull(targetLine);
            Assert.AreEqual(targetLine.CommodityId, supply.Lines[0].CommodityId);
            Assert.AreEqual(targetLine.WarehouseId, supply.WarehouseId);
            Assert.AreEqual(targetLine.Quantity, supply.Lines[0].Quantity);
        }

        [Test]
        public void Test3()
        {
            dataOperations = new BLL.DataOperations.DbDataOperations(sss);
            createSupplyForTests23();
            dataOperations.CreateSupply(supply);
            supply.StatusId = 2;
            dataOperations.UpdateSupply(supply);
            BLL.BusinessModels.WarehouseLine targetLine = dataOperations.getWarehouseLines(supply.WarehouseId)
                .Where(i => i.CommodityId == supply.Lines[0].CommodityId).FirstOrDefault();
            Assert.NotNull(targetLine);
            Assert.AreEqual(targetLine.CommodityId, supply.Lines[0].CommodityId);
            Assert.AreEqual(targetLine.WarehouseId, supply.WarehouseId);
            Assert.IsTrue(targetLine.Quantity > supply.Lines[0].Quantity);
        }

        private void setProvidersForTests()
        {
            oldDateProvider.CompanyName = "Taiga Logistics";
            oldDateProvider.Id = 1;
            oldDateProvider.PossibleDeliveryDate = new System.DateTime(2008, 5, 12, 5, 2, 33);

            newDateProvider.CompanyName = "Taiga Logistics";
            newDateProvider.Id = 1;
            newDateProvider.PossibleDeliveryDate = new System.DateTime(2014, 6, 28, 3, 7, 23);
        }

        public void createSupplyForTests23()
        {
            supply.WarehouseId = 2;
            supply.StatusId = 1;
            supply.ApplicationDate = DateTime.Now;
            supply.ApplicantId = 3;
            supply.DeliveryDate = DateTime.Now;
            supply.ProviderId = 2;

            BLL.BusinessModels.SupplyLine firstLine = new BLL.BusinessModels.SupplyLine();
            firstLine.CommodityName = "SarkoZy";
            firstLine.CommodityId = 25;
            firstLine.CommodityType = "Табак";
            firstLine.Quantity = 5;
            firstLine.Cost = 500;
            firstLine.SupplyId = 1;
            lines.Add(firstLine);

            supply.Lines = lines;
            foreach (BLL.BusinessModels.SupplyLine innerLine in lines)
            {
                supply.Cost += innerLine.Cost * innerLine.Quantity;
            }
        }
    }
}