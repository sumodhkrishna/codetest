using DeliveryServiceApi.Adapters.InterFaces;
using DeliveryServiceApi.Entities;
using DeliveryServiceApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeliveryServiceApi.Adapters
{
    public class DeliveryServiceAdapter : IDeliveryServiceAdapter
    {
        DeliveryContext _context;
        public DeliveryServiceAdapter(DeliveryContext context)
        {
            _context = context;
        }
        public List<DeliveryServiceModel> GetAll()
        {
            return this._context.DeliveryEntities.ToList().Select(e => new DeliveryServiceModel(e)).ToList();
        }

        public DeliveryServiceModel Save(DeliveryServiceModel deliveryServiceModel)
        {
            var entity = new DeliveryEntity();
            entity.BaseCost = deliveryServiceModel.BaseCost;
            entity.Distance = deliveryServiceModel.Distance;
            entity.Floor = deliveryServiceModel.Floor;
            entity.WeekendDelivery = deliveryServiceModel.WeekendDelivery;
            entity.GoldRated = deliveryServiceModel.GoldRated;
            entity.HasCoupen = deliveryServiceModel.HasCoupen;
            entity.TotalCost = deliveryServiceModel.TotalCost;

            this._context.DeliveryEntities.Add(entity);
            this._context.SaveChanges();
            return new DeliveryServiceModel(entity);
        }
    }
}
