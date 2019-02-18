using Autofac;
using Autofac.Core;
using DeliveryServiceApi.Adapters;
using DeliveryServiceApi.Adapters.InterFaces;
using DeliveryServiceApi.Entities;

namespace DeliveryService_Api
{
    public class AutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register((c, p) => new DeliveryServiceAdapter(c.Resolve<DeliveryContext>())).As<IDeliveryServiceAdapter>().InstancePerLifetimeScope();
            base.Load(builder);
        }
    }
}