using Kentico.PageBuilder.Web.Mvc;
using Kentico.Content.Web.Mvc;
using FinalProject.Widgets;
using FigmaProject;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CMS.ContentEngine;

[assembly: RegisterWidget(
    FigmaFrequentlyAskedQuestionsWidgetViewComponent.IDENTIFIER,
    typeof(FigmaFrequentlyAskedQuestionsWidgetViewComponent),
    "Figma FAQ",
    typeof(FigmaFrequentlyAskedQuestionsWidgetProperties),
    Description = "Accordion FAQ section driven by FrequentQuestions content items",
    IconClass = "icon-question-circle")]

namespace FinalProject.Widgets
{
    public class FigmaFrequentlyAskedQuestionsWidgetViewComponent : ViewComponent
    {
        public const string IDENTIFIER = "FinalProject.FigmaFrequentlyAskedQuestionsWidget";

        private readonly IContentRetriever _contentRetriever;

        public FigmaFrequentlyAskedQuestionsWidgetViewComponent(IContentRetriever contentRetriever)
        {
            _contentRetriever = contentRetriever;
        }

        public async Task<ViewViewComponentResult> InvokeAsync(FigmaFrequentlyAskedQuestionsWidgetProperties properties)
        {
            var items = new List<FrequentQuestions>();
            if (properties.Items?.Any() == true)
            {
                var guids = properties.Items.Select(r => r.Identifier).ToList();
                var results = await _contentRetriever.RetrieveContentByGuids<FrequentQuestions>(
                    guids,
                    new RetrieveContentParameters { LinkedItemsMaxLevel = 0 });
                items = results.ToList();
            }

            var viewModel = new FigmaFrequentlyAskedQuestionsWidgetViewModel
            {
                Title       = properties.Title,
                HelpText    = properties.HelpText,
                HelpLinkText = properties.HelpLinkText,
                HelpLinkUrl = properties.HelpLinkUrl,
                Items       = items
            };

            return View("~/Components/Widgets/FigmaFrequentlyAskedQuestionsWidget/FigmaFrequentlyAskedQuestionsWidget.cshtml", viewModel);
        }
    }
}
