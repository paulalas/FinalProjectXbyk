using System.Collections.Generic;
using CMS.ContentEngine;
using FigmaProject;
using Kentico.PageBuilder.Web.Mvc;
using Kentico.Xperience.Admin.Base.FormAnnotations;

namespace FinalProject.Widgets
{
    public class FigmaFeaturesWidgetProperties : IWidgetProperties
    {
        [TextInputComponent(Label = "Title", Order = 1)]
        public string Title { get; set; } = "Fast, Friendly, and Satisfaction Guarantee";

        [TextAreaComponent(Label = "Content Text", Order = 2)]
        public string ContentText { get; set; } = "No matter how big or small your work is, whether it's for the interior or exterior of your home, we are ready to serve and help you solve your home problems.";

        [ContentItemSelectorComponent(IconWithTitleAndText.CONTENT_TYPE_NAME, Label = "Feature Items", MaximumItems = 6, Order = 3)]
        public IEnumerable<ContentItemReference> FeatureItems { get; set; }
    }
}
