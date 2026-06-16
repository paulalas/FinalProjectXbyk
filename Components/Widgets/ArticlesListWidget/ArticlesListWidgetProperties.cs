using Kentico.PageBuilder.Web.Mvc;
using Kentico.Xperience.Admin.Base.FormAnnotations;

namespace FinalProject.Widgets
{
    public class ArticlesListWidgetProperties : IWidgetProperties
    {
        [TextInputComponent(Label = "Section Title", Order = 1)]
        public string SectionTitle { get; set; } = "All Articles";

        [TextInputComponent(Label = "Section Title Highlight", Order = 2)]
        public string SectionTitleHighlight { get; set; } = "Articles";

        [TextAreaComponent(Label = "Section Subtitle", Order = 3)]
        public string SectionSubtitle { get; set; } = "Browse all of our latest news and articles.";
    }
}
