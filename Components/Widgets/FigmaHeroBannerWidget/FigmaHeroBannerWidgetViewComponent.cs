using Kentico.PageBuilder.Web.Mvc;
using Kentico.Content.Web.Mvc;
using FinalProject.Widgets;
using FinalProject;
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
                TaglineWord1    = properties.TaglineWord1,
                TaglineWord2    = properties.TaglineWord2,
                TaglineWord3    = properties.TaglineWord3,
                Title           = properties.Title,
                ButtonText      = properties.ButtonText,
                ButtonLink      = properties.ButtonLink,
                LeftPhotoUrl    = await GetPhotoUrl(properties.LeftPhoto),
                RightPhotoUrl   = await GetPhotoUrl(properties.RightPhoto),
                Highlight1Label = properties.Highlight1Label,
                Highlight2Label = properties.Highlight2Label,
                Highlight3Label = properties.Highlight3Label,
                Highlight4Label = properties.Highlight4Label
            };

            return View("~/Components/Widgets/FigmaHeroBannerWidget/FigmaHeroBannerWidget.cshtml", viewModel);
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
