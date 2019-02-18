using DeliveryServiceApi.Adapters.InterFaces;
using DeliveryServiceApi.Controllers;
using DeliveryServiceApi.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;

namespace DeliveryServiceApiTest
{
    [TestClass]
    public class DeliveryController_Test
    {
        private readonly Mock<IDeliveryServiceAdapter> deliveryServiceAdapter = new Mock<IDeliveryServiceAdapter>();

        [TestMethod]
        public void GetOrderCost()
        {
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
            var returnObj = new DeliveryServiceModel()
            {
                BaseCost = 100,
                Distance = 30,
                Floor = 4,
                GoldRated = false,
                HasCoupen = false,
                NewCustomer = false,
                WeekendDelivery = false,
                id = 1,
                TotalCost = 125
            };
            this.deliveryServiceAdapter.Setup(x => x.Save(It.IsAny<DeliveryServiceModel>())).Returns(returnObj);

            var controller = new DeliveryController(deliveryServiceAdapter.Object);
            var output = controller.GetOrderCost(obj);

            this.deliveryServiceAdapter.VerifyAll();
            Assert.IsNotNull(output);
            Assert.IsTrue(output.Equals(returnObj));
        }
        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void GetOrderCost_NullObject()
        {
            
            var returnObj = new DeliveryServiceModel()
            {
                BaseCost = 100,
                Distance = 30,
                Floor = 4,
                GoldRated = false,
                HasCoupen = false,
                NewCustomer = false,
                WeekendDelivery = false,
                id = 1,
                TotalCost = 200
            };
            this.deliveryServiceAdapter.Setup(x => x.Save(It.IsAny<DeliveryServiceModel>())).Returns(returnObj);

            var controller = new DeliveryController(deliveryServiceAdapter.Object);
            var output = controller.GetOrderCost(null);

        }

        [TestMethod]
        public void GetAll()
        {
            var returnObj = new List<DeliveryServiceModel>()
            {
                new DeliveryServiceModel(),
                new DeliveryServiceModel()
            };

            this.deliveryServiceAdapter.Setup(x => x.GetAll()).Returns(returnObj);
            var controller = new DeliveryController(deliveryServiceAdapter.Object);
            var output = controller.GetAll();
            deliveryServiceAdapter.VerifyAll();
            Assert.IsTrue(output.Count == 2);
        }
    }
}
