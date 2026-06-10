using Kentico.PageBuilder.Web.Mvc;
using Kentico.Content.Web.Mvc;
using FinalProject.Widgets;
using FinalProject;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CMS.ContentEngine;

[assembly: RegisterWidget(
    CarouselBannerWidgetViewComponent.IDENTIFIER,
    typeof(CarouselBannerWidgetViewComponent),
    "Carousel Banner",
    typeof(CarouselBannerWidgetProperties),
    Description = "Displays a carousel of banner items with background images, titles, content, and buttons",
    IconClass = "xp-icon-rectangle")]

namespace FinalProject.Widgets
{
    /// <summary>
    /// View component for carousel banner widget.
    /// </summary>
    public class CarouselBannerWidgetViewComponent : ViewComponent
    {
        public const string IDENTIFIER = "FinalProject.CarouselBannerWidget";

        private readonly IContentRetriever _contentRetriever;

        public CarouselBannerWidgetViewComponent(IContentRetriever contentRetriever)
        {
            _contentRetriever = contentRetriever;
        }

        public async Task<ViewViewComponentResult> InvokeAsync(CarouselBannerWidgetProperties properties)
        {
            var carouselItems = new List<CarouselBanner>();

            if (properties?.CarouselItems != null && properties.CarouselItems.Any())
            {
                var selectedGuids = properties.CarouselItems.Select(x => x.Identifier).ToList();

                // Retrieve carousel banner content items by GUID
                var items = await _contentRetriever.RetrieveContentByGuids<CarouselBanner>(
                    selectedGuids,
                    new RetrieveContentParameters
                    {
                        LinkedItemsMaxLevel = 1
                    }
                );

                carouselItems = items.ToList();
            }

            var viewModel = new CarouselBannerWidgetViewModel
            {
                CarouselItems = carouselItems
            };

            return View("~/Components/Widgets/CarouselBanner/CarouselBannerWidget.cshtml", viewModel);
        }
    }
}
