using System.Collections.Generic;
using CMS.ContentEngine;
using Kentico.PageBuilder.Web.Mvc;
using Kentico.Xperience.Admin.Base.FormAnnotations;

namespace FinalProject.Widgets
{
    public class FigmaHeroBannerWidgetProperties : IWidgetProperties
    {
        [TextInputComponent(Label = "Tagline Word 1", Order = 1)]
        public string TaglineWord1 { get; set; } = "Maintenances";

        [TextInputComponent(Label = "Tagline Word 2", Order = 2)]
        public string TaglineWord2 { get; set; } = "Repairs";

        [TextInputComponent(Label = "Tagline Word 3", Order = 3)]
        public string TaglineWord3 { get; set; } = "Improvements";

        [TextAreaComponent(Label = "Title", Order = 4)]
        public string Title { get; set; } = "Need improvement\nor repair your home?\nwe can help!";

        [TextInputComponent(Label = "Button Text", Order = 5)]
        public string ButtonText { get; set; } = "Call Us Now";

        [TextInputComponent(Label = "Button Link", Order = 6)]
        public string ButtonLink { get; set; } = "#";

        [ContentItemSelectorComponent(Assets.CONTENT_TYPE_NAME, Label = "Left Photo", MaximumItems = 1, Order = 7)]
        public IEnumerable<ContentItemReference> LeftPhoto { get; set; }

        [ContentItemSelectorComponent(Assets.CONTENT_TYPE_NAME, Label = "Right Photo", MaximumItems = 1, Order = 8)]
        public IEnumerable<ContentItemReference> RightPhoto { get; set; }

        [TextInputComponent(Label = "Highlight 1 Label", Order = 9)]
        public string Highlight1Label { get; set; } = "Satisfaction Guarantee";

        [TextInputComponent(Label = "Highlight 2 Label", Order = 10)]
        public string Highlight2Label { get; set; } = "24H Availability";

        [TextInputComponent(Label = "Highlight 3 Label", Order = 11)]
        public string Highlight3Label { get; set; } = "Local US Professional";

        [TextInputComponent(Label = "Highlight 4 Label", Order = 12)]
        public string Highlight4Label { get; set; } = "Flexible Appointments";
    }
}
