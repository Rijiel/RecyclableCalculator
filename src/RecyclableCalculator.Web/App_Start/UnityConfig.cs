using RecyclableCalculator.Core.Domain.RepositoryContracts;
using RecyclableCalculator.Core.ServiceContracts;
using RecyclableCalculator.Core.Services;
using RecyclableCalculator.Infrastructure.Repositories;
using System.Web.Mvc;
using Unity;
using Unity.Mvc5;

namespace RecyclableCalculator.Web
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            
            // register all your components with the container here
            // it is NOT necessary to register your controllers
            
            // e.g. container.RegisterType<ITestService, TestService>();

           // container.RegisterType<IRecyclableItemRepository, RecyclableItemRepository>();
            container.RegisterType<IRecyclableTypeRepository, RecyclableTypeRepository>();
            container.RegisterType<IRecyclableItemRepository, RecyclableItemRepository>();
            container.RegisterType<IRecyclableTypeService, RecyclableTypeService>();
			container.RegisterType<IRecyclableItemService, RecyclableItemService>();
            
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}