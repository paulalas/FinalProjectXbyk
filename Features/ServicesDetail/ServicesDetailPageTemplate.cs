using Kentico.PageBuilder.Web.Mvc.PageTemplates;
using FinalProject;

[assembly: RegisterPageTemplate(
    identifier: "FinalProject.ServicesDetailPageTemplate",
    name: "Services Detail Page Template",
    customViewName: "~/Features/ServicesDetail/ServicesDetailPageTemplate.cshtml",
    ContentTypeNames = new[] { ServicesDetail.CONTENT_TYPE_NAME },
    Description = "Services detail page template displaying service information with thumbnail, title, content, and creation date",
    IconClass = "xp-layout-full")]

namespace FinalProject
{
    /// <summary>
    /// Services Detail page template.
    /// </summary>
    public static class ServicesDetailPageTemplate
    {
        public const string IDENTIFIER = "FinalProject.ServicesDetail";
    }
}
