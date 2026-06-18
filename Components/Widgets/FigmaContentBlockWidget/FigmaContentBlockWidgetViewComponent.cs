using Kentico.PageBuilder.Web.Mvc;
using Kentico.Content.Web.Mvc;
using FinalProject.Widgets;
using FigmaProject;
using FinalProject;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CMS.ContentEngine;

[assembly: RegisterWidget(
    FigmaContentBlockWidgetViewComponent.IDENTIFIER,
    typeof(FigmaContentBlockWidgetViewComponent),
    "Figma Content Block",
    typeof(FigmaContentBlockWidgetProperties),
    Description = "How-it-works section with a photo and numbered steps driven by IconWithTitleAndText content items",
    IconClass = "icon-list")]

namespace FinalProject.Widgets
{
    public class FigmaContentBlockWidgetViewComponent : ViewComponent
    {
        public const string IDENTIFIER = "FinalProject.FigmaContentBlockWidget";

        private readonly IContentRetriever _contentRetriever;

        public FigmaContentBlockWidgetViewComponent(IContentRetriever contentRetriever)
        {
            _contentRetriever = contentRetriever;
        }

        public async Task<ViewViewComponentResult> InvokeAsync(FigmaContentBlockWidgetProperties properties)
        {
            var imageUrl = "";
            if (properties.Image?.Any() == true)
            {
                var guid = properties.Image.First().Identifier;
                var assets = await _contentRetriever.RetrieveContentByGuids<Assets>(
                    new[] { guid },
                    new RetrieveContentParameters { LinkedItemsMaxLevel = 1 });
                imageUrl = assets.FirstOrDefault()?.Thumbnail?.Url ?? "";
            }

            var steps = new List<IconWithTitleAndText>();
            if (properties.Steps?.Any() == true)
            {
                var guids = properties.Steps.Select(r => r.Identifier).ToList();
                var results = await _contentRetriever.RetrieveContentByGuids<IconWithTitleAndText>(
                    guids,
                    new RetrieveContentParameters { LinkedItemsMaxLevel = 1 });
                steps = results.ToList();
            }

            var viewModel = new FigmaContentBlockWidgetViewModel
            {
                Title    = properties.Title,
                ImageUrl = imageUrl,
                Steps    = steps
            };

            return View("~/Components/Widgets/FigmaContentBlockWidget/FigmaContentBlockWidget.cshtml", viewModel);
        }
    }
}
