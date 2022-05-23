using System.Reflection;
using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstract;
using Business.Concrete;
using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Module = Autofac.Module;

namespace Business.DependecyResolvers;

public class AutofacBusinessModule: Module
{
    protected override void Load(ContainerBuilder builder)
    {
        //Product
        builder.RegisterType<ProductManager>().As<IProductService>();
        builder.RegisterType<EfProductDal>().As<IProductDal>();
        //ProductCategory
        builder.RegisterType<ProductCategoryManager>().As<IProductCategoryService>();
        builder.RegisterType<EfProductCategoryDal>().As<IProductCategoryDal>();

        var assembly = Assembly.GetExecutingAssembly();
        builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces().EnableInterfaceInterceptors(new ProxyGenerationOptions()
        {
            Selector = new AspectInterceptorSelector()
        }).SingleInstance();
    }
}