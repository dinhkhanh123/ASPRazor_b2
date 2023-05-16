using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding;
/*
- chuyen ten thanh in hoa
- ten khong duoc chua xxx
- cac khoang trang khong duoc o dau va o cuoi
**/
public class UserNameBinding : IModelBinder
{
    public Task BindModelAsync(ModelBindingContext bindingContext)
    {
        if (bindingContext == null)
            throw new ArgumentNullException("bindingContext");

        string modelName = bindingContext.ModelName;

        // doc gia tri gui den
        var valueProviderResult = bindingContext.ValueProvider.GetValue(modelName);

        if (valueProviderResult == ValueProviderResult.None)
        {
            return Task.CompletedTask;
        }
        string value = valueProviderResult.FirstValue;

        if (string.IsNullOrEmpty(value))
            return Task.CompletedTask;

        string s = value.ToUpper();

        if (s.Contains("XXX"))
        {
            bindingContext.ModelState.SetModelValue(modelName, valueProviderResult);
            bindingContext.ModelState.TryAddModelError(modelName, "loi do chua XXX");
            return Task.CompletedTask;
        }
        s = s.Trim();
        bindingContext.ModelState.SetModelValue(modelName, s, s);
        bindingContext.Result = ModelBindingResult.Success(s);
        return Task.CompletedTask;
    }
}