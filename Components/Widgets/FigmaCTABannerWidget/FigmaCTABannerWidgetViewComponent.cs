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
    FigmaCTABannerWidgetViewComponent.IDENTIFIER,
    typeof(FigmaCTABannerWidgetViewComponent),
    "Figma CTA Banner",
    typeof(FigmaCTABannerWidgetProperties),
    Description = "Dark blue CTA banner with feature items and a call-to-action button",
    IconClass = "icon-megaphone")]

namespace FinalProject.Widgets
{
    public class FigmaCTABannerWidgetViewComponent : ViewComponent
    {
        public const string IDENTIFIER = "FinalProject.FigmaCTABannerWidget";

        private readonly IContentRetriever _contentRetriever;

        public FigmaCTABannerWidgetViewComponent(IContentRetriever contentRetriever)
        {
            _contentRetriever = contentRetriever;
        }

        public async Task<ViewViewComponentResult> InvokeAsync(FigmaCTABannerWidgetProperties properties)
        {
            var featureItems = new List<IconWithTitleAndText>();
            if (properties.FeatureItems?.Any() == true)
            {
                var guids = properties.FeatureItems.Select(r => r.Identifier).ToList();
                var results = await _contentRetriever.RetrieveContentByGuids<IconWithTitleAndText>(
                    guids,
                    new RetrieveContentParameters { LinkedItemsMaxLevel = 0 });
                featureItems = results.ToList();
            }

            string imageUrl = null;
            if (properties.Image?.Any() == true)
            {
                var imageGuids = properties.Image.Select(r => r.Identifier).ToList();
                var imageResults = await _contentRetriever.RetrieveContentByGuids<Assets>(
                    imageGuids,
                    new RetrieveContentParameters { LinkedItemsMaxLevel = 0 });
                imageUrl = imageResults.FirstOrDefault()?.Thumbnail?.Url;
            }

            var viewModel = new FigmaCTABannerWidgetViewModel
            {
                Title        = properties.Title,
                FeatureItems = featureItems,
                CtaText      = properties.CtaText,
                CtaLink      = properties.CtaLink,
                ImageUrl     = imageUrl
            };

            return View("~/Components/Widgets/FigmaCTABannerWidget/FigmaCTABannerWidget.cshtml", viewModel);
        }
    }
}
