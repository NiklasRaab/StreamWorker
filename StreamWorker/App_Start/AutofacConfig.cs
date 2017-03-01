using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using StreamWorker.Business.Repository;
using StreamWorker.Data.DataContext;

namespace StreamWorker
{
    public class AutofacConfig
    {
        public static void RegisterTypes()
        {
            var builder = new ContainerBuilder();

            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            builder.RegisterType<StreamWorkerDataContext>()
                .InstancePerDependency();
            builder.RegisterType<TaskRepository>()
                .As<ITaskRepository>();
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}