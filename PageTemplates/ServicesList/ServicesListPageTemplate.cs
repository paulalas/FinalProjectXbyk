using Kentico.PageBuilder.Web.Mvc.PageTemplates;
using FinalProject;

[assembly: RegisterPageTemplate(
    identifier: "FinalProject.ServicesListPageTemplate",
    name: "Services List Page Template",
    customViewName: "~/PageTemplates/ServicesList/ServicesListPageTemplate.cshtml",
    ContentTypeNames = new[] { ServicesList.CONTENT_TYPE_NAME },
    Description = "Services list page template with single editable area for services content",
    IconClass = "xp-layout-full")]

namespace FinalProject
{
    /// <summary>
    /// Services List page template.
    /// </summary>
    public static class ServicesListPageTemplate
    {
        public const string IDENTIFIER = "FinalProject.ServicesList";
    }
}
