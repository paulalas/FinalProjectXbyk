using Kentico.PageBuilder.Web.Mvc.PageTemplates;
using FigmaProject;

[assembly: RegisterPageTemplate(
    identifier: "FigmaProject.FigmaHomePageTemplate",
    name: "Figma Home Page Template",
    customViewName: "~/PageTemplates/FigmaHome/FigmaHomePageTemplate.cshtml",
    ContentTypeNames = new[] { "FigmaProject.Figma_Home" },
    Description = "Figma home page template with editable areas",
    IconClass = "xp-layout")]

namespace FigmaProject
{
    public static class FigmaHomePageTemplate
    {
        public const string IDENTIFIER = "FigmaProject.FigmaHome";
    }
}
