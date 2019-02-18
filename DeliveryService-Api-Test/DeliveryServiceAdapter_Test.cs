using DeliveryServiceApi.Adapters;
using DeliveryServiceApi.Entities;
using DeliveryServiceApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DeliveryService_Api_Test
{
    [TestClass]
    public class DeliveryServiceAdapter_Test
    {
        [TestMethod]
        public void Save()
        {
            var options = new DbContextOptionsBuilder<DeliveryContext>()
                .UseInMemoryDatabase(databaseName: "test")
                .Options;

            var obj = new DeliveryServiceModel()
            {
                BaseCost = 100,
                Distance = 30,
                Floor = 4,
                GoldRated = false,
                HasCoupen = false,
                NewCustomer = false,
                WeekendDelivery = false
            };

            using (var context = new DeliveryContext(options))
            {
                var adapter = new DeliveryServiceAdapter(context);
                var results = adapter.Save(obj);

                Assert.IsNotNull(results.id);
            }
        }
        [TestMethod]
        public void GetAll()
        {
            var options = new DbContextOptionsBuilder<DeliveryContext>()
               .UseInMemoryDatabase(databaseName: "test")
               .Options;
            using (var context = new DeliveryContext(options))
            {
                for(var i =0; i< 10; i++)
                {
                    context.DeliveryEntities.Add(new DeliveryEntity());
                }
                var adapter = new DeliveryServiceAdapter(context);;
                var results = adapter.GetAll();

                Assert.IsNotNull(results.Count == 10);
            }
        }
    }
}
