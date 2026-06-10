using Kentico.PageBuilder.Web.Mvc.PageTemplates;
using FinalProject;

[assembly: RegisterPageTemplate(
    identifier: "FinalProject.HomePageTemplate",
    name: "Home Page Template",
    //propertiesType: typeof(FinalProject.HomePageTemplateProperties),
    customViewName: "~/Features/Home/HomePageTemplate.cshtml",
    ContentTypeNames = new[] { Home.CONTENT_TYPE_NAME },
    Description = "Home page template with 4 editable areas for hero, main content, features, and call to action sections",
    IconClass = "xp-layout-80-20")]

namespace FinalProject
{
    /// <summary>
    /// Home page template properties.
    /// </summary>
    // public class HomePageTemplateProperties : IPageTemplateProperties
    // {
    //     // Add custom properties here if needed in the future
    //     // For now, this template doesn't require any custom properties
    // }

    public static class HomePageTemplate
    {
            public const string IDENTIFIER = "FinalProject.Home";
    }

}
