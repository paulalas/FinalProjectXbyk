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
    FigmaFeaturesWidgetViewComponent.IDENTIFIER,
    typeof(FigmaFeaturesWidgetViewComponent),
    "Figma Features",
    typeof(FigmaFeaturesWidgetProperties),
    Description = "Feature highlights grid with icon cards driven by IconWithTitleAndText content items",
    IconClass = "icon-star")]

namespace FinalProject.Widgets
{
    public class FigmaFeaturesWidgetViewComponent : ViewComponent
    {
        public const string IDENTIFIER = "FinalProject.FigmaFeaturesWidget";

        private readonly IContentRetriever _contentRetriever;

        public FigmaFeaturesWidgetViewComponent(IContentRetriever contentRetriever)
        {
            _contentRetriever = contentRetriever;
        }

        public async Task<ViewViewComponentResult> InvokeAsync(FigmaFeaturesWidgetProperties properties)
        {
            var featureItems = new List<IconWithTitleAndText>();
            if (properties.FeatureItems?.Any() == true)
            {
                var guids = properties.FeatureItems.Select(r => r.Identifier).ToList();
                var results = await _contentRetriever.RetrieveContentByGuids<IconWithTitleAndText>(
                    guids,
                    new RetrieveContentParameters { LinkedItemsMaxLevel = 1 });
                featureItems = results.ToList();
            }

            var viewModel = new FigmaFeaturesWidgetViewModel
            {
                Title       = properties.Title,
                ContentText = properties.ContentText,
                FeatureItems = featureItems
            };

            return View("~/Components/Widgets/FigmaFeaturesWidget/FigmaFeaturesWidget.cshtml", viewModel);
        }
    }
}
