using System.Web.Mvc;

namespace Framework.Mvc.ViewModel
{
    public abstract class BaseViewModel
    {

        [HiddenInput(DisplayValue = false)]
        public virtual string ConcreteModelType => this.GetType().ToString();
    }
}