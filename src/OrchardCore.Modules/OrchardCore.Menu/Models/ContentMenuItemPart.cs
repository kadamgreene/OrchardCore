using OrchardCore.ContentFields.Fields;
using OrchardCore.ContentManagement;

namespace CTFTheme.Models
{
    public class ContentMenuItemPart : ContentPart
    {
        public ContentPickerField Target { get; set; }
    }
}
