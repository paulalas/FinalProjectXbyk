using System.Collections.Generic;
using CMS.ContentEngine;
using Kentico.PageBuilder.Web.Mvc;
using Kentico.Xperience.Admin.Base.FormAnnotations;

namespace FinalProject.Widgets
{
    public class FigmaHeroBannerWidgetProperties : IWidgetProperties
    {
        [ContentItemSelectorComponent(FigmaProject.IconWithTitleAndText.CONTENT_TYPE_NAME,
            Label = "Tagline Items (up to 3)",
            MaximumItems = 3,
            Order = 1)]
        public IEnumerable<ContentItemReference> TaglineItems { get; set; }

        [TextAreaComponent(Label = "Title", Order = 2)]
        public string Title { get; set; } = "Need improvement\nor repair your home?\nwe can help!";

        [ContentItemSelectorComponent(FigmaProject.IconWithTitleAndText.CONTENT_TYPE_NAME,
            Label = "Feature Items (up to 2)",
            MaximumItems = 2,
            Order = 3)]
        public IEnumerable<ContentItemReference> FeatureItems { get; set; }

        [TextInputComponent(Label = "Button Text", Order = 4)]
        public string ButtonText { get; set; } = "Call Us Now";

        [TextInputComponent(Label = "Button Link", Order = 5)]
        public string ButtonLink { get; set; } = "#";

        [ContentItemSelectorComponent(Assets.CONTENT_TYPE_NAME, Label = "Left Photo", MaximumItems = 1, Order = 6)]
        public IEnumerable<ContentItemReference> LeftPhoto { get; set; }

        [ContentItemSelectorComponent(Assets.CONTENT_TYPE_NAME, Label = "Right Photo", MaximumItems = 1, Order = 7)]
        public IEnumerable<ContentItemReference> RightPhoto { get; set; }

        [ContentItemSelectorComponent(FigmaProject.IconWithTitleAndText.CONTENT_TYPE_NAME,
            Label = "Highlight Items (up to 4)",
            MaximumItems = 4,
            Order = 8)]
        public IEnumerable<ContentItemReference> HighlightItems { get; set; }
    }
}
