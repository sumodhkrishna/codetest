using DeliveryServiceApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeliveryServiceApi.Helpers
{
    public static class TotalCostCalculator
    {
        public static double CalculateTotalCost(DeliveryServiceModel deliveryServiceModel)
        {
            var totalCost = 0.0;
            if (deliveryServiceModel.HasCoupen)
            {
                totalCost = deliveryServiceModel.BaseCost - (deliveryServiceModel.BaseCost * .2);
            }
            else if (deliveryServiceModel.GoldRated)
            {
                totalCost = deliveryServiceModel.BaseCost - (deliveryServiceModel.BaseCost * .1);
            }
            else if (deliveryServiceModel.NewCustomer)
            {
                totalCost = deliveryServiceModel.BaseCost - (deliveryServiceModel.BaseCost * .15);
            }
            else if (deliveryServiceModel.WeekendDelivery)
            {
                totalCost = deliveryServiceModel.BaseCost + (deliveryServiceModel.BaseCost * .5);
            }
            else if (deliveryServiceModel.Distance <= 10) // Not clarified in requirements what happens if the distance is 10km, assuming the 10 km also falls under less than 10
            {
                totalCost = deliveryServiceModel.BaseCost + (deliveryServiceModel.BaseCost * .1);
                CalculateFloorCost(deliveryServiceModel.BaseCost, deliveryServiceModel.Floor, totalCost); // Assuming the floor cost is only applicable to normal customers
            }
            else if (deliveryServiceModel.Distance <= 50) // Assuming the same explained above
            {
                totalCost = deliveryServiceModel.BaseCost + (deliveryServiceModel.BaseCost * .25);
                CalculateFloorCost(deliveryServiceModel.BaseCost, deliveryServiceModel.Floor, totalCost);
            }
            else
            {
                totalCost = deliveryServiceModel.BaseCost + (deliveryServiceModel.Distance * .25);
                CalculateFloorCost(deliveryServiceModel.BaseCost, deliveryServiceModel.Floor, totalCost);
            }
            return totalCost;

        }

        private static void CalculateFloorCost(double baseCost, int floor, double totalCost)
        {
            if (floor > 1 && floor <= 5)
            {
                totalCost += baseCost * .05;
            }
            else
            {
                totalCost += (baseCost * .05) + ((floor - 5) * 2);
            }
        }
    }
}
