using Kentico.PageBuilder.Web.Mvc.PageTemplates;
using FinalProject;

[assembly: RegisterPageTemplate(
    identifier: "FinalProject.AboutUsPageTemplate",
    name: "About Us Page Template",
    //propertiesType: typeof(FinalProject.AboutUsPageTemplateProperties),
    customViewName: "~/PageTemplates/AboutUs/AboutUsPageTemplate.cshtml",
    ContentTypeNames = new[] { AboutUs.CONTENT_TYPE_NAME },
    Description = "About Us page template with 4 editable areas for hero, main content, features, and call to action sections",
    IconClass = "xp-layout-80-20")]

namespace FinalProject
{
    /// <summary>
    /// About Us page template properties.
    /// </summary>
    // public class AboutUsPageTemplateProperties : IPageTemplateProperties
    // {
    //     // Add custom properties here if needed in the future
    //     // For now, this template doesn't require any custom properties
    // }

    public static class AboutUsPageTemplate
    {
            public const string IDENTIFIER = "FinalProject.AboutUs";
    }

}
