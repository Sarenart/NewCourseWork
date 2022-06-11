using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Configuration;

namespace ModularTesting
{
    public class Tests
    {
        BLL.DataOperations.DbDataOperations dataOperations;

        BLL.BusinessModels.Supply supply;

        DateTime UpdDate;

        string sss = "data source=.\\sqlexpress;initial catalog=SupplyDb;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework";

        public List<BLL.BusinessModels.SupplyLine> lines { get; set; }

        public int[] indeces;

        public int updatedDatesCount;

        [SetUp]
        public void Setup()
        {
            supply = new BLL.BusinessModels.Supply();
            lines = new List<BLL.BusinessModels.SupplyLine>();
            updatedDatesCount = new int();
            dataOperations = new BLL.DataOperations.DbDataOperations(sss);
        }

        [Test]
        public void TestMethod1()
        {
            createSupplyForTest1();
            dataOperations.CreateSupply(supply);
            supply.StatusId = 3;
            dataOperations.UpdateSupply(supply);
            Assert.NotNull(dataOperations.getLastSupply(supply));
            Assert.AreEqual(supply.StatusId, 3);
        }

        [Test]
        public void TestMethod2()
        {
            createSupplyForTests234();
            dataOperations.CreateSupply(supply);
            supply.StatusId = 4;
            dataOperations.UpdateSupply(supply);
            Assert.NotNull(dataOperations.getLastSupply(supply));
            Assert.AreEqual(supply.StatusId, 4);
        }

        [Test]
        public void TestMethod3()
        {
            createSupplyForTests234();
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
            createSupplyForTests234();
            dataOperations.CreateSupply(supply);
            supply.StatusId = 3;
            dataOperations.UpdateSupply(supply);
            supply.StatusId = 5;
            dataOperations.UpdateSupply(supply);
            Assert.NotNull(dataOperations.getLastSupply(supply));
            Assert.AreEqual(supply.StatusId, 5);
        }

        [Test]
        public void TestMethod5()
        {
            indeces = new int[0] { };
            createDataForTests567();
            dataOperations.UpdateDeliveryDate(UpdDate, indeces);
            lookupProviders(UpdDate);
            Assert.IsTrue(updatedDatesCount < 1);
        }

        [Test]
        public void TestMethod6()
        {
            indeces = new int[2] { 1, 2 };
            createDataForTests567();
            dataOperations.UpdateDeliveryDate(UpdDate, indeces);
            lookupProviders(UpdDate);
            Assert.IsTrue(updatedDatesCount < 1);
        }

        [Test]
        public void TestMethod7()
        {
            indeces = new int[3] { 1, 2, 3 };
            createDataForTests567();
            dataOperations.UpdateDeliveryDate(UpdDate, indeces);
            lookupProviders(UpdDate);  
            BLL.BusinessModels.Provider updatedProv = dataOperations.getProvider(3);
            Assert.IsTrue(updatedDatesCount > 0);
            Assert.AreEqual(updatedProv.PossibleDeliveryDate, UpdDate);
        }

        public void createSupplyForTest1()
        {
            supply.WarehouseId = 2;
            supply.StatusId = 1;
            supply.ApplicationDate = DateTime.Now;
            supply.ApplicantId = 3;
            supply.DeliveryDate = DateTime.Now;
            supply.ProviderId = 2;

            BLL.BusinessModels.SupplyLine firstLine = new BLL.BusinessModels.SupplyLine();
            firstLine.CommodityName = "Chabacco";
            firstLine.CommodityId = 7;
            firstLine.CommodityType = "Табак";
            firstLine.Quantity = 5;
            firstLine.Cost = 320;
            firstLine.SupplyId = 1;
            lines.Add(firstLine);

            BLL.BusinessModels.SupplyLine secondLine = new BLL.BusinessModels.SupplyLine();
            secondLine.CommodityName = "BlackBurn";
            secondLine.CommodityId = 8;
            secondLine.CommodityType = "Табак";
            secondLine.Quantity = 4;
            secondLine.Cost = 270;
            secondLine.SupplyId = 1;
            lines.Add(secondLine);

            BLL.BusinessModels.SupplyLine thirdLine = new BLL.BusinessModels.SupplyLine();
            thirdLine.CommodityName = "Duft";
            thirdLine.CommodityId = 10;
            thirdLine.CommodityType = "Табак";
            thirdLine.Quantity = 1;
            thirdLine.Cost = 380;
            thirdLine.SupplyId = 1;
            lines.Add(thirdLine);

            supply.Lines = lines;
            foreach (BLL.BusinessModels.SupplyLine innerLine in lines)
            {
                supply.Cost += innerLine.Cost * innerLine.Quantity;
            }
        }

        public void createSupplyForTests234()
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

        public void createDataForTests567()
        {
            UpdDate = new DateTime(2021, 12, 24);
        }
        public void lookupProviders(DateTime date)
        {
            updatedDatesCount = 0;
            List<BLL.BusinessModels.Provider> Providers = dataOperations.getProviders();
            foreach(BLL.BusinessModels.Provider prov in Providers)
            {
                if (prov.PossibleDeliveryDate == date)
                    updatedDatesCount++;
            }
        }
    }
}