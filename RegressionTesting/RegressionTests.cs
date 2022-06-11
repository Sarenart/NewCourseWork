using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Configuration;

namespace RegressionTesting
{
    [TestFixture]
    public class Tests
    {
        BLL.DataOperations.DbDataOperations dataOperations;

        BLL.BusinessModels.Supply supply;

        string sss = "data source=.\\sqlexpress;initial catalog=SupplyDb;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework";

        public List<BLL.BusinessModels.SupplyLine> lines { get; set; }

        [SetUp]
        public void Setup()
        {
            supply = new BLL.BusinessModels.Supply();
            lines = new List<BLL.BusinessModels.SupplyLine>();
            dataOperations = new BLL.DataOperations.DbDataOperations(sss);
        }

        [Test]
        public void TestMethod3()
        {
            createSupplyForTests();
            dataOperations.CreateSupply(supply);
            supply.StatusId = 3;
            dataOperations.UpdateSupply(supply);
            supply.StatusId = 2;
            dataOperations.UpdateSupply(supply);
            Assert.NotNull(dataOperations.getLastSupply(supply));
            Assert.AreEqual(supply.StatusId, 2);
        }

        [Test]
        public void TestMethod4()
        {
            createSupplyForTests();
            dataOperations.CreateSupply(supply);
            supply.StatusId = 3;
            dataOperations.UpdateSupply(supply);
            supply.StatusId = 5;
            dataOperations.UpdateSupply(supply);
            Assert.NotNull(dataOperations.getLastSupply(supply));
            Assert.AreEqual(supply.StatusId, 5);
        }
        public void createSupplyForTests()
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