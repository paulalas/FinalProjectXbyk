using Kentico.PageBuilder.Web.Mvc;
using Kentico.Content.Web.Mvc;
using FinalProject.Widgets;
using FinalProject;
using FigmaProject;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CMS.ContentEngine;

[assembly: RegisterWidget(
    FigmaHeroBannerWidgetViewComponent.IDENTIFIER,
    typeof(FigmaHeroBannerWidgetViewComponent),
    "Figma Hero Banner",
    typeof(FigmaHeroBannerWidgetProperties),
    Description = "Full-width hero banner with photos, tagline, title, CTA button, and highlights",
    IconClass = "icon-layout")]

namespace FinalProject.Widgets
{
    public class FigmaHeroBannerWidgetViewComponent : ViewComponent
    {
        public const string IDENTIFIER = "FinalProject.FigmaHeroBannerWidget";

        private readonly IContentRetriever _contentRetriever;

        public FigmaHeroBannerWidgetViewComponent(IContentRetriever contentRetriever)
        {
            _contentRetriever = contentRetriever;
        }

        public async Task<ViewViewComponentResult> InvokeAsync(FigmaHeroBannerWidgetProperties properties)
        {
            var viewModel = new FigmaHeroBannerWidgetViewModel
            {
                TaglineItems   = await FetchIconItems(properties.TaglineItems),
                Title          = properties.Title,
                FeatureItems   = await FetchIconItems(properties.FeatureItems),
                ButtonText     = properties.ButtonText,
                ButtonLink     = properties.ButtonLink,
                LeftPhotoUrl   = await GetPhotoUrl(properties.LeftPhoto),
                RightPhotoUrl  = await GetPhotoUrl(properties.RightPhoto),
                HighlightItems = await FetchIconItems(properties.HighlightItems)
            };

            return View("~/Components/Widgets/FigmaHeroBannerWidget/FigmaHeroBannerWidget.cshtml", viewModel);
        }

        private async Task<List<IconWithTitleAndText>> FetchIconItems(IEnumerable<ContentItemReference> refs)
        {
            if (refs?.Any() != true) return new List<IconWithTitleAndText>();

            var guids = refs.Select(r => r.Identifier).ToList();
            var results = await _contentRetriever.RetrieveContentByGuids<IconWithTitleAndText>(
                guids,
                new RetrieveContentParameters { LinkedItemsMaxLevel = 0 });
            return results.ToList();
        }

        private async Task<string> GetPhotoUrl(IEnumerable<ContentItemReference> refs)
        {
            var guid = refs?.FirstOrDefault()?.Identifier;
            if (guid == null) return "";

            var results = await _contentRetriever.RetrieveContentByGuids<Assets>(
                new[] { guid.Value },
                new RetrieveContentParameters { LinkedItemsMaxLevel = 1 });

            return results.FirstOrDefault()?.Thumbnail?.Url ?? "";
        }
    }
}
