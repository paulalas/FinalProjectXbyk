using System.Collections.Generic;
using CMS.ContentEngine;
using FigmaProject;
using FinalProject;
using Kentico.PageBuilder.Web.Mvc;
using Kentico.Xperience.Admin.Base.FormAnnotations;

namespace FinalProject.Widgets
{
    public class FigmaContentBlockWidgetProperties : IWidgetProperties
    {
        [TextInputComponent(Label = "Title", Order = 1)]
        public string Title { get; set; } = "How HomePro works?";

        [ContentItemSelectorComponent(Assets.CONTENT_TYPE_NAME, Label = "Worker Photo", MaximumItems = 1, Order = 2)]
        public IEnumerable<ContentItemReference> Image { get; set; }

        [ContentItemSelectorComponent(IconWithTitleAndText.CONTENT_TYPE_NAME, Label = "Steps", MaximumItems = 5, Order = 3)]
        public IEnumerable<ContentItemReference> Steps { get; set; }
    }
}
