using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeliveryServiceApi.Entities
{
    public class DeliveryContext : DbContext
    {
        public DeliveryContext(DbContextOptions<DeliveryContext> options):base (options)
        {

        }

        public DbSet<DeliveryEntity> DeliveryEntities {get;set;}
        
    }

    public class DeliveryEntity
    {
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
