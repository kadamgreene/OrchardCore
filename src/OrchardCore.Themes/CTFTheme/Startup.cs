using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using OrchardCore.ResourceManagement;
using OrchardCore.Themes.CTFTheme;

namespace OrchardCore.Themes.TheBlogTheme
{
    public class Startup : StartupBase
    {
        public override void Configure(IApplicationBuilder app)
        {
        }

        public override void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IResourceManifestProvider, ThemeResourceManifest>();
        }
    }
}
