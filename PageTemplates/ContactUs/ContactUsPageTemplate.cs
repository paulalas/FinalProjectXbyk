using Kentico.PageBuilder.Web.Mvc.PageTemplates;
using FinalProject;

[assembly: RegisterPageTemplate(
    identifier: "FinalProject.ContactUsPageTemplate",
    name: "Contact Us Page Template",
    customViewName: "~/PageTemplates/ContactUs/ContactUsPageTemplate.cshtml",
    ContentTypeNames = new[] { ContactUs.CONTENT_TYPE_NAME },
    Description = "Contact us page template with single editable area for contact content",
    IconClass = "xp-layout-full")]

namespace FinalProject
{
    /// <summary>
    /// Contact Us page template.
    /// </summary>
    public static class ContactUsPageTemplate
    {
        public const string IDENTIFIER = "FinalProject.ContactUs";
    }
}
