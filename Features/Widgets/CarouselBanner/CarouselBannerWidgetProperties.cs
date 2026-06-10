using Kentico.PageBuilder.Web.Mvc;
using FinalProject;

namespace FinalProject.Widgets
{
    public class CarouselBannerWidgetProperties : IWidgetProperties
    {
        /// <summary>
        /// Selected carousel banner items
        /// </summary>
        public IEnumerable<CarouselBanner> CarouselItems { get; set; } = new List<CarouselBanner>();
    }
}
