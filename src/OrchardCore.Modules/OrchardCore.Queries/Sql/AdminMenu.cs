using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Localization;
using OrchardCore.Navigation;

namespace OrchardCore.Queries.Sql
{
    public class AdminMenu : INavigationProvider
    {
        private readonly IStringLocalizer S;

        public AdminMenu(IStringLocalizer<AdminMenu> localizer)
        {
            S = localizer;
        }

        public Task BuildNavigationAsync(string name, NavigationBuilder builder)
        {
            if (!String.Equals(name, "admin", StringComparison.OrdinalIgnoreCase))
            {
                return Task.CompletedTask;
            }

            builder
                .Add(S["Search"], search => search
                    .Add(S["Queries"], "am-" + S["Queries"], queries => queries
                        .Add(S["Run SQL Query"], "am-" + S["Run SQL Query"], sql => sql
                            .Action("Query", "Admin", new { area = "OrchardCore.Queries" })
                            .Permission(Permissions.ManageSqlQueries)
                            .LocalNav())));

            return Task.CompletedTask;
        }
    }
}
