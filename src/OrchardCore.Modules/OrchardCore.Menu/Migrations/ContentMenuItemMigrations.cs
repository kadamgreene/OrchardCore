using System.Threading.Tasks;
using CTFTheme.Models;
using OrchardCore.ContentFields.Fields;
using OrchardCore.ContentFields.Settings;
using OrchardCore.ContentManagement.Metadata;
using OrchardCore.ContentManagement.Metadata.Settings;
using OrchardCore.Data.Migration;
using OrchardCore.Recipes.Services;

namespace CTFTheme.Migrations
{
    public class ContentMenuItemMigrations : DataMigration
    {
        private readonly IContentDefinitionManager contentDefinitionManager;
        private readonly IRecipeMigrator recipeMigrator;

        public ContentMenuItemMigrations(IContentDefinitionManager contentDefinitionManager, IRecipeMigrator recipeMigrator)
        {
            this.contentDefinitionManager = contentDefinitionManager;
            this.recipeMigrator = recipeMigrator;
        }

        public int Create()
        {
            contentDefinitionManager.AlterPartDefinition(nameof(ContentMenuItemPart), part => {
                part.WithField(nameof(ContentMenuItemPart.Target), field => {
                    field
                        .OfType(nameof(ContentPickerField))
                        .WithDisplayName("Target")
                        .WithSettings(new ContentPickerFieldSettings {
                            DisplayedContentTypes = new string[]
                            {
                                "Page",
                                "Liquid Page",
                                "Blog",
                                "Tag",
                                "Category"
                            },
                            Multiple = false,
                            Required = true,
                            Hint = "Content Item to link to"
                        });
                });
            });

            contentDefinitionManager.AlterTypeDefinition("ContentMenuItem", builder => builder
                .WithPart(nameof(ContentMenuItemPart))
                .Stereotype("MenuItem")
            );

            return 1;
        }

        public async Task<int> UpdateFrom1Async()
        {
            await recipeMigrator.ExecuteAsync("menu.recipe.json", this);

            return 2;
        }
    }
}
