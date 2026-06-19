using System.Collections.Generic;
using CMS.ContentEngine;
using Kentico.PageBuilder.Web.Mvc;
using Kentico.Xperience.Admin.Base.FormAnnotations;

namespace FinalProject.Widgets
{
    public class FigmaCTABannerWidgetProperties : IWidgetProperties
    {
        [TextInputComponent(Label = "Title", Order = 1)]
        public string Title { get; set; } = "Already to improve or repair your home? Let's Talk!";

        [ContentItemSelectorComponent(FigmaProject.IconWithTitleAndText.CONTENT_TYPE_NAME,
            Label = "Feature Items",
            MaximumItems = 6,
            Order = 2)]
        public IEnumerable<ContentItemReference> FeatureItems { get; set; }

        [TextInputComponent(Label = "CTA Button Text", Order = 3)]
        public string CtaText { get; set; } = "Call Us Now";

        [TextInputComponent(Label = "CTA Button Link", Order = 4)]
        public string CtaLink { get; set; } = "#";

        [ContentItemSelectorComponent(FinalProject.Assets.CONTENT_TYPE_NAME,
            Label = "Banner Image",
            MaximumItems = 1,
            Order = 5)]
        public IEnumerable<ContentItemReference> Image { get; set; }
    }
}
