using Kentico.PageBuilder.Web.Mvc.PageTemplates;
using FinalProject;

[assembly: RegisterPageTemplate(
    identifier: "FinalProject.ArticlesListPageTemplate",
    name: "Articles List Page Template",
    customViewName: "~/Features/ArticlesList/ArticlesListPageTemplate.cshtml",
    ContentTypeNames = new[] { ArticlesList.CONTENT_TYPE_NAME },
    Description = "Articles list page template with single editable area for articles content",
    IconClass = "xp-layout-full")]

namespace FinalProject
{
    /// <summary>
    /// Articles List page template.
    /// </summary>
    public static class ArticlesListPageTemplate
    {
        public const string IDENTIFIER = "FinalProject.ArticlesList";
    }
}
