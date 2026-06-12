using Kentico.PageBuilder.Web.Mvc;
using Kentico.Xperience.Admin.Base.FormAnnotations;

namespace FinalProject.Widgets
{
    public class LatestArticlesWidgetProperties : IWidgetProperties
    {
        [TextInputComponent(Label = "Section Title", Order = 1)]
        public string SectionTitle { get; set; } = "Latest Articles";

        [TextInputComponent(Label = "Section Title Highlight", Order = 2)]
        public string SectionTitleHighlight { get; set; } = "Articles";

        [TextAreaComponent(Label = "Section Subtitle", Order = 3)]
        public string SectionSubtitle { get; set; } = "Stay up to date with our latest news and articles.";
    }
}
