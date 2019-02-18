using System.Collections.Generic;
using DeliveryServiceApi.Adapters.InterFaces;
using DeliveryServiceApi.Helpers;
using DeliveryServiceApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace DeliveryServiceApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeliveryController : ControllerBase
    {
        private IDeliveryServiceAdapter _adapter;
        public DeliveryController(IDeliveryServiceAdapter adapter)
        {
            this._adapter = adapter;
        }

        [HttpPost]
        public DeliveryServiceModel GetOrderCost(DeliveryServiceModel deliveryServiceModel)
        {
            deliveryServiceModel.TotalCost = TotalCostCalculator.CalculateTotalCost(deliveryServiceModel);
            return this._adapter.Save(deliveryServiceModel);
        }

        [HttpGet]
        public List<DeliveryServiceModel> GetAll()
        {
            return this._adapter.GetAll();
        }
        
    }
}