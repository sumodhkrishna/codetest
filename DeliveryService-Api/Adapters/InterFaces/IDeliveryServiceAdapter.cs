using DeliveryServiceApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeliveryServiceApi.Adapters.InterFaces
{
    public interface IDeliveryServiceAdapter
    {
        List<DeliveryServiceModel> GetAll();
        DeliveryServiceModel Save(DeliveryServiceModel deliveryServiceModel);
    }
}
