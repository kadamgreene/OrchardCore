using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CTFTheme.Models;
using CTFTheme.ViewModels;
using OrchardCore.ContentManagement;
using OrchardCore.ContentManagement.Display.ContentDisplay;
using OrchardCore.ContentManagement.Display.Models;
using OrchardCore.DisplayManagement.Views;
using OrchardCore.DisplayManagement.ModelBinding;

namespace CTFTheme.Drivers
{
    public class ContentMenuItemPartDisplayDriver : ContentPartDisplayDriver<ContentMenuItemPart>
    {
        private readonly IContentManager contentManager;

        public ContentMenuItemPartDisplayDriver(IContentManager contentManager)
        {
            this.contentManager = contentManager;
        }

        public override IDisplayResult Display(ContentMenuItemPart part, BuildPartDisplayContext context)
        {
            return Combine(
               Dynamic($"{nameof(ContentMenuItemPart)}_Admin", shape =>
               {
                   shape.MenuItemPart = part;
               })
               .Location("Admin", "Content:10"),
               Dynamic($"{nameof(ContentMenuItemPart)}_Thumbnail", shape =>
               {
                   shape.MenuItemPart = part;
               })
               .Location("Thumbnail", "Content:10")
           );
        }

        public override IDisplayResult Edit(ContentMenuItemPart part)
        {
            return Initialize<ContentMenuItemPartEditViewModel>("ContentMenuItemPart_Edit", model => {
                model.Target = part.Target;
                model.MenuItemPart = part;
            });
        }

        public override async Task<IDisplayResult> UpdateAsync(ContentMenuItemPart part, IUpdateModel updater)
        {
            await updater.TryUpdateModelAsync(part, Prefix, x => x.Target);

            return Edit(part);
        }
    }
}
