using System.Collections.Generic;
using CMS.ContentEngine;
using FigmaProject;
using Kentico.PageBuilder.Web.Mvc;
using Kentico.Xperience.Admin.Base.FormAnnotations;

namespace FinalProject.Widgets
{
    public class FigmaServicesListWidgetProperties : IWidgetProperties
    {
        [TextInputComponent(Label = "Section Title", Order = 1)]
        public string SectionTitle { get; set; } = "Our Services";

        [TextAreaComponent(Label = "Section Subtitle", Order = 2)]
        public string SectionSubtitle { get; set; } = "You have problems with leaking pipes, broken tiles, lost keys or want to tidy up the trees around you, of course you need our help!";

        [ContentItemSelectorComponent(IconWithTitleAndText.CONTENT_TYPE_NAME, Label = "Service Cards", MaximumItems = 20, Order = 3)]
        public IEnumerable<ContentItemReference> ServiceCards { get; set; }

        [TextInputComponent(Label = "CTA Title", Order = 4)]
        public string CtaTitle { get; set; } = "More service?";

        [TextAreaComponent(Label = "CTA Text", Order = 5)]
        public string CtaText { get; set; } = "You can tell us what you need and we can help!";

        [TextInputComponent(Label = "CTA Button Text", Order = 6)]
        public string CtaButtonText { get; set; } = "Call Us Now";

        [TextInputComponent(Label = "CTA Button Link", Order = 7)]
        public string CtaButtonLink { get; set; } = "#";
    }
}
