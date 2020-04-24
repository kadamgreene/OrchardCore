using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using CTFTheme.Models;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Localization;
using OrchardCore.ContentFields.Fields;

namespace CTFTheme.ViewModels
{
    public class ContentMenuItemPartEditViewModel
    {
        public ContentMenuItemPart MenuItemPart { get; set; }
        public ContentPickerField Target { get; internal set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var T = validationContext.GetService<IStringLocalizer<ContentMenuItemPartEditViewModel>>();
            if (Target == null || Target.ContentItemIds?.Length == 0)
            {
                yield return new ValidationResult(T["Target is required"]);
            }
        }
    }
}
