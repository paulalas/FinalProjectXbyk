using System.Collections.Generic;
using CMS.ContentEngine;
using Kentico.PageBuilder.Web.Mvc;
using Kentico.Xperience.Admin.Base.FormAnnotations;

namespace FinalProject.Widgets
{
    public class FigmaFrequentlyAskedQuestionsWidgetProperties : IWidgetProperties
    {
        [TextInputComponent(Label = "Title", Order = 1)]
        public string Title { get; set; } = "Frequently Asked Questions";

        [TextInputComponent(Label = "Help Text", Order = 2)]
        public string HelpText { get; set; } = "Still need help?";

        [TextInputComponent(Label = "Help Link Text", Order = 3)]
        public string HelpLinkText { get; set; } = "Get Help Now";

        [TextInputComponent(Label = "Help Link URL", Order = 4)]
        public string HelpLinkUrl { get; set; } = "#";

        [ContentItemSelectorComponent(FigmaProject.FrequentQuestions.CONTENT_TYPE_NAME,
            Label = "FAQ Items",
            MaximumItems = 20,
            Order = 5)]
        public IEnumerable<ContentItemReference> Items { get; set; }
    }
}
