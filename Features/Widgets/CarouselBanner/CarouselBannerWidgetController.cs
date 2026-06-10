using Kentico.PageBuilder.Web.Mvc;
using Kentico.Content.Web.Mvc;
using FinalProject.Widgets;

namespace FinalProject.Widgets
{
    [WidgetComponent(
        Identifier = "FinalProject.CarouselBannerWidget",
        Name = "Carousel Banner",
        DefaultName = "Carousel Banner",
        Description = "Displays a carousel of banner items with background images, titles, content, and buttons",
        IconClass = "xp-icon-rectangle")]
    public class CarouselBannerWidgetController : WidgetController<CarouselBannerWidgetProperties>
    {
        private readonly IContentRetriever contentRetriever;

        public CarouselBannerWidgetController(IContentRetriever contentRetriever)
        {
            this.contentRetriever = contentRetriever;
        }

        public async Task<IActionResult> Index()
        {
            var properties = GetProperties();
            
            return View("~/Features/Widgets/CarouselBanner/CarouselBannerWidget.cshtml", properties);
        }
    }
}
