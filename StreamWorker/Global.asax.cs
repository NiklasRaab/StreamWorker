using System.Collections.Generic;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Framework.Mvc.Application;
using Framework.Mvc.Binding;
using Framework.Mvc.ViewModel;
using StreamWorker.ViewModels.Task;

namespace StreamWorker
{
    public class MvcApplication : BaseHttpApplication
    {
        protected override void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AutofacConfig.RegisterTypes();

            //ModelBinders.Binders.Add(typeof(IEnumerable<TimeLineEntryViewModel>), new BaseViewModelBinder());
            base.Application_Start();
        }
    }
}