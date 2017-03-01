using System.Web;
using System.Web.Mvc;
using Framework.Mvc.Binding;
using Framework.Mvc.ViewModel;

namespace Framework.Mvc.Application
{
    public class BaseHttpApplication : HttpApplication
    {
        protected virtual void Application_Start()
        {

            ModelBinders.Binders.DefaultBinder = new BaseViewModelBinder();
        }
    }
}
