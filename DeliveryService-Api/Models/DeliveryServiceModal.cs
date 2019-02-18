using DeliveryServiceApi.Entities;

namespace DeliveryServiceApi.Models
{
    public class DeliveryServiceModel
    {
        public DeliveryServiceModel()
        {

        }

        public DeliveryServiceModel(DeliveryEntity entity)
        {
            this.id = entity.id;
            this.BaseCost = entity.BaseCost;
            this.Distance = entity.Distance;
            this.Floor = entity.Floor;
            this.WeekendDelivery = entity.WeekendDelivery;
            this.GoldRated = entity.GoldRated;
            this.HasCoupen = entity.HasCoupen;
            this.TotalCost = entity.TotalCost;
            this.NewCustomer = entity.NewCustomer;
        }

        public long id { get; set; }
        public double BaseCost { get; set; }
        public double Distance { get; set; }
        public int Floor { get; set; }
        public bool WeekendDelivery { get; set; }
        public bool GoldRated { get; set; }
        public bool HasCoupen { get; set; }
        public double TotalCost { get; set; }
        public bool NewCustomer { get; set; }
    }
}
