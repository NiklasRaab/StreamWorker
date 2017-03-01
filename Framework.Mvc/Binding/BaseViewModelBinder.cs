using System;
using System.Linq;
using System.Web.Mvc;
using Framework.Mvc.ViewModel;

namespace Framework.Mvc.Binding
{
    public class BaseViewModelBinder : DefaultModelBinder
    {
        protected override object CreateModel(ControllerContext controllerContext, ModelBindingContext bindingContext, Type modelType)
        {
            var typeValue = bindingContext.ValueProvider.GetValue((string.IsNullOrEmpty(bindingContext.ModelName) ? "" : bindingContext.ModelName + ".") + nameof(BaseViewModel.ConcreteModelType));

            if (typeValue == null) return base.CreateModel(controllerContext, bindingContext, modelType);
            var type = modelType.Assembly.GetTypes().SingleOrDefault(x => x.IsSubclassOf(modelType) && x.FullName == typeValue.AttemptedValue);

            if (type == null)
                throw new NullReferenceException("The class of subtype can't be found. Type:" + typeValue.AttemptedValue);
            var model = Activator.CreateInstance(type);
            bindingContext.ModelMetadata = ModelMetadataProviders.Current.GetMetadataForType(() => model, type);
            return model;
        }
    }
}
