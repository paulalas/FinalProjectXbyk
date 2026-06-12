using Kentico.PageBuilder.Web.Mvc;
using Kentico.Xperience.Admin.Base.FormAnnotations;

namespace FinalProject.Widgets
{
    public class ServicesWidgetProperties : IWidgetProperties
    {
        [TextInputComponent(Label = "Section Title", Order = 1)]
        public string SectionTitle { get; set; } = "Our Services";

        [TextInputComponent(Label = "Section Title Highlight", Order = 2)]
        public string SectionTitleHighlight { get; set; } = "Services";

        [TextAreaComponent(Label = "Section Subtitle", Order = 3)]
        public string SectionSubtitle { get; set; } = "Explore what we have to offer.";
    }
}
