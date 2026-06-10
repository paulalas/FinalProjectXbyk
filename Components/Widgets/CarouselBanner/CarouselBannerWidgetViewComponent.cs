using Kentico.PageBuilder.Web.Mvc;
using Kentico.Content.Web.Mvc;
using Kentico.Content.Web.Mvc.Routing;
using FinalProject.Widgets;
using FinalProject;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CMS.ContentEngine;
using CMS.Websites;

[assembly: RegisterWidget(
    CarouselBannerWidgetViewComponent.IDENTIFIER,
    typeof(CarouselBannerWidgetViewComponent),
    "Carousel Banner",
    typeof(CarouselBannerWidgetProperties),
    Description = "Displays a carousel of banner items with background images, titles, content, and buttons",
    IconClass = "xp-icon-rectangle")]

namespace FinalProject.Widgets
{
    public class CarouselBannerWidgetViewComponent : ViewComponent
    {
        public const string IDENTIFIER = "FinalProject.CarouselBannerWidget";

        private readonly IContentRetriever _contentRetriever;
        private readonly IWebPageUrlRetriever _urlRetriever;
        private readonly IPreferredLanguageRetriever _languageRetriever;

        public CarouselBannerWidgetViewComponent(
            IContentRetriever contentRetriever,
            IWebPageUrlRetriever urlRetriever,
            IPreferredLanguageRetriever languageRetriever)
        {
            _contentRetriever = contentRetriever;
            _urlRetriever = urlRetriever;
            _languageRetriever = languageRetriever;
        }

        public async Task<ViewViewComponentResult> InvokeAsync(CarouselBannerWidgetProperties properties)
        {
            var carouselItems = new List<CarouselBanner>();

            if (properties?.CarouselItems != null && properties.CarouselItems.Any())
            {
                var selectedGuids = properties.CarouselItems.Select(x => x.Identifier).ToList();

                var items = await _contentRetriever.RetrieveContentByGuids<CarouselBanner>(
                    selectedGuids,
                    new RetrieveContentParameters
                    {
                        LinkedItemsMaxLevel = 1
                    }
                );

                carouselItems = items.ToList();
            }

            var languageName = _languageRetriever.Get();
            var itemViewModels = new List<CarouselBannerItemViewModel>();

            foreach (var item in carouselItems)
            {
                string buttonUrl = "";
                var webPage = item.ButtonLink?.FirstOrDefault();
                if (webPage != null)
                {
                    try
                    {
                        var url = await _urlRetriever.Retrieve(webPage.WebPageGuid, languageName, false);
                        buttonUrl = url.RelativePath;
                    }
                    catch { }
                }

                itemViewModels.Add(new CarouselBannerItemViewModel { Item = item, ButtonUrl = buttonUrl });
            }

            var viewModel = new CarouselBannerWidgetViewModel
            {
                CarouselItems = itemViewModels
            };

            return View("~/Components/Widgets/CarouselBanner/CarouselBannerWidget.cshtml", viewModel);
        }
    }
}
