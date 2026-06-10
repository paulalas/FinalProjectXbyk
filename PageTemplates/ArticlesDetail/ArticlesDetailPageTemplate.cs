using Kentico.PageBuilder.Web.Mvc.PageTemplates;
using FinalProject;

[assembly: RegisterPageTemplate(
    identifier: "FinalProject.ArticlesDetailPageTemplate",
    name: "Articles Detail Page Template",
    customViewName: "~/PageTemplates/ArticlesDetail/ArticlesDetailPageTemplate.cshtml",
    ContentTypeNames = new[] { ArticlesDetail.CONTENT_TYPE_NAME },
    Description = "Articles detail page template displaying article information with thumbnail, title, content, and creation date",
    IconClass = "xp-layout-full")]

namespace FinalProject
{
    /// <summary>
    /// Articles Detail page template.
    /// </summary>
    public static class ArticlesDetailPageTemplate
    {
        public const string IDENTIFIER = "FinalProject.ArticlesDetail";
    }
}
