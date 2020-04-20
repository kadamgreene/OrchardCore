using OrchardCore.DisplayManagement.Manifest;
using OrchardCore.Modules.Manifest;

[assembly: Theme(
    Name = "Catch the Fire Theme",
    Author = "Catch the Fire Moncton",
    Website = "https://ctfmoncton.com",
    Version = "0.0.1",
    Description = "A theme conforming to Catch the Fire branding guidelines"
)]
[assembly: Module(
    // Name of the module to be displayed on the Modules page of the Dashboard.
    Name = "Catch the Fire Demo Module",
    // Your name, company or any name that identifies the developers working on the project.
    Author = "Catch the Fire",
    // Optionally you can add a website URL (e.g. your company's website, GitHub repository URL).
    Website = "https://ctfmoncton.com",
    // Version of the module.
    Version = "0.0.1",
    // Short description of the module. It will be displayed on the Dashboard.
    Description = "Orchard Core training demo module for teaching Orchard Core fundamentals primarily by going " +
        "through its source code.",
    // Modules are categorized on the Dashboard so it's a good idea to put similar modules together into a separate
    // section.
    Category = "Training",
    // Modules can have dependencies which are other module names (name of the project) or if these modules have
    // subfeatures then the name of the feature. If you use any service, taghelper etc. coming from an Orchard Core
    // feature then you need to include them in this list. Orchard Core will make sure to enable all dependent modules
    // when you enable a module that has dependencies. Without this some features would not work even if the assembly
    // is referenced in the project.
    Dependencies = new[]
    {
        //"Lombiq.VueJs",
        "OrchardCore.BackgroundTasks",
        "OrchardCore.Contents",
        "OrchardCore.ContentTypes",
        "OrchardCore.ContentFields",
        "OrchardCore.DynamicCache",
        "OrchardCore.Media",
        "OrchardCore.Navigation"
    }
)]
