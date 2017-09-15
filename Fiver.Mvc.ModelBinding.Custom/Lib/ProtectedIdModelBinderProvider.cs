using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using System.Linq;

namespace Fiver.Mvc.ModelBinding.Custom.Lib
{
    public class ProtectedIdModelBinderProvider : IModelBinderProvider
    {
        public IModelBinder GetBinder(ModelBinderProviderContext context)
        {
            if (context.Metadata.IsComplexType) return null;

            var propName = context.Metadata.PropertyName;
            if (propName == null) return null;

            var propInfo = context.Metadata.ContainerType.GetProperty(propName);
            if (propInfo == null) return null;

            var attribute = propInfo.GetCustomAttributes(
                typeof(IProtectedIdAttribute), false).FirstOrDefault();
            if (attribute == null) return null;

            return new BinderTypeModelBinder(typeof(ProtectedIdModelBinder));
        }
    }
}
