using Autofac;
using OnlineAlisveris.Web.Services;
using OnlineAlisveris.Web.Services.Contracts;

namespace OnlineAlisveris.Web.Autofac;

public class AutofacWebModule: Module
{
   protected override void Load(ContainerBuilder builder)
   {
      builder.RegisterType<IProductService>().As<ProductService>();
   }
}