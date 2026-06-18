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
    FigmaAboutUsWidgetViewComponent.IDENTIFIER,
    typeof(FigmaAboutUsWidgetViewComponent),
    "Figma About Us",
    typeof(FigmaAboutUsWidgetProperties),
    Description = "About Us section with title, description, service list items, and house image",
    IconClass = "icon-home")]

namespace FinalProject.Widgets
{
    public class FigmaAboutUsWidgetViewComponent : ViewComponent
    {
        public const string IDENTIFIER = "FinalProject.FigmaAboutUsWidget";

        private readonly IContentRetriever _contentRetriever;

        public FigmaAboutUsWidgetViewComponent(IContentRetriever contentRetriever)
        {
            _contentRetriever = contentRetriever;
        }

        public async Task<ViewViewComponentResult> InvokeAsync(FigmaAboutUsWidgetProperties properties)
        {
            var serviceItems = new List<AboutUsTextData>();
            if (properties.ServiceItems?.Any() == true)
            {
                var guids = properties.ServiceItems.Select(r => r.Identifier).ToList();
                var results = await _contentRetriever.RetrieveContentByGuids<AboutUsTextData>(
                    guids,
                    new RetrieveContentParameters { LinkedItemsMaxLevel = 1 });
                serviceItems = results.ToList();
            }

            var viewModel = new FigmaAboutUsWidgetViewModel
            {
                Title         = properties.Title,
                ContentText   = properties.ContentText,
                ServiceItems  = serviceItems,
                NoteText      = properties.NoteText,
                NoteLinkText  = properties.NoteLinkText,
                NoteLinkHref  = properties.NoteLinkHref,
                HouseImageUrl = await GetAssetUrl(properties.HouseImage)
            };

            return View("~/Components/Widgets/FigmaAboutUsWidget/FigmaAboutUsWidget.cshtml", viewModel);
        }

        private async Task<string> GetAssetUrl(IEnumerable<ContentItemReference> refs)
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
