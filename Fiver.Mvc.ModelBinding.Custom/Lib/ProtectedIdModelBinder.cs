using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Threading.Tasks;

namespace FFiver.Mvc.ModelBinding.Custom.Lib
{
    public class ProtectedIdModelBinder : IModelBinder
    {
        private readonly IDataProtector protector;

        public ProtectedIdModelBinder(IDataProtectionProvider provider)
        {
            this.protector = provider.CreateProtector("protect_my_query_string");
        }

        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            var valueProviderResult =
                bindingContext.ValueProvider.GetValue(bindingContext.ModelName);

            if (valueProviderResult == ValueProviderResult.None)
                return Task.CompletedTask;

            bindingContext.ModelState.SetModelValue(
                    bindingContext.ModelName, valueProviderResult);

            var result = this.protector.Unprotect(valueProviderResult.FirstValue);

            bindingContext.Result = ModelBindingResult.Success(result);
            return Task.CompletedTask;
        }
    }
}
